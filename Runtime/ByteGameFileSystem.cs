#if UNITY_WEBGL && DOUYIN_MINI_GAME
using System.Collections.Generic;
using StarkSDKSpace;
using UnityEngine;
using UnityEngine.Scripting;
using YooAsset;

namespace GameFrameX.Asset.YooAsset.Minigame.TikTok.Runtime
{
    [UnityEngine.Scripting.Preserve]
    public static class ByteGameFileSystemCreater
    {
        [Preserve]
        public static FileSystemParameters CreateByteGameFileSystemParameters(IRemoteServices remoteServices = null)
        {
            string fileSystemClass = typeof(ByteGameFileSystem).FullName;
            var fileSystemParams = new FileSystemParameters(fileSystemClass, null);
            fileSystemParams.AddParameter(FileSystemParametersDefine.REMOTE_SERVICES, remoteServices);
            return fileSystemParams;
        }

        [Preserve]
        public static FileSystemParameters CreateByteGameFileSystemParameters(string buildinPackRoot)
        {
            string fileSystemClass = typeof(ByteGameFileSystem).FullName;
            IRemoteServices remoteServices = new ByteGameFileSystem.WebRemoteServices(buildinPackRoot);
            var fileSystemParams = new FileSystemParameters(fileSystemClass, null);
            fileSystemParams.AddParameter(FileSystemParametersDefine.REMOTE_SERVICES, remoteServices);
            return fileSystemParams;
        }
    }

    /// <summary>
    /// 抖音小游戏文件系统
    /// 参考：https://developer.open-douyin.com/docs/resource/zh-CN/mini-game/develop/guide/know
    /// </summary>
    public class ByteGameFileSystem : IFileSystem
    {
        [UnityEngine.Scripting.Preserve]
        public sealed class WebRemoteServices : IRemoteServices
        {
            private readonly string _webPackageRoot;
            protected readonly Dictionary<string, string> _mapping = new Dictionary<string, string>(10000);

            [Preserve]
            public WebRemoteServices(string buildinPackRoot)
            {
                _webPackageRoot = buildinPackRoot;
            }

            [Preserve]
            string IRemoteServices.GetRemoteMainURL(string fileName)
            {
                return GetFileLoadURL(fileName);
            }

            [Preserve]
            string IRemoteServices.GetRemoteFallbackURL(string fileName)
            {
                return GetFileLoadURL(fileName);
            }

            [Preserve]
            private string GetFileLoadURL(string fileName)
            {
                if (_mapping.TryGetValue(fileName, out string url) == false)
                {
                    string filePath = PathUtility.Combine(_webPackageRoot, fileName);
                    url = DownloadSystemHelper.ConvertToWWWPath(filePath);
                    _mapping.Add(fileName, url);
                }

                return url;
            }
        }

        private readonly Dictionary<string, string> _cacheFilePaths = new Dictionary<string, string>(10000);
        private StarkFileSystemManager _fileSystemManager;

        /// <summary>
        /// 包裹名称
        /// </summary>
        public string PackageName { private set; get; }

        /// <summary>
        /// 文件根目录
        /// </summary>
        public string FileRoot
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 文件数量
        /// </summary>
        public int FileCount
        {
            get { return 0; }
        }

        #region 自定义参数

        /// <summary>
        /// 自定义参数：远程服务接口
        /// </summary>
        public IRemoteServices RemoteServices { private set; get; } = null;

        #endregion

        [Preserve]
        public ByteGameFileSystem()
        {
            PackageName = string.Empty;
        }

        [Preserve]
        public virtual FSInitializeFileSystemOperation InitializeFileSystemAsync()
        {
            var operation = new BGFSInitializeOperation(this);
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual FSLoadPackageManifestOperation LoadPackageManifestAsync(string packageVersion, int timeout)
        {
            var operation = new BGFSLoadPackageManifestOperation(this, packageVersion, timeout);
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual FSRequestPackageVersionOperation RequestPackageVersionAsync(bool appendTimeTicks, int timeout)
        {
            var operation = new BGFSRequestPackageVersionOperation(this, timeout);
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual FSClearAllBundleFilesOperation ClearAllBundleFilesAsync()
        {
            var operation = new FSClearAllBundleFilesCompleteOperation();
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual FSClearUnusedBundleFilesOperation ClearUnusedBundleFilesAsync(PackageManifest manifest)
        {
            var operation = new FSClearUnusedBundleFilesCompleteOperation();
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual FSDownloadFileOperation DownloadFileAsync(PackageBundle bundle, DownloadParam param)
        {
            param.MainURL = RemoteServices.GetRemoteMainURL(bundle.FileName);
            param.FallbackURL = RemoteServices.GetRemoteFallbackURL(bundle.FileName);
            var operation = new BGFSDownloadFileOperation(this, bundle, param);
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual FSLoadBundleOperation LoadBundleFile(PackageBundle bundle)
        {
            var operation = new BGFSLoadBundleOperation(this, bundle);
            OperationSystem.StartOperation(PackageName, operation);
            return operation;
        }

        [Preserve]
        public virtual void UnloadBundleFile(PackageBundle bundle, object result)
        {
            AssetBundle assetBundle = result as AssetBundle;
            if (assetBundle != null)
            {
                assetBundle.Unload(true);
            }
        }

        [Preserve]
        public virtual void SetParameter(string name, object value)
        {
            if (name == FileSystemParametersDefine.REMOTE_SERVICES)
            {
                RemoteServices = (IRemoteServices)value;
            }
            else
            {
                YooLogger.Warning($"Invalid parameter : {name}");
            }
        }

        [Preserve]
        public virtual void OnCreate(string packageName, string rootDirectory)
        {
            PackageName = packageName;

            // 注意：CDN服务未启用的情况下，使用抖音WEB服务器
            if (RemoteServices == null)
            {
                string webRoot = PathUtility.Combine(Application.streamingAssetsPath, YooAssetSettingsData.Setting.DefaultYooFolderName, packageName);
                RemoteServices = new WebRemoteServices(webRoot);
            }

            _fileSystemManager = StarkSDK.API.GetStarkFileSystemManager();
        }

        [Preserve]
        public virtual void OnUpdate()
        {
        }

        [Preserve]
        public virtual bool Belong(PackageBundle bundle)
        {
            return true;
        }

        [Preserve]
        public virtual bool Exists(PackageBundle bundle)
        {
            string filePath = GetCacheFileLoadPath(bundle);
            return _fileSystemManager.AccessSync(filePath);
        }

        [Preserve]
        public virtual bool NeedDownload(PackageBundle bundle)
        {
            if (Belong(bundle) == false)
            {
                return false;
            }

            return Exists(bundle) == false;
        }

        [Preserve]
        public virtual bool NeedUnpack(PackageBundle bundle)
        {
            return false;
        }

        [Preserve]
        public virtual bool NeedImport(PackageBundle bundle)
        {
            return false;
        }

        [Preserve]
        public virtual byte[] ReadFileData(PackageBundle bundle)
        {
            throw new System.NotImplementedException();
        }

        [Preserve]
        public virtual string ReadFileText(PackageBundle bundle)
        {
            throw new System.NotImplementedException();
        }

        #region 内部方法

        private string GetCacheFileLoadPath(PackageBundle bundle)
        {
            if (_cacheFilePaths.TryGetValue(bundle.BundleGUID, out string filePath) == false)
            {
                filePath = _fileSystemManager.GetLocalCachedPathForUrl(bundle.FileName);
                _cacheFilePaths.Add(bundle.BundleGUID, filePath);
            }

            return filePath;
        }

        #endregion
    }
#endif
}