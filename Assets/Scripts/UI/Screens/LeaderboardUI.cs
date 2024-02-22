using UnityEngine;
using UnityEngine.UI;
using Helpers.Extensions;
using Helpers.Managers;

namespace GameUI
{
    class LeaderboardUI : BaseUI
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Transform _leaderboardParent;

        private BoardSlot[] _slots;

        protected override void Awake()
        {
            base.Awake();
            _slots = _leaderboardParent.GetComponentsInChildren<BoardSlot>();
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonDown);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonDown);
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            UpdateLeaderboardContent();
            ShowUI.Invoke();

        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
        private void OnBackButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);
        }
        private void UpdateLeaderboardContent()
        {
            var score = SaveFileExtender.LoadFile<int>(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.SCORE_KEY);
            var name  = SaveFileExtender.LoadFile<string>(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.PLAYER_NAME_KEY);
            string playerScore = StringBuilderExtender.CreateString(name, score.ToString());
            _slots[0].FillSlot(name, score.ToString());
        }
    }
}
