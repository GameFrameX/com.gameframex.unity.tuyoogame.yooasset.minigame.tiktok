#if UNITY_WEBGL && DOUYINMINIGAME
using YooAsset;

namespace GameFrameX.Asset.YooAsset.Minigame.TikTok.Runtime.Operation
{
    [UnityEngine.Scripting.Preserve]
    public partial class TTFSInitializeOperation : FSInitializeFileSystemOperation
    {
        private readonly TiktokFileSystem _fileSystem;

        [UnityEngine.Scripting.Preserve]
        public TTFSInitializeOperation(TiktokFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        [UnityEngine.Scripting.Preserve]
        protected override void InternalStart()
        {
            Status = EOperationStatus.Succeed;
        }

        [UnityEngine.Scripting.Preserve]
        protected override void InternalUpdate()
        {
        }
    }
}
#endif