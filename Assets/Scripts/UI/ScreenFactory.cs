using UnityEngine;
using Helpers;
using Helpers.Extensions;
using Helpers.AssetsPath;
using Helpers.Services;

namespace GameUI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameUI _gameMenu;
        private MainMenuUI _mainMenu;
        private PauseMenu _pauseMenu;
        private LevelsUI _levelsMenu;
        private LeaderboardUI _leaderboardUI;
        private EndGameUI _endGameUI;
        private SettingsUI _settingsUI;


        public ScreenFactory()
        {
            if (ReferenceEquals(_canvas, null))
            {
                var gmCanvas = GameObject.Find(ResourcesPathManager.SCREEN_CANVAS_NAME);

                if (gmCanvas != null)
                {
                    var canvas = gmCanvas.GetComponent<Canvas>();
                    if (canvas != null)
                    {
                        _canvas = canvas;
                    }
                }
                else
                {
                    var resources = CustomResources.Load<Canvas>(ScreenAssetPath.Screens[ScreenTypes.Canvas].Screen);
                    _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);
                }
            }
            if (_canvas.worldCamera == null)
            {
                _canvas.worldCamera = Services.Instance.CameraService.GetUICamera();
            }
        }

        public GameUI GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var gameMenu = _canvas.GetComponentInChildren<GameUI>();
                if (gameMenu)
                {
                    _gameMenu = gameMenu;
                }
                else
                {
                    var resources = CustomResources.Load<GameUI>(ScreenAssetPath.Screens[ScreenTypes.GameMenu].Screen);
                    _gameMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _gameMenu;
        }

        public MainMenuUI GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var mainMenu = _canvas.GetComponentInChildren<MainMenuUI>();
                if (mainMenu)
                {
                    _mainMenu = mainMenu;
                }
                else
                {
                    var resources = CustomResources.Load<MainMenuUI>(ScreenAssetPath.Screens[ScreenTypes.MainMenu].Screen);
                    _mainMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _mainMenu;
        }
        public PauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                var pauseMenu = _canvas.GetComponentInChildren<PauseMenu>();
                if (pauseMenu)
                {
                    _pauseMenu = pauseMenu;
                }
                else
                {
                    var resources = CustomResources.Load<PauseMenu>(ScreenAssetPath.Screens[ScreenTypes.PauseMenu].Screen);
                    _pauseMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _pauseMenu;
        }
        public LevelsUI GetLevelsMenu()
        {
            if (_levelsMenu == null)
            {
                var levelsMenu = _canvas.GetComponentInChildren<LevelsUI>();
                if (levelsMenu)
                {
                    _levelsMenu = levelsMenu;
                }
                else
                {
                    var resources = CustomResources.Load<LevelsUI>(ScreenAssetPath.Screens[ScreenTypes.LevelsMenu].Screen);
                    _levelsMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _levelsMenu;
        }
        public LeaderboardUI GetLeaderboardMenu()
        {
            if (_leaderboardUI == null)
            {
                var leaderboardUI = _canvas.GetComponentInChildren<LeaderboardUI>();
                if (leaderboardUI)
                {
                    _leaderboardUI = leaderboardUI;
                }
                else
                {
                    var resources = CustomResources.Load<LeaderboardUI>(ScreenAssetPath.Screens[ScreenTypes.LeaderboardsMenu].Screen);
                    _leaderboardUI = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _leaderboardUI;
        }
        public EndGameUI GetEndGameMenu()
        {
            if (_endGameUI == null)
            {
                var endGameUI = _canvas.GetComponentInChildren<EndGameUI>();
                if (endGameUI)
                {
                    _endGameUI = endGameUI;
                }
                else
                {
                    var resources = CustomResources.Load<EndGameUI>(ScreenAssetPath.Screens[ScreenTypes.EndGameMenu].Screen);
                    _endGameUI = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _endGameUI;
        }
        public SettingsUI GetSettingsMenu()
        {
            if (_settingsUI == null)
            {
                var settingsUI = _canvas.GetComponentInChildren<SettingsUI>();
                if (settingsUI)
                {
                    _settingsUI = settingsUI;
                }
                else
                {
                    var resources = CustomResources.Load<SettingsUI>(ScreenAssetPath.Screens[ScreenTypes.SettingsMenu].Screen);
                    _settingsUI = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
                }
            }
            return _settingsUI;
        }
    }
}