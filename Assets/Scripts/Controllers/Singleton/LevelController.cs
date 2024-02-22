using Helpers.Singleton;
using Data;
using UnityEngine;
using Behaviours;

namespace Controllers
{
    class LevelController : PersistanceSingleton<LevelController>
    {
        private Level _currentLevel;
        private LevelData _currentLevelData;
        private EndLevelRules _endLevel;
        private GameScore _gameScore;

        private void Awake()
        {
            _endLevel = new EndLevelRules();
            _gameScore = new GameScore();
        }
        public void LoadLevel(LevelsBundle levelsBundle)
        {
            var levelData = levelsBundle.GetCurrentLevelData();
            _currentLevel = Instantiate(levelData.GetPrefab(), levelData.GetLevelPosition(), Quaternion.identity);
            Helpers.Services.Services.Instance.LevelService.SetObject(_currentLevel);
        }
        public void LoadLevel(LevelData levelData)
        {
            _currentLevelData = levelData;
            _currentLevel = Instantiate(levelData.GetPrefab(), levelData.GetLevelPosition(), Quaternion.identity);
            Helpers.Services.Services.Instance.LevelService.SetObject(_currentLevel);
            Debug.Log($"{_currentLevel} Loaded");
        }
        public void RestartLevel()
        {
            ClearLevel();
            LoadLevel(_currentLevelData);
        }
        public void QuitLevel()
        {
            Helpers.Observer.SnakeEvent.Trigger(true);
            ClearLevel();
        }
        private void ClearLevel()
        {
            _currentLevel.DeleteLevelObjects();
            Destroy(_currentLevel.gameObject);
            _currentLevel = null;
        }
        private void OnApplicationQuit()
        {
            _gameScore.UpdateSavingScore();
        }
    }
}
