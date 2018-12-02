# Localization

Unity で言語ローカライズをするためのモジュール.
現段階でサポートしている言語は以下の通り:
- en
- ja

## Requirements
- Generic
- TMPro
- Odin


## How To Use
1. シーンに LocalizationManager をアタッチしたゲームオブジェクトを配置する.
2. LocalizationTable スクリプタブルオブジェクトをプロジェクト内に作成する.
3. LocalizationManager.tables に 2 で作成したアセットをセットする.
4. ゲーム開始時に LocalizationManager.SetLanguage を呼び出す.

