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

## 安裝方式（任選其一）

1. 在 `manifest.json` 的 `dependencies` 中添加
   ```json
   {
     "com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok": "https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok.git"
   }
   ```
2. 在 Unity 的 Package Manager 使用 Git URL 添加
   https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok.git
3. 直接下載倉庫放到 Unity 項目的 `Packages` 目錄

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
