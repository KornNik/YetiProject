using UnityEngine;
using UnityEngine.SceneManagement;
using Helpers.Singleton;
using System.Collections;

namespace Controllers
{
    class GameController : PersistanceSingleton<GameController>
    {
        private AsyncOperation _asyncOperation;
        private Coroutine _loadSceneCoroutine;
        private SettingsInitializer _settingsInitializer;

        private void Awake()
        {
            _settingsInitializer = new SettingsInitializer();
            GameUI.ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);

            _settingsInitializer.Initialization();
        }
        public void GoToScene(string sceneName)
        {
            if (ReferenceEquals(_loadSceneCoroutine, null))
            {
                _loadSceneCoroutine = StartCoroutine(LoadingScene(sceneName));
            }
        }
        public void RestartLevel()
        {
            var activeScene = SceneManager.GetActiveScene();
            if (ReferenceEquals(_loadSceneCoroutine, null))
            {
                _loadSceneCoroutine = StartCoroutine(LoadingScene(activeScene));
            }
        }
        public void QuitGame()
        {
            Application.Quit();
        }


        #region IEnumerators
        private IEnumerator LoadingScene(string sceneName)
        {
            yield return null;

            _asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            _asyncOperation.allowSceneActivation = false;

            while (!_asyncOperation.isDone)
            {
                var loadingProgress = _asyncOperation.progress;
                if (_asyncOperation.progress >= 0.9f)
                {
                    _asyncOperation.allowSceneActivation = true;
                }
            }

            _loadSceneCoroutine = null;

            yield return null;
        }
        private IEnumerator LoadingScene(Scene sceneType)
        {
            yield return null;

            _asyncOperation = SceneManager.LoadSceneAsync(sceneType.buildIndex);
            _asyncOperation.allowSceneActivation = false;

            while (!_asyncOperation.isDone)
            {
                var loadingProgress = _asyncOperation.progress;
                if (_asyncOperation.progress >= 0.9f)
                {
                    _asyncOperation.allowSceneActivation = true;
                }
            }

            _loadSceneCoroutine = null;

            yield return null;
        }

        #endregion


    }
}
