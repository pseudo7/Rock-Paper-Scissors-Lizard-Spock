using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RPSLS.GameData
{
    public class MemoryRelease : MonoBehaviour
    {
        public event Action<AssetReference, MemoryRelease> OnObjectDestroyed;

        internal AssetReference CurrentAssetReference { private get; set; }

        private void OnDestroy() =>
            OnObjectDestroyed?.Invoke(CurrentAssetReference, this);
    }
}