using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Helpers.Extensions;
using Helpers.Managers;

namespace GameUI
{
    class MainMenuUI : BaseUI
    {
        [SerializeField] private Button _levelsButton;
        [SerializeField] private Button _challengeButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _privacyButton;
        [SerializeField] private LayoutGroup _buttonsGroup;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void OnEnable()
        {
            _levelsButton.onClick.AddListener(OnLevelsButtonDown);
            _challengeButton.onClick.AddListener(OnChallengeButtonDown);
            _leaderboardButton.onClick.AddListener(OnLeaderboardButtonDown);
            _settingsButton.onClick.AddListener(OnSettingsButtonDown);
            _privacyButton.onClick.AddListener(OnPrivacyButtonDown);
        }

        private void OnDisable()
        {
            _levelsButton.onClick.RemoveListener(OnLevelsButtonDown);
            _challengeButton.onClick.RemoveListener(OnChallengeButtonDown);
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonDown);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonDown);
            _privacyButton.onClick.RemoveListener(OnPrivacyButtonDown);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            UpdateScore();
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void UpdateScore()
        {
            var storedScore = SaveFileExtender.LoadFile<int>(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.SCORE_KEY);
            _scoreText.text = storedScore.ToString();
        }

        private void OnPrivacyButtonDown()
        {

        }

        private void OnSettingsButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.SettingsMenu);
        }

        private void OnLeaderboardButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.LeaderboardsMenu);
        }

        private void OnChallengeButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.GameMenu);
        }

        private void OnLevelsButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.LevelsMenu);
        }
    }
}