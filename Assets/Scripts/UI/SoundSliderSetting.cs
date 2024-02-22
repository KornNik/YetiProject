using UnityEngine;
using UnityEngine.Audio;
using Helpers.Managers;
using Helpers.Extensions;

namespace GameUI
{
    [System.Serializable]
    public class SoundSliderSetting : SettingSlider
    {
        public const string MIXER_NAME = "Master";

        [SerializeField] private AudioMixer _audioMixer;

        protected override void SetConfigurationValue(float configureValue)
        {
            _audioMixer.SetFloat(MIXER_NAME, Mathf.Log10(configureValue) * 20);
            SaveFileExtender.SaveFile(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.AUDIO_VOLUME_KEY, configureValue);
        }
        protected override void SetSliderValueOnLoad()
        {
            var volume = SaveFileExtender.LoadFile<float>(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.AUDIO_VOLUME_KEY);
            CurrentSlider.value = volume;
        }
    }
}
