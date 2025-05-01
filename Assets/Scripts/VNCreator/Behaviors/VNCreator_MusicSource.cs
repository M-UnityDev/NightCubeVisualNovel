using UnityEngine;
namespace VNCreator
{
    [RequireComponent(typeof(AudioSource))]
    public class VNCreator_MusicSource : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        public static VNCreator_MusicSource instance;
        private void Start()
        {
            instance = this;
            UpdateSoundVolume(GameOptions.musicVolume);
        }
        public void UpdateSoundVolume(float value) => source.volume = value;
        public void Play(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
