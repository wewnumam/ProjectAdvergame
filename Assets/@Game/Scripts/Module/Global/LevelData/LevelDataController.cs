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

            Debug.Log("0");
            yield return LoadAsset<Sprite>(levelData.artwork, sprite => _model.SetCurrentArtwork(sprite), "artwork");
            Debug.Log("1");
            yield return LoadAsset<Material>(levelData.skybox, material => _model.SetCurrentSkybox(material), "skybox");
            Debug.Log("2");
            yield return LoadAsset<GameObject>(levelData.environmentPrefab, gameObject => _model.SetCurrentEnvironmentPrefab(gameObject), "environment");
            Debug.Log("3");
            yield return LoadAsset<GameObject>(levelData.stonePrefab, gameObject => _model.SetCurrentStonePrefab(gameObject), "stone");
            Debug.Log("4");
            yield return LoadAsset<AudioClip>(levelData.musicClip, audioClip => _model.SetCurrentMusicClip(audioClip), "music");
            Debug.Log("5");

            Publish(new LoadLevelCompleteMessage(levelName, _model.CurrentArtwork, _model.CurrentMusicClip, _model.CurrentSkybox));
        }

        private IEnumerator LoadAsset<T>(AssetReference assetReference, System.Action<T> onSuccess, string handleKey)
        {
            // Handle asset loading and validation
            if (_assetHandles.ContainsKey(handleKey))
            {
                Addressables.Release(_assetHandles[handleKey]);
                _assetHandles.Remove(handleKey);
            }

            var handle = assetReference.LoadAssetAsync<T>();
            _assetHandles[handleKey] = handle;
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                onSuccess?.Invoke(handle.Result);
            }

            // Release the handle if it is no longer needed
            Addressables.Release(handle);
            _assetHandles.Remove(handleKey);
        }

        internal void OnChooseLevel(ChooseLevelMessage message)
        {
            Debug.Log($"CHOOSE LEVEL: {message.LevelName}");
            GameMain.Instance.RunCoroutine(SetCurrentLevel(message.LevelName));
            _saveSystemController.SetCurrentLevelName(message.LevelName);
        }
    }
}
