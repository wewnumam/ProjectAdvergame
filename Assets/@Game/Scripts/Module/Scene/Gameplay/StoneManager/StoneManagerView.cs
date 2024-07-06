using Agate.MVC.Base;
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

        public StoneView SpawnStone(GameObject prefab, Vector3 position, float duration, int index)
        {
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
            obj.GetComponent<StoneView>().duration = duration;
            obj.GetComponent<StoneView>().index = index;
            return obj.GetComponent<StoneView>();
        }
    }
}