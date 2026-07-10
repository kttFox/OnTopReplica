using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace OnTopReplica {

    /// <summary>
    /// アプリケーション設定 (Settings.Default) を user.config の代わりに
    /// 実行ファイルと同じフォルダーの XML ファイルへ保存するプロバイダー。
    /// ログや PanelLayout と同様に exe 横へ保存され、ポータブル運用が可能になる。
    /// </summary>
    public sealed class PortableSettingsProvider : SettingsProvider {

        const string FileName = "OnTopReplica.Settings.xml";
        const string RootName = "Settings";

        static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

        XDocument _doc;

        public override string Name => "PortableSettingsProvider";

        public override string ApplicationName {
            get { return "OnTopReplica"; }
            set { }
        }

        public override void Initialize(string name, NameValueCollection config) {
            base.Initialize(name ?? Name, config);
        }

        XElement LoadRoot() {
            if (_doc == null) {
                try {
                    if (File.Exists(FilePath)) {
                        var doc = XDocument.Load(FilePath);
                        if (doc.Root != null && doc.Root.Name == RootName)
                            _doc = doc;
                    }
                }
                catch (Exception ex) {
                    Log.WriteException("Unable to load settings file", ex);
                }
                if (_doc == null)
                    _doc = new XDocument(new XElement(RootName));
            }
            return _doc.Root;
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection) {
            var root = LoadRoot();
            var values = new SettingsPropertyValueCollection();

            foreach (SettingsProperty prop in collection) {
                var value = new SettingsPropertyValue(prop) {
                    IsDirty = false
                };
                var elem = root.Element(prop.Name);
                if (elem != null) {
                    //Stored as text content; deserialized lazily according to SerializeAs
                    value.SerializedValue = elem.Value;
                }
                values.Add(value);
            }
            return values;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection) {
            var root = LoadRoot();

            foreach (SettingsPropertyValue value in collection) {
                var serialized = value.SerializedValue as string
                    ?? value.SerializedValue?.ToString();

                var elem = root.Element(value.Name);
                if (serialized == null) {
                    elem?.Remove();
                    continue;
                }
                if (elem == null) {
                    elem = new XElement(value.Name);
                    root.Add(elem);
                }
                elem.Value = serialized;
                value.IsDirty = false;
            }

            try {
                _doc.Save(FilePath);
            }
            catch (Exception ex) {
                Log.WriteException("Unable to save settings file", ex);
            }
        }
    }
}
