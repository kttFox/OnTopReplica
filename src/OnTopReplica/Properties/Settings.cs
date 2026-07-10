using System.Configuration;

namespace OnTopReplica.Properties {

    /// <summary>
    /// 設定の保存先を実行ファイルと同じフォルダー (OnTopReplica.Settings.xml) に
    /// 切り替える。属性は partial クラス経由で自動生成コードに合成される。
    /// </summary>
    [SettingsProvider(typeof(OnTopReplica.PortableSettingsProvider))]
    internal sealed partial class Settings {

        public Settings() {
            //設定値が変更されたら即座にファイルへ保存する
            PropertyChanged += (s, e) => Save();
        }
    }
}
