using System;
using Helpers;

namespace GameUI
{
    sealed class ScreenInterface : IDisposable
    {
        private BaseUI _currentWindow;
        private readonly ScreenFactory _screenFactory;
        private static ScreenInterface _instance;

        private ScreenInterface()
        {
            _screenFactory = new ScreenFactory();
        }

        public BaseUI CurrentWindow => _currentWindow;

        public static ScreenInterface GetInstance()
        {
            return _instance ?? (_instance = new ScreenInterface());
        }

        public void Execute(ScreenTypes screenType)
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.Hide();
            }

            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _currentWindow = _screenFactory.GetGameMenu();
                    break;
                case ScreenTypes.MainMenu:
                    _currentWindow = _screenFactory.GetMainMenu();
                    break;
                case ScreenTypes.PauseMenu:
                    _currentWindow = _screenFactory.GetPauseMenu();
                    break;
                case ScreenTypes.LevelsMenu:
                    _currentWindow = _screenFactory.GetLevelsMenu();
                    break;
                case ScreenTypes.LeaderboardsMenu:
                    _currentWindow = _screenFactory.GetLeaderboardMenu();
                    break;
                case ScreenTypes.SettingsMenu:
                    _currentWindow = _screenFactory.GetSettingsMenu();
                    break;
                case ScreenTypes.EndGameMenu:
                    _currentWindow = _screenFactory.GetEndGameMenu();
                    break;
                default:
                    break;
            }

            CurrentWindow.Show();
        }

        public void AddObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.PauseMenu:
                    _screenFactory.GetPauseMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetPauseMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetPauseMenu().Hide();
                    break;
                case ScreenTypes.LevelsMenu:
                    _screenFactory.GetLevelsMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetLevelsMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetLevelsMenu().Hide();
                    break;
                case ScreenTypes.LeaderboardsMenu:
                    _screenFactory.GetLeaderboardMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetLeaderboardMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetLeaderboardMenu().Hide();
                    break;
                case ScreenTypes.EndGameMenu:
                    _screenFactory.GetEndGameMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetEndGameMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetEndGameMenu().Hide();
                    break;
                case ScreenTypes.SettingsMenu:
                    _screenFactory.GetSettingsMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetSettingsMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetSettingsMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void RemoveObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.PauseMenu:
                    _screenFactory.GetPauseMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetPauseMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetPauseMenu().Hide();
                    break;
                case ScreenTypes.LevelsMenu:
                    _screenFactory.GetLevelsMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetLevelsMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetLevelsMenu().Hide();
                    break;
                case ScreenTypes.LeaderboardsMenu:
                    _screenFactory.GetLeaderboardMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetLeaderboardMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetLeaderboardMenu().Hide();
                    break;
                case ScreenTypes.EndGameMenu:
                    _screenFactory.GetEndGameMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetEndGameMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetEndGameMenu().Hide();
                    break;
                case ScreenTypes.SettingsMenu:
                    _screenFactory.GetSettingsMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetSettingsMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetSettingsMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}
