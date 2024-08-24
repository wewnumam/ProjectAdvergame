using Agate.MVC.Base;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ProjectAdvergame.Module.CharacterData
{
    public class CharacterDataController : DataController<CharacterDataController, CharacterDataModel, ICharacterDataModel>
    {
        private SaveSystemController _saveSystemController;

        // Use a single dictionary to manage handles
        private readonly Dictionary<string, AsyncOperationHandle> _assetHandles = new Dictionary<string, AsyncOperationHandle>();

        public override IEnumerator Initialize()
        {
            SO_CharacterCollection characterCollection = Resources.Load<SO_CharacterCollection>(@"CharacterCollection");
            _model.SetCharacterCollection(characterCollection);

            yield return base.Initialize();
        }

        public IEnumerator SetCurrentCharacter(string characterName)
        {
            SO_CharacterData characterData = Resources.Load<SO_CharacterData>(@"CharacterData/" + characterName);
            _model.SetCurrentCharacterData(characterData);

            yield return LoadAsset<GameObject>(characterData.prefab, obj => _model.SetCurrentPrefab(obj), "character");

            Publish(new LoadCharacterCompleteMessage(characterName));
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
                Publish(new LoadProgressMessage($"{_model.CurrentCharacterData.fullName} {handleKey}", handle.PercentComplete, false));
                SplashScreen.Instance.LoadProgress($"{_model.CurrentCharacterData.fullName} {handleKey}", handle.PercentComplete, false);
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

        internal void OnChooseCharacter(ChooseCharacterMessage message)
        {
            Debug.Log($"CHOOSE LEVEL: {message.CharacterName}");
            GameMain.Instance.RunCoroutine(SetCurrentCharacter(message.CharacterName));
            _saveSystemController.SetCurrentCharacterName(message.CharacterName);
        }
    }
}
