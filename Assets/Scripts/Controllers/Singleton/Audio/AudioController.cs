using UnityEngine;
using Helpers.Singleton;

namespace Helpers.Audio
{
    class AudioController : PersistanceSingleton<AudioController>
    {
        [SerializeField] private AudioSource _audioSource;

        private AudioClip _audioClip;

        public void PlaySound(string resourcesName)
        {
            _audioClip = Resources.Load(resourcesName) as AudioClip;
            _audioSource.PlayOneShot(_audioClip);
        }

        private void Update()
        {
            if (!_audioSource.isPlaying && _audioClip != null)
            {
                Resources.UnloadAsset(_audioClip);
                _audioClip = null;
            }
        }
    }
}