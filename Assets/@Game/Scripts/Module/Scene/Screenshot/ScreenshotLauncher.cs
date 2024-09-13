using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine.SceneManagement;
using ProjectAdvergame.Message;
using UnityEngine;
using ProjectAdvergame.Utility;
using System.IO;
using ProjectAdvergame.Module.SaveSystem;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.GameConstants;

namespace ProjectAdvergame.Scene.Screenshot
{
    public class ScreenshotLauncher : SceneLauncher<ScreenshotLauncher, ScreenshotView>
    {
        public override string SceneName { get { return TagManager.SCENE_SCREENSHOT; } }

        private SaveSystemController _saveSystem;
        private LevelDataController _levelData;
        private GameConstantsController _gameConstants;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            Time.timeScale = 1;

            Publish(new GameStateMessage(EnumManager.GameState.PreGame));

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            _view.SetButtonCallback(GoToMainMenu, () => StartCoroutine(TakeScreenshotAndShareUrl()), target => StartCoroutine(TakeScreenshotAndShare(target)));

            _view.starText.SetText(_saveSystem.Model.SaveData.GetTotalStarCount().ToString());
            _view.unlockedSongText.SetText($"{_saveSystem.Model.SaveData.UnlockedLevels.Count}/{_levelData.Model.LevelCollection.levelItems.Count}");

            yield return null;
        }

        private void GoToMainMenu()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }

        private IEnumerator TakeScreenshotAndShareUrl()
        {
            _view.onStart?.Invoke();

            yield return new WaitForEndOfFrame();

            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ss.Apply();

            string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
            File.WriteAllBytes(filePath, ss.EncodeToPNG());

            // To avoid memory leaks
            Destroy(ss);

            new NativeShare().AddFile(filePath)
                .SetSubject("Subject goes here").SetText("Hello world!").SetUrl("https://github.com/yasirkula/UnityNativeShare")
                .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                .Share();

            _view.onEnd?.Invoke();
        }

        private IEnumerator TakeScreenshotAndShare(string target)
        {
            _view.onStart?.Invoke();

            yield return new WaitForEndOfFrame();

            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ss.Apply();

            string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
            File.WriteAllBytes(filePath, ss.EncodeToPNG());

            // To avoid memory leaks
            Destroy(ss);

            if (NativeShare.TargetExists(target))
                new NativeShare().AddFile(filePath)
                    .AddTarget(target)
                    .SetTitle("Title")
                    .SetText("Hello world!")
                    .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                    .Share();
            
            _view.onEnd?.Invoke();
        }
    }
}
