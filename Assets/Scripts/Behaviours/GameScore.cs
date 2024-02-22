using Helpers.Observer;
using Helpers.Extensions;
using Helpers.Managers;

namespace Behaviours
{
    class GameScore : IEventListener<SnakeEvent>,IEventListener<CollectableEvent>
    {
        private int _score;

        public int Score => _score;

        public GameScore()
        {
            this.EventStartListening<CollectableEvent>();
            this.EventStartListening<SnakeEvent>();
        }
        ~GameScore()
        {
            this.EventStopListening<CollectableEvent>();
            this.EventStopListening<SnakeEvent>();
        }
        public void UpdateSavingScore()
        {
            var storedScore = SaveFileExtender.LoadFile<int>(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.SCORE_KEY);
            if (storedScore < Score)
            {
                SaveFileExtender.SaveFileFresh(SaveFilesNames.MAIN_SAVE_FILE_NAME, SaveFilesNames.SCORE_KEY, Score);
            }
        }
        private void UpdateInGameScore(int value)
        {
            if (value > 0)
            {
                _score += value;
            }
        }
        private void ClearScore()
        {
            _score = 0;
        }
        public void OnEventTrigger(SnakeEvent eventType)
        {
            if (eventType.IsDead)
            {
                UpdateSavingScore();
                ClearScore();
            }
        }
        public void OnEventTrigger(CollectableEvent eventType)
        {
            UpdateInGameScore(eventType.Score);
        }
    }
}
