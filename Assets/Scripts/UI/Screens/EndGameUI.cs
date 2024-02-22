using UnityEngine;
using UnityEngine.UI;
using Controllers;

namespace GameUI
{
    class EndGameUI : BaseUI
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonDown);
            _homeButton.onClick.AddListener(OnHomeButtonDown);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonDown);
            _homeButton.onClick.RemoveListener(OnHomeButtonDown);
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            TimeController.GetInstance().PauseTime();
            ShowUI.Invoke();

        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            TimeController.GetInstance().ResumeTime();
            HideUI.Invoke();
        }

        private void OnHomeButtonDown()
        {
            LevelController.GetInstance().QuitLevel();
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);
        }

        private void OnRestartButtonDown()
        {
            LevelController.GetInstance().RestartLevel();
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.GameMenu);
        }
    }
}
