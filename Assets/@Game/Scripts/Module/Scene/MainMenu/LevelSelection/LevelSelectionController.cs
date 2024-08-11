using Agate.MVC.Base;
using Agate.MVC.Core;
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
        public void SetLevelCollection(SO_LevelCollection levelCollection) => _model.SetLevelCollection(levelCollection);
        public void SetUnlockedLevel(List<StarRecords> unlockedLevels) => _model.SetUnlockedLevel(unlockedLevels);
        public void SetCurrentHeartCount(int count) => _model.SetCurrentHeartCount(count);
        public void SetCurrentStarCount(int count) => _model.SetCurrentStarCount(count);
        public void SetCurrentContent(string levelName)
        {
            SO_LevelData levelData = _model.LevelCollection.levelItems.FirstOrDefault(r => r.name == levelName);
            StarRecords starRecords = _model.UnlockedLevels.FirstOrDefault(r => r.LevelName == levelName);
            _model.SetCurrentContent(levelData, starRecords);
        }

        public override void SetView(LevelSelectionView view)
        {
            base.SetView(view);

            for (global::System.Int32 i = view.listedLevel.Count; i < _model.LevelCollection.levelItems.Count; i++)
            {
                GameObject obj = GameObject.Instantiate(view.template, view.container);
                obj.SetActive(true);

                LevelItemView levelItemView = obj.GetComponent<LevelItemView>();
                SO_LevelData levelItem = _model.LevelCollection.levelItems[i];

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

        internal void OnChooseLevel(ChooseLevelMessage message)
        {
            SetCurrentContent(message.LevelName);
        }

        internal void OnUnlockLevel(UnlockLevelMessage message)
        {
            _model.SubtractHeart(message.LevelItem.cost);

            _view.listedLevel.ForEach(item => item.SubstractHeart(message.LevelItem.cost));
        }
    }
}