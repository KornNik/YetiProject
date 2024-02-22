using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Helpers.Observer;

namespace GameUI
{
    class GameUI : BaseUI, IEventListener<CollectableEvent>, IEventListener<SnakeEvent>
    {
        [SerializeField] private Button _pauseGameButton;
        [SerializeField] private Button _settingsGameButton;
        [SerializeField] private TextMeshProUGUI _yetisScoreText;
        [SerializeField] private Transform _gameArea;

        private int _score;

        private void OnEnable()
        {
            this.EventStartListening<CollectableEvent>();
            this.EventStartListening<SnakeEvent>();
            _pauseGameButton.onClick.AddListener(OnPauseButtonDown);
            _settingsGameButton.onClick.AddListener(OnSettingsButtonDown);
        }

        private void OnDisable()
        {
            this.EventStopListening<CollectableEvent>();
            this.EventStopListening<SnakeEvent>();
            _pauseGameButton.onClick.RemoveListener(OnPauseButtonDown);
            _settingsGameButton.onClick.RemoveListener(OnSettingsButtonDown);
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
        public void UpdateScore(int score)
        {
            _score += score;
            _yetisScoreText.text = _score.ToString();
        }
        private void OnPauseButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.PauseMenu);
        }
        private void OnSettingsButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.SettingsMenu);
        }

        public void OnEventTrigger(CollectableEvent eventType)
        {
            UpdateScore(eventType.Score);
        }

        public void OnEventTrigger(SnakeEvent eventType)
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.EndGameMenu);
        }
    }
}