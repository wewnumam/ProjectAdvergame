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
        public Sprite artwork;
        public Color backgroundColor;

        [Header("Price")]
        public int cost;
        public bool isUnlockByStar;
        [ShowIf(nameof(isUnlockByStar))] public int starAmount;

        [Header("Beat")]
        public List<Beat> beats;

        [Header("Environment")]
        public GameObject environmentPrefab;
        public AudioClip musicClip;
        public Material skybox;
    }

    [System.Serializable]
    public class Beat
    {
        public float interval;
        [Foldout("Details")]
        public EnumManager.StoneType type;
        [Foldout("Details")]
        public EnumManager.Direction direction;
        [Foldout("Details"), ShowAssetPreview(32, 32)]
        public GameObject prefab;
    }
}
