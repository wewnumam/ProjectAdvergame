using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.Stone;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerView : BaseView
    {
        [ReadOnly] public List<StoneView> stones;

        private StoneView currentStone;

        public StoneView SpawnStone(GameObject prefab, Vector3 position, float duration, int index, StoneView previousStone)
        {
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
            
            currentStone = obj.GetComponent<StoneView>();
            currentStone.duration = duration;
            currentStone.index = index;
            currentStone.previousStone = previousStone;

            stones.Add(currentStone);

            return currentStone;
        }
    }
}