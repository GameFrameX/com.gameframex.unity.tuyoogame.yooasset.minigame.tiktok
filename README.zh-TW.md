<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X YooAsset MiniGame TikTok

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok)](https://github.com/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok)](https://github.com/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#quick-start) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

GameFrameX 的 YooAsset 抖音小遊戲（TikTok MiniGame）運行時組件，面向 Unity WebGL 平台，提供與抖音小遊戲文件系統、資源包加載流程的適配實現。

## 功能特性

- 提供抖音小遊戲專用的 IFileSystem 實現
- 適配 TTSDK 的 AssetBundle 下載與緩存流程
- 支持包版本請求、清單加載、資源包下載與加載
- 可對接遠程服務與解密服務

## 運行環境

- Unity 2019.4
- 平台：UNITY_WEBGL
- 條件編譯：DOUYINMINIGAME
- 依賴：YooAsset、StarkWebGL、TTWebGL

## 安裝

### 安裝

編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

`scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok": "1.1.1"
  }
}
```


## 使用說明

1. 確保已接入抖音小遊戲 SDK，並啟用 `DOUYINMINIGAME` 宏
2. 通過 `TiktokFileSystemCreater.CreateFileSystemParameters(...)` 生成文件系統參數
3. 將參數傳入 YooAsset 的文件系統創建流程
4. 按照 YooAsset 的常規流程進行初始化、版本請求、清單加載與資源加載

## 主要類型

- `TiktokFileSystem`：抖音小遊戲文件系統實現
- `TiktokFileSystemCreater`：文件系統參數構建入口
- `LoadTiktokAssetBundleOperation`：資源包下載與加載操作
- `UnityTiktokAssetBundleRequestOperation`：基於 TTSDK 的下載請求封裝

## 注意事項

- 需要設置抖音小遊戲的緩存根目錄，否則會拋出異常
- 未配置遠程服務時會回退到 Web 服務器路徑
