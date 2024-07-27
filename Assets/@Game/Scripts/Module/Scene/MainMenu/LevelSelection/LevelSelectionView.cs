using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.LevelItem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionView : ObjectView<ILevelSelectionModel>
    {
        [ReadOnly] public SO_LevelCollection levelCollection;
        [ReadOnly] public List<GameObject> listedLevel;
        public Transform container;
        public GameObject template;

        private UnityAction<LevelItemView> onInitLevelItem;

        public void SetCallback(UnityAction<LevelItemView> onInitLevelItem)
        {
            this.onInitLevelItem = onInitLevelItem;
        }

        protected override void InitRenderModel(ILevelSelectionModel model)
        {
        }

        protected override void UpdateRenderModel(ILevelSelectionModel model)
        {
            if (model.LevelCollection == null)
                return;

            levelCollection = model.LevelCollection;

            if (listedLevel.Count < model.LevelCollection.levelItems.Count)
            {
                for (global::System.Int32 i = listedLevel.Count; i < model.LevelCollection.levelItems.Count; i++)
                {
                    GameObject obj = Instantiate(template, container);
                    obj.SetActive(true);
                    listedLevel.Add(obj);
                }
            }

            for (global::System.Int32 i = 0; i < listedLevel.Count; i++)
            {
                listedLevel[i].GetComponent<LevelItemView>().levelData = model.LevelCollection.levelItems[i].levelData;
                listedLevel[i].GetComponent<LevelItemView>().title.SetText(model.LevelCollection.levelItems[i].name);
                listedLevel[i].GetComponent<LevelItemView>().cost.SetText(model.LevelCollection.levelItems[i].cost.ToString());
                onInitLevelItem?.Invoke(listedLevel[i].GetComponent<LevelItemView>());
            }
        }
    }
}