using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "ProjectAdvergame/LevelData", order = 1)]
    public class SO_LevelData : ScriptableObject
    {
        [Header("Display")]
        public string title;
        public int cost;
        public Sprite artwork;
        public Color backgroundColor;

        [Header("Beat")]
        public List<BeatCollection> beatCollections;

        [Header("Environment")]
        public GameObject environmentPrefab;
        public AudioClip musicClip;
        public Material skybox;
    }

    [System.Serializable]
    public class Beat
    {
        public float interval;
        public EnumManager.StoneType type;
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
