# OnTopReplica

**A real-time always-on-top “replica” of a window of your choice, for Windows Vista, 7, 8, or 10.**

This simple utility application shows a blank always-on-top window by default.
Users can pick any other window of the system to have an always up-to-date clone of the target window shown always-on-top.
Very useful for monitoring background processes, wrangling with complex multi-window games or tools, watching Youtube videos while working, and so on.

**📢 Features:**

* Clone any of your windows and keep it *always-on-top* while working with other windows,
* Color‑alert feature lets you monitor a target window for a chosen colour; open the **Color Alert** side panel, select a colour and check “Enable Color Detection” (settings take effect immediately).  If the monitored window contains the colour the alarm will sound for 3 seconds and an entry is written to the log.
* Select a subregion of the cloned window, which:
  * Can be stored for future use,
  * Can use relative coordinates from the target window’s borders.
* Auto-resizing (fit the original window, half, quarter and fullscreen mode),
* Position lock on any corner of your screen,
* Adjustable opacity (10% steps),
* “Click forwarding”: allows to interact with the cloned window,
* “Click-through”: makes the replica ignore any mouse interaction (turns **OnTopReplica** into an overlay if set together with partial opacity),
* ~~“Group switch”-mode automatically switches through a group of windows while you use them.~~

## このフォークでの変更点 (Fork changes)

### マルチパネル

* 右クリックメニューの **「パネルを追加」** で、同じ対象ウィンドウの別領域を表示するパネルを何枚でも開けます。
  * 対象ウィンドウはメイン(プライマリ)パネルと常に同期します。監視領域・カラーアラート設定・不透明度・枠の有無はパネルごとに独立です。
* 最小化・復元・「Switch to window」は全パネルを一括で操作します。

### レイアウトの自動保存・復元

* パネル構成(対象ウィンドウ・位置・サイズ・枠の有無・監視領域・カラーアラート設定)は**変更のたびに即時保存**され、次回起動時に全パネルが復元されます(`%AppData%\OnTopReplica\PanelLayout.txt`)。
* 対象ウィンドウが起動していなくても常駐ウォッチャーが監視し、**後から起動された時点で自動的に再接続**します(セッション中に対象が終了→再起動した場合も同様)。

### カラーアラートの拡張

* 検出色: 赤・オレンジ・グレーのカテゴリに加え、**カスタム色**を指定できます。画面上の任意の点をクリックして色を取得するサンプリング機能付きです(サンプリング中はカーソル追従の色プレビューを表示)。
* 警報音: 同梱のWAV/MP3(`Sounds` フォルダにファイルを置くだけで選択肢に反映)に加え、Windowsのシステムサウンドを選択できます。
* 検出はパネルごとに独立して動作します。

### その他

* 自動アップデート機能を削除しました(起動時のネットワークアクセスなし)。
* 「最後のウィンドウを復元」「前回の位置とサイズを復元」等の旧設定は、上記のレイアウト自動復元に一本化して削除しました。
* ターゲットフレームワークを .NET Framework 4.8 に更新しました。

## Requirements

* Microsoft Windows Vista or greater (the application makes use of native DWM&nbsp;Thumbnails to create replicas),
* Microsoft .NET Framework 4.8.
* Desktop Composition (a.k.a. Windows *Aero*) enabled.

## Logging & Troubleshooting
If the executable does not start when you double‑click it, check for a log file in the same folder as the executable:

```
<application folder>\lastrun.log.txt
```

The program records startup details (version, command line, OS/CLR, current directory) and any exceptions.  A crash dump (`OnTopReplica-dump-*.txt`) is written to the desktop if an unhandled exception occurs.

No log file at all usually means the process failed before the CLR loaded; verify that .NET Framework 4.8 (or later) is installed.

## Installation

Get the [latest version](https://github.com/LorenzCK/OnTopReplica/releases) from the releases section as an MSI&nbsp;installer.

## Contributions

…are very welcome. Fork away! 🍽️

Submitting [issues](https://github.com/LorenzCK/OnTopReplica/issues) and other feedback is also appreciated.

### Roadmap

1. ✅&nbsp;Update to the newest [WindowsFormsAero](https://github.com/LorenzCK/WindowsFormsAero) version.
1. ✅&nbsp;Migrate to .NET 4.7.
1. Improve/add **High DPI** support!
1. “Stored scenarios” that, just like stored regions, automatically clone a window (based on title or window class criteria), select a region, and set other options. Ideally to be used as Taskbar shortlinks.
1. Move to the Windows Store, via Centennial. 🤞

## License

**OnTopReplica** is licensed under the [MS-RL (Microsoft Reciprocal License)](https://github.com/LorenzCK/OnTopReplica/blob/master/LICENSE).
