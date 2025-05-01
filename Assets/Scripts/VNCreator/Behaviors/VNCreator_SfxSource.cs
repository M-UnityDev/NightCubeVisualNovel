using UnityEngine;

namespace VNCreator
{
    [RequireComponent(typeof(AudioSource))]
    public class VNCreator_SfxSource : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        public static VNCreator_SfxSource instance;
        private void Start()
        {
            instance = this;
            UpdateSoundVolume(GameOptions.sfxVolume);
        }
        public void UpdateSoundVolume(float value) => source.volume = value;
        public void Play(AudioClip clip)
        {
            source.PlayOneShot(clip);
        }
    }
}
