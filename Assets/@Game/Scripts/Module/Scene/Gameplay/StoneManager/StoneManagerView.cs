using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerView : BaseView
    {
        [ReadOnly] public List<StoneView> stones;

        public GameObject addHealthPrefab;

        private StoneView currentStone;

        public StoneView SpawnStone(GameObject prefab, Vector3 position, float duration, int index, EnumManager.StoneType type, StoneView previousStone)
        {
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
            
            currentStone = obj.GetComponent<StoneView>();
            currentStone.duration = duration;
            currentStone.index = index;
            currentStone.previousStone = previousStone;
            currentStone.stoneType = type;

            if (type == EnumManager.StoneType.AddHealth)
                Instantiate(addHealthPrefab, obj.transform);

            stones.Add(currentStone);

            return currentStone;
        }
    }
}