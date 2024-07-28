using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.LevelItem;
using System.Collections.Generic;
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
            view.SetCallback(OnInitLevelItem);
            _model.UpdateRender();
        }

        private void OnInitLevelItem(LevelItemView levelItemView)
        {
            LevelItemController instance = new LevelItemController();
            InjectDependencies(instance);
            instance.Init(levelItemView);
        }
    }
}