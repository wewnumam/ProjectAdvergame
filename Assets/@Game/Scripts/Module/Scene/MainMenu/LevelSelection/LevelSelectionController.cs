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

        public override void SetView(LevelSelectionView view)
        {
            base.SetView(view);

            for (global::System.Int32 i = view.listedLevel.Count; i < _model.LevelCollection.levelItems.Count; i++)
            {
                GameObject obj = GameObject.Instantiate(view.template, view.container);
                obj.SetActive(true);

                LevelItemView levelItemView = obj.GetComponent<LevelItemView>();
                LevelData.LevelItem levelItem = _model.LevelCollection.levelItems[i];

                view.listedLevel.Add(levelItemView);

                levelItemView.levelItem = levelItem;
                levelItemView.levelData = levelItem.levelData;
                levelItemView.title.SetText(levelItem.name);
                levelItemView.cost.SetText($"{levelItem.cost}");

                StarRecords starRecords = _model.UnlockedLevels.FirstOrDefault(r => r.LevelName == levelItem.levelData.name);
                levelItemView.chooseButton.gameObject.SetActive(starRecords != null);
                levelItemView.unlockButton.gameObject.SetActive(starRecords == null);
                levelItemView.unlockButton.interactable = _model.CurrentHeartCount >= levelItem.cost;

                LevelItemModel levelItemModel = new LevelItemModel();
                LevelItemController levelItemController = new LevelItemController();
                InjectDependencies(levelItemController);
                levelItemController.Init(levelItemModel, levelItemView);
                levelItemController.SetCurrentHeartCount(_model.CurrentHeartCount);
            }
        }

        internal void OnUnlockLevel(UnlockLevelMessage message)
        {
            _model.SubtractHeart(message.LevelItem.cost);

            _view.listedLevel.ForEach(item => item.SubstractHeart(message.LevelItem.cost));
        }
    }
}