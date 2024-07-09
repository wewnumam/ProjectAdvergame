using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerView : BaseView
    {
        public SO_LevelData levelData;
        public List<StoneView> stones;

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