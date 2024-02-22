using UnityEngine;
using UnityEngine.UI;
using Controllers;

namespace GameUI
{
    class PauseMenu : BaseUI
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private LayoutGroup _buttonsGroup;


        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonDown);
            _homeButton.onClick.AddListener(OnHomeButtonDown);
        }
        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnResumeButtonDown);
            _homeButton.onClick.RemoveListener(OnHomeButtonDown);

        }

        private void OnResumeButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.GameMenu);
        }

        private void OnHomeButtonDown()
        {
            LevelController.GetInstance().QuitLevel();
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);
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
    }
}
