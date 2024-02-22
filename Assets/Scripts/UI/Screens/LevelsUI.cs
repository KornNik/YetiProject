using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    class LevelsUI : BaseUI
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Transform _levelButtonsParent;

        private Button[] _levelButtons;
        protected override void Awake()
        {
            base.Awake();
            _levelButtons = _levelButtonsParent.GetComponentsInChildren<Button>();
        }
        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonDown);

            foreach (var button in _levelButtons)
            {
                button.onClick.AddListener(OnLevelButtonDown);
            }
        }
        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonDown);

            foreach (var button in _levelButtons)
            {
                button.onClick.RemoveListener(OnLevelButtonDown);
            }
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
        private void OnLevelButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.GameMenu);
        }
        private void OnBackButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);
        }
    }
}
