using Agate.MVC.Base;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataController : DataController<LevelDataController, LevelDataModel, ILevelDataModel>
    {
        private SaveSystemController _saveSystemController;

        // Use a single dictionary to manage handles
        private readonly Dictionary<string, AsyncOperationHandle> _assetHandles = new Dictionary<string, AsyncOperationHandle>();

        public override IEnumerator Initialize()
        {
            SO_LevelCollection levelCollection = Resources.Load<SO_LevelCollection>(@"LevelCollection");
            _model.SetLevelCollection(levelCollection);

            yield return base.Initialize();
        }

        public IEnumerator SetCurrentLevel(string levelName)
        {
            SO_LevelData levelData = Resources.Load<SO_LevelData>(@"LevelData/" + levelName);
            _model.SetCurrentLevelData(levelData);
            _model.ResetStonePrefabs();

            yield return LoadAsset<Sprite>(levelData.artwork, sprite => _model.SetCurrentArtwork(sprite), "artwork");
            yield return LoadAsset<Material>(levelData.skybox, material => _model.SetCurrentSkybox(material), "skybox");
            yield return LoadAsset<GameObject>(levelData.environmentPrefab, gameObject => _model.SetCurrentEnvironmentPrefab(gameObject), "environment");
            for (int i = 0; i < levelData.stonePrefabs.Count; i++)
                yield return LoadAsset<GameObject>(levelData.stonePrefabs[i], gameObject => _model.AddCurrentStonePrefab(gameObject), $"stone-{i}");

            yield return LoadAsset<AudioClip>(levelData.musicClip, audioClip => _model.SetCurrentMusicClip(audioClip), "music");

            Publish(new LoadLevelCompleteMessage(levelName, _model.CurrentArtwork, _model.CurrentMusicClip, _model.CurrentSkybox));
        }

        private IEnumerator LoadAsset<T>(AssetReference assetReference, System.Action<T> onSuccess, string handleKey)
        {
            // Handle asset loading and validation
            if (_assetHandles.ContainsKey(handleKey))
            {
                assetReference.ReleaseAsset();
                _assetHandles.Remove(handleKey);
            }

            var handle = assetReference.LoadAssetAsync<T>();
            _assetHandles[handleKey] = handle;

            while (!handle.IsDone)
            {
                Publish(new LoadProgressMessage($"{_model.CurrentLevelData.title} {handleKey}", handle.PercentComplete, false));
                SplashScreen.Instance.LoadProgress($"{_model.CurrentLevelData.title} {handleKey}", handle.PercentComplete, false);
                yield return null;
            }
            
            Publish(new LoadProgressMessage(string.Empty, 0, true));
            SplashScreen.Instance.LoadProgress(string.Empty, 0, true);

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                onSuccess?.Invoke(handle.Result);
                Debug.Log($"{handleKey} installed successfully...");
            }
            else
            {
                Debug.LogError($"{handleKey} failed to install");
            }

        }

        internal void OnChooseLevel(ChooseLevelMessage message)
        {
            Debug.Log($"CHOOSE LEVEL: {message.LevelName}");
            GameMain.Instance.RunCoroutine(SetCurrentLevel(message.LevelName));
            _saveSystemController.SetCurrentLevelName(message.LevelName);
        }
    }
}
