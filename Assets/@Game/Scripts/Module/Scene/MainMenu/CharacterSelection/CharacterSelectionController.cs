using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.CharacterData;
using ProjectAdvergame.Module.CharacterItem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectAdvergame.Module.CharacterSelection
{
    public class CharacterSelectionController : ObjectController<CharacterSelectionController, CharacterSelectionModel, ICharacterSelectionModel, CharacterSelectionView>
    {
        public void SetCharacterCollection(SO_CharacterCollection characterCollection) => _model.SetCharacterCollection(characterCollection);
        public void SetUnlockedCharacters(List<string> unlockedCharacters) => _model.SetUnlockedCharacters(unlockedCharacters);
        public void SetCurrentHeartCount(int count) => _model.SetCurrentHeartCount(count);
        public void SetCurrentStarCount(int count) => _model.SetCurrentStarCount(count);

        public override void SetView(CharacterSelectionView view)
        {
            base.SetView(view);

            for (global::System.Int32 i = view.listedCharacter.Count; i < _model.CharacterCollection.characterItems.Count; i++)
            {
                GameObject obj = GameObject.Instantiate(view.template, view.container);
                obj.SetActive(true);

                CharacterItemView characterItemView = obj.GetComponent<CharacterItemView>();
                SO_CharacterData characterItem = _model.CharacterCollection.characterItems[i];

                view.listedCharacter.Add(characterItemView);

                characterItemView.characterData = characterItem;
                characterItemView.fullName.SetText(characterItem.fullName);
                characterItemView.cost.SetText($"{characterItem.cost}");
                
                string unlockedCharacter = _model.UnlockedCharacters.FirstOrDefault(r => r == characterItem.name);

                if (characterItem.isUnlockByStar)
                {
                    if (_model.CurrentStarCount >= characterItem.starAmount)
                    {
                        characterItemView.chooseButton.gameObject.SetActive(true);
                        characterItemView.unlockSlider.gameObject.SetActive(false);
                        if (unlockedCharacter == null)
                            Publish(new UnlockCharacterMessage(characterItem));
                    }
                    else
                    {
                        characterItemView.chooseButton.gameObject.SetActive(false);
                        characterItemView.unlockSlider.gameObject.SetActive(true);
                    }

                    characterItemView.unlockButton.gameObject.SetActive(false);
                    characterItemView.unlockSlider.maxValue = characterItem.starAmount;
                    characterItemView.unlockSlider.value = _model.CurrentStarCount;
                    characterItemView.starProgress.SetText($"{(int)((float)_model.CurrentStarCount / (float)characterItem.starAmount * 100f)}%");
                }
                else
                {
                    characterItemView.chooseButton.gameObject.SetActive(unlockedCharacter != null);
                    characterItemView.unlockButton.gameObject.SetActive(unlockedCharacter == null);
                    characterItemView.unlockButton.interactable = _model.CurrentHeartCount >= characterItem.cost;
                    characterItemView.unlockSlider.gameObject.SetActive(false);
                }

                CharacterItemModel levelItemModel = new CharacterItemModel();
                CharacterItemController levelItemController = new CharacterItemController();
                InjectDependencies(levelItemController);
                levelItemController.Init(levelItemModel, characterItemView);
                levelItemController.SetCurrentHeartCount(_model.CurrentHeartCount);
            }
        }

        internal void OnLoadCharacterComplete(LoadCharacterCompleteMessage message)
        {
            if (_model.CharacterCollection == null)
                return;

            // Find the level data
            SO_CharacterData characterData = _model.CharacterCollection.characterItems.FirstOrDefault(r => r.name == message.CharacterName);
            // Find the star records
            string unlockedCharacter = _model.UnlockedCharacters.FirstOrDefault(r => r == message.CharacterName);

            // Check for null references and handle appropriately
            if (characterData == null)
            {
                // Handle the case where levelData is null
                Debug.LogError($"Level data not found for level: {message.CharacterName}");
                return; // Exit the method or handle appropriately
            }

            if (unlockedCharacter == null)
            {
                // Handle the case where starRecords is null
                Debug.LogError($"Star records not found for level: {message.CharacterName}");
                return; // Exit the method or handle appropriately
            }

            // If both levelData and starRecords are not null, proceed to set current content
            _model.SetCurrentContent(message.CharacterName, message.CharacterFullName, message.CharacterPrefab);
        }


        internal void OnUnlockCharacter(UnlockCharacterMessage message)
        {
            _model.SubtractHeart(message.CharacterData.cost);

            _view.listedCharacter.ForEach(item => item.SubstractHeart(message.CharacterData.cost));
        }

        internal void OnLoadProgress(LoadProgressMessage message)
        {
            if (_view == null)
                return;

           _view.progressText.SetText($"Installing {message.Label} ({(int)(message.Percentage * 100)}%)");
           _view.progressPanel.SetActive(!message.IsDone);
        }
    }
}