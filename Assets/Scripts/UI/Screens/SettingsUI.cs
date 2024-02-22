using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Helpers.Extensions;
using Helpers.Managers;

namespace GameUI
{
    class SettingsUI : BaseUI
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Slider _soundSlider;

        private void OnEnable()
        {
            _saveButton.onClick.AddListener(OnSaveButtonDown);
            _backButton.onClick.AddListener(OnBackButtonDown);
        }
        private void OnDisable()
        {
            _saveButton.onClick.RemoveListener(OnSaveButtonDown);
            _backButton.onClick.RemoveListener(OnBackButtonDown);
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            GetPlayerName();
            ShowUI.Invoke();

        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
        private void GetPlayerName()
        {
            var currentName = SaveFileExtender.LoadFile<string>(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.PLAYER_NAME_KEY);
            _nameInputField.text = currentName;
        }
        private void OnSaveButtonDown()
        {
            if (CheckNameString(_nameInputField.text))
            {
                SaveFileExtender.SaveFileFresh(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.PLAYER_NAME_KEY,_nameInputField.text);
            }
        }
        private void OnBackButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);
        }
        private bool CheckNameString(string name)
        {
            if (name == null ||name.Contains(' '))
            {
                return false;
            }
            else { return true; }
        }
    }
}
