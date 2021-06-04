using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RPSLS.GameData
{
    [CreateAssetMenu(fileName = "AddressableResource ", menuName = "Create Resource")]
    public class AddressableAssetScriptableObject : ScriptableObject
    {
        [SerializeField] private string assetKey;
        [SerializeField] private AssetReference assetReference;

        internal string AssetKey => assetKey;
        internal AssetReference AssetReference => assetReference;
    }
}