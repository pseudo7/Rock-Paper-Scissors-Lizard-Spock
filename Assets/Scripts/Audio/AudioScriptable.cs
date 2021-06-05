using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RPSLS.Audio
{
    [CreateAssetMenu(fileName = "Audio Data", menuName = "Audio/Create Data File", order = 1)]
    public class AudioScriptable : ScriptableObject
    {
        [SerializeField] private AssetReferenceT<AudioClip> audioClip;
        [Range(0F, 1F)] public float volume = 1;
        [SerializeField] private string audioTag;
        public bool loop;
        public bool isMusic;

        internal string AudioTag => audioTag;

        internal AssetReferenceT<AudioClip> AssetReference => audioClip;

        internal static void InstantiateAudio(AudioScriptable audioData, GameObject gameObject,
            in AudioClip audioClip, out AudioSource source)
        {
            source = gameObject.AddComponent<AudioSource>();
            source.clip = audioClip;
            source.volume = audioData.volume;
            source.loop = audioData.loop;
        }
    }
}