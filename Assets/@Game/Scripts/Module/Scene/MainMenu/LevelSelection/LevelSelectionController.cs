using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.LevelItem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionController : ObjectController<LevelSelectionController, LevelSelectionModel, ILevelSelectionModel, LevelSelectionView>
    {
        public void SetLevelCollection(List<SO_LevelData> levelCollection) => _model.SetLevelCollection(levelCollection);
        public void SetUnlockedLevel(List<StarRecords> unlockedLevels) => _model.SetUnlockedLevel(unlockedLevels);
        public void SetCurrentHeartCount(int count) => _model.SetCurrentHeartCount(count);
        public void SetCurrentStarCount(int count) => _model.SetCurrentStarCount(count);

        public override void SetView(LevelSelectionView view)
        {
            base.SetView(view);

            for (global::System.Int32 i = view.listedLevel.Count; i < _model.LevelCollection.Count; i++)
            {
                GameObject obj = GameObject.Instantiate(view.template, view.container);
                obj.SetActive(true);

                LevelItemView levelItemView = obj.GetComponent<LevelItemView>();
                SO_LevelData levelItem = _model.LevelCollection[i];

                view.listedLevel.Add(levelItemView);

                levelItemView.levelData = levelItem;
                levelItemView.title.SetText(levelItem.title);
                levelItemView.cost.SetText($"{levelItem.cost}");

                
                
                StarRecords starRecords = _model.UnlockedLevels.FirstOrDefault(r => r.LevelName == levelItem.name);

                if (levelItem.isUnlockByStar)
                {
                    if (_model.CurrentStarCount >= levelItem.starAmount)
                    {
                        levelItemView.chooseButton.gameObject.SetActive(true);
                        levelItemView.unlockSlider.gameObject.SetActive(false);
                        if (starRecords == null)
                            Publish(new UnlockLevelMessage(levelItem));
                    }
                    else
                    {
                        levelItemView.chooseButton.gameObject.SetActive(false);
                        levelItemView.unlockSlider.gameObject.SetActive(true);
                    }

                    levelItemView.unlockButton.gameObject.SetActive(false);
                    levelItemView.unlockSlider.maxValue = levelItem.starAmount;
                    levelItemView.unlockSlider.value = _model.CurrentStarCount;
                    levelItemView.starProgress.SetText($"{(int)((float)_model.CurrentStarCount / (float)levelItem.starAmount * 100f)}%");
                }
                else
                {
                    levelItemView.chooseButton.gameObject.SetActive(starRecords != null);
                    levelItemView.unlockButton.gameObject.SetActive(starRecords == null);
                    levelItemView.unlockButton.interactable = _model.CurrentHeartCount >= levelItem.cost;
                    levelItemView.unlockSlider.gameObject.SetActive(false);
                }

                LevelItemModel levelItemModel = new LevelItemModel();
                LevelItemController levelItemController = new LevelItemController();
                InjectDependencies(levelItemController);
                levelItemController.Init(levelItemModel, levelItemView);
                levelItemController.SetCurrentHeartCount(_model.CurrentHeartCount);
            }
        }

        internal void OnLoadLevelComplete(LoadLevelCompleteMessage message)
        {
            if (_model.LevelCollection == null)
                return;

            // Find the level data
            SO_LevelData levelData = _model.LevelCollection.FirstOrDefault(r => r.name == message.LevelName);
            // Find the star records
            StarRecords starRecords = _model.UnlockedLevels.FirstOrDefault(r => r.LevelName == message.LevelName);

            // Check for null references and handle appropriately
            if (levelData == null)
            {
                // Handle the case where levelData is null
                Debug.LogError($"Level data not found for level: {message.LevelName}");
                return; // Exit the method or handle appropriately
            }

            if (starRecords == null)
            {
                // Handle the case where starRecords is null
                Debug.LogError($"Star records not found for level: {message.LevelName}");
                return; // Exit the method or handle appropriately
            }

            // If both levelData and starRecords are not null, proceed to set current content
            _model.SetCurrentContent(levelData, starRecords, message.Artwork, message.MusicClip, message.Skybox);
        }


        internal void OnUnlockLevel(UnlockLevelMessage message)
        {
            _model.SubtractHeart(message.LevelItem.cost);

            _view.listedLevel.ForEach(item => item.SubstractHeart(message.LevelItem.cost));
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