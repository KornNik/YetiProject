using System.Collections.Generic;
using Helpers.Extensions;

namespace Helpers.AssetsPath
{
    sealed class ScreenAssetPath
    {
        public struct ScreenPath
        {
            public string Screen;
            public Dictionary<ScreenElementTypes, string> Elements;
        }

        public static readonly Dictionary<ScreenTypes, ScreenPath> Screens = new Dictionary<ScreenTypes, ScreenPath>
        {
            {
                ScreenTypes.Canvas,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_CANVAS_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.MainMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_MAIN_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.PauseMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_PAUSE_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.GameMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_GAME_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.LevelsMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_LEVELS_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.LeaderboardsMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_LEADERBOARD_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.EndGameMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_END_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.SettingsMenu,
                new ScreenPath
                {
                    Screen = StringBuilderExtender.CreateString
                    (ResourcesPathManager.SCREENS_UI_FOLDER,ResourcesPathManager.SCREEN_SETTINGS_MENU_NAME),
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
        };
    }
}