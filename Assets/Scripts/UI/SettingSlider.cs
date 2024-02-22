using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public abstract class SettingSlider : MonoBehaviour
    {
        [SerializeField] private Slider _currentSlider;

        public Slider CurrentSlider => _currentSlider;
        private void Awake()
        {
            PreInitialization();
        }
        private void Start()
        {
            PostInitialization();
        }

        protected virtual void OnEnable()
        {
            _currentSlider.onValueChanged.AddListener(delegate { SetConfigurationValue(_currentSlider.value); });
        }
        protected virtual void OnDisable()
        {
            _currentSlider.onValueChanged.RemoveListener(delegate { SetConfigurationValue(_currentSlider.value); });
        }
        protected virtual void PreInitialization()
        {

        }
        protected virtual void PostInitialization()
        {
            SetSliderValueOnLoad();
        }
        protected abstract void SetConfigurationValue(float configureValue);
        protected abstract void SetSliderValueOnLoad();
    }
}