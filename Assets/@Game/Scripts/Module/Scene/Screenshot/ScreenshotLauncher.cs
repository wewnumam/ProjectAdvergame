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
using System.Collections.Generic;
using static TMPro.TMP_Dropdown;
using Dan.Main;
using System;
using UnityEngine.SocialPlatforms.Impl;

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

            _view.SetCallback(GoToMainMenu, () => StartCoroutine(TakeScreenshotAndShareUrl()), target => StartCoroutine(TakeScreenshotAndShare(target)), OnEditUsername);

            _view.starText.SetText(_saveSystem.Model.SaveData.GetTotalStarCount().ToString());
            _view.unlockedSongText.SetText($"{_saveSystem.Model.SaveData.UnlockedLevels.Count}/{_levelData.Model.LevelCollection.levelItems.Count}");

            int currentXP = _saveSystem.Model.SaveData.GetTotalXP();
            Badge currentBadge = _gameConstants.Model.GameConstants.GetCurrentBadge(currentXP);
            Badge nextBadge = _gameConstants.Model.GameConstants.GetNextBadge(currentBadge);

            _view.currentBadgeText.SetText(currentBadge.name);
            _view.nextBadgeText.SetText(nextBadge.name);
            _view.badgeScoreText.SetText($"{currentXP}/{nextBadge.amount}");
            _view.badgeSlider.maxValue = nextBadge.amount;
            _view.badgeSlider.value = currentXP;

            _view.favoriteSongs.ClearOptions();

            List<OptionData> options = new List<OptionData>();

            foreach (var levelItem in _levelData.Model.LevelCollection.levelItems)
                options.Add(new OptionData(levelItem.title, null));
            _view.favoriteSongs.AddOptions(options);

            _view.usernameText.SetText(_saveSystem.Model.SaveData.CurrentUsername);
            _view.dateText.SetText(DateTime.Now.ToString("dd MMM yyyy"));

            LeaderboardCreator.UploadNewEntry(_gameConstants.Model.GameConstants.publicKey, _saveSystem.Model.SaveData.CurrentUsername, currentXP, isComplete =>
            {
                Debug.Log($"Update Leaderboard: {isComplete}");

                LeaderboardCreator.GetEntryCount(_gameConstants.Model.GameConstants.publicKey, count =>
                {
                    LeaderboardCreator.GetPersonalEntry(_gameConstants.Model.GameConstants.publicKey, player =>
                    {
                        _view.rankText.SetText($"{player.Rank}/{count}");
                    });
                });
            });


            yield return null;
        }

        private void OnEditUsername(string text)
        {
            if (text == string.Empty)
                return;

            Publish(new UpdateUsernameMessage(text));
            LeaderboardCreator.UploadNewEntry(_gameConstants.Model.GameConstants.publicKey, text, _saveSystem.Model.SaveData.GetTotalXP(), isComplete => Debug.Log($"Update Leaderboard: {isComplete}"));
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
                .SetSubject("").SetText("Mainkan Langit Sore Rhythm Game sekarang dan buktikan kalau kamu bisa lebih baik! ??")
                .SetUrl("https://play.google.com/store/apps/details?id=com.feelablesoftware.langitsore")
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
                    .SetText("Mainkan Langit Sore Rhythm Game sekarang dan buktikan kalau kamu bisa lebih baik! ??")
                    .SetUrl("https://play.google.com/store/apps/details?id=com.feelablesoftware.langitsore")
                    .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                    .Share();
            
            _view.onEnd?.Invoke();
        }
    }
}
