using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "ProjectAdvergame/LevelData", order = 1)]
    public class SO_LevelData : ScriptableObject
    {
        public List<BeatCollection> beatCollections;
        public GameObject environmentPrefab;
    }

    [System.Serializable]
    public class Beat
    {
        public float interval;
        [ShowAssetPreview(32, 32)]
        public GameObject prefab;
    }

    [System.Serializable]
    public class BeatCollection
    {
        public List<Beat> beats;
        public EnumManager.Direction direction;
    }
}
