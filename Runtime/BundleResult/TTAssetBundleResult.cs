#if UNITY_WEBGL && DOUYINMINIGAME
using TTSDK;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

namespace GameFrameX.Asset.YooAsset.Minigame.TikTok.Runtime.BundleResult
{
    [UnityEngine.Scripting.Preserve]
    public class TtAssetBundleResult : global::YooAsset.BundleResult
    {
        private readonly IFileSystem _fileSystem;
        private readonly PackageBundle _packageBundle;
        private readonly AssetBundle _assetBundle;

        [UnityEngine.Scripting.Preserve]
        public TtAssetBundleResult(IFileSystem fileSystem, PackageBundle packageBundle, AssetBundle assetBundle)
        {
            _fileSystem = fileSystem;
            _packageBundle = packageBundle;
            _assetBundle = assetBundle;
        }

        [UnityEngine.Scripting.Preserve]
        public override void UnloadBundleFile()
        {
            if (_assetBundle == null)
            {
                return;
            }

            if (_packageBundle.Encrypted)
            {
                _assetBundle.Unload(true);
            }
            else
            {
                _assetBundle.TTUnload(true);
            }
        }

        [UnityEngine.Scripting.Preserve]
        public override string GetBundleFilePath()
        {
            return _fileSystem.GetBundleFilePath(_packageBundle);
        }

        [UnityEngine.Scripting.Preserve]
        public override byte[] ReadBundleFileData()
        {
            return _fileSystem.ReadBundleFileData(_packageBundle);
        }

        [UnityEngine.Scripting.Preserve]
        public override string ReadBundleFileText()
        {
            return _fileSystem.ReadBundleFileText(_packageBundle);
        }

        [UnityEngine.Scripting.Preserve]
        public override FSLoadAssetOperation LoadAssetAsync(AssetInfo assetInfo)
        {
            var operation = new AssetBundleLoadAssetOperation(_packageBundle, _assetBundle, assetInfo);
            return operation;
        }

        [UnityEngine.Scripting.Preserve]
        public override FSLoadAllAssetsOperation LoadAllAssetsAsync(AssetInfo assetInfo)
        {
            var operation = new AssetBundleLoadAllAssetsOperation(_packageBundle, _assetBundle, assetInfo);
            return operation;
        }

        [UnityEngine.Scripting.Preserve]
        public override FSLoadSubAssetsOperation LoadSubAssetsAsync(AssetInfo assetInfo)
        {
            var operation = new AssetBundleLoadSubAssetsOperation(_packageBundle, _assetBundle, assetInfo);
            return operation;
        }

        [UnityEngine.Scripting.Preserve]
        public override FSLoadSceneOperation LoadSceneOperation(AssetInfo assetInfo, LoadSceneParameters loadParams, bool suspendLoad)
        {
            var operation = new AssetBundleLoadSceneOperation(assetInfo, loadParams, suspendLoad);
            return operation;
        }
    }
}
#endif