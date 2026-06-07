<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X YooAsset MiniGame TikTok

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok)](https://github.com/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok)](https://github.com/GameFrameX/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#quick-start) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

GameFrameX의 YooAsset TikTok 미니게임 런타임 컴포넌트로, Unity WebGL 플랫폼을 대상으로 TikTok 미니게임 파일 시스템 및 애셋 번들 로딩 워크플로우에 대한 어댑터 구현을 제공합니다.

## 기능 특징

- TikTok 미니게임 전용 IFileSystem 구현 제공
- TTSDK의 AssetBundle 다운로드 및 캐싱 워크플로우에 대응
- 패키지 버전 요청, 매니페스트 로딩, 애셋 번들 다운로드 및 로딩 지원
- 원격 서비스 및 복호화 서비스 연동 가능

## 실행 환경

- Unity 2019.4
- 플랫폼: UNITY_WEBGL
- 조건부 컴파일: DOUYINMINIGAME
- 의존성: YooAsset, StarkWebGL, TTWebGL

## 설치 방법 (택 1)

1. `manifest.json`의 `dependencies`에 추가:
   ```json
   {
     "com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok": "https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok.git"
   }
   ```
2. Unity Package Manager에서 Git URL을 사용하여 추가:
   https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.minigame.tiktok.git
3. 저장소를 직접 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치

## 사용 방법

1. TikTok 미니게임 SDK가 통합되어 있고 `DOUYINMINIGAME` 매크로가 활성화되어 있는지 확인
2. `TiktokFileSystemCreater.CreateFileSystemParameters(...)`로 파일 시스템 매개변수 생성
3. 매개변수를 YooAsset의 파일 시스템 생성 워크플로우에 전달
4. YooAsset의 표준 워크플로우에 따라 초기화, 버전 요청, 매니페스트 로딩 및 애셋 로딩 수행

## 주요 타입

- `TiktokFileSystem`: TikTok 미니게임 파일 시스템 구현
- `TiktokFileSystemCreater`: 파일 시스템 매개변수 빌더 진입점
- `LoadTiktokAssetBundleOperation`: 애셋 번들 다운로드 및 로딩 작업
- `UnityTiktokAssetBundleRequestOperation`: TTSDK 기반 다운로드 요청 래퍼

## 주의 사항

- TikTok 미니게임의 캐시 루트 디렉토리를 설정해야 합니다. 그렇지 않으면 예외가 발생합니다
- 원격 서비스가 구성되지 않은 경우 웹 서버 경로로 대체됩니다
