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

        public GameObject defaultStonePrefab;
        public GameObject addHealthPrefab;
        public Material successMaterial;
        public Material failMaterial;

        private StoneView currentStone;

        public StoneView SpawnStone(List<GameObject> prefabs, Vector3 position, float duration, int index, EnumManager.StoneType type, StoneView previousStone, float zIndex)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            GameObject prefab = prefabs[randomIndex] == null ? defaultStonePrefab : prefabs[randomIndex];
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
            
            currentStone = obj.GetComponent<StoneView>();
            currentStone.duration = duration;
            currentStone.index = index;
            currentStone.zIndex = zIndex;
            currentStone.previousStone = previousStone;
            currentStone.stoneType = type;

            if (type == EnumManager.StoneType.AddHealth)
            {
                GameObject healthObj = Instantiate(addHealthPrefab, obj.transform);
                currentStone.onComplete += () => Destroy(healthObj);
            }

            stones.Add(currentStone);

            return currentStone;
        }
    }
}