<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X YooAsset MiniGame TikTok

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok)](https://github.com/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok)](https://github.com/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

GameFrameX YooAsset TikTok MiniGame runtime component for Unity WebGL, providing adapter implementations for the TikTok MiniGame file system and asset bundle loading workflow.

## Features

- Provides TikTok MiniGame-specific IFileSystem implementation
- Adapts TTSDK AssetBundle download and caching workflow
- Supports package version requests, manifest loading, and asset bundle download and loading
- Compatible with remote services and decryption services

## Runtime Requirements

- Unity 2019.4
- Platform: UNITY_WEBGL
- Conditional compilation: DOUYINMINIGAME
- Dependencies: YooAsset, StarkWebGL, TTWebGL

## Installation (choose one)

1. Add to `manifest.json` dependencies:
   ```json
   {
     "com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok": "https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok.git"
   }
   ```
2. Add via Unity Package Manager using Git URL:
   https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok.git
3. Download the repository directly and place it in the Unity project's `Packages` directory

## Usage

1. Ensure the TikTok MiniGame SDK is integrated and the `DOUYINMINIGAME` macro is enabled
2. Use `TiktokFileSystemCreater.CreateFileSystemParameters(...)` to generate file system parameters
3. Pass the parameters to YooAsset's file system creation workflow
4. Follow YooAsset's standard workflow for initialization, version requests, manifest loading, and asset loading

## Main Types

- `TiktokFileSystem`: TikTok MiniGame file system implementation
- `TiktokFileSystemCreater`: File system parameter builder entry point
- `LoadTiktokAssetBundleOperation`: Asset bundle download and loading operation
- `UnityTiktokAssetBundleRequestOperation`: Download request wrapper based on TTSDK

## Notes

- The TikTok MiniGame cache root directory must be set, otherwise an exception will be thrown
- If no remote service is configured, it falls back to the web server path
