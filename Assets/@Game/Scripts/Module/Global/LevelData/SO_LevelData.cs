using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ProjectAdvergame.Module.LevelData
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "ProjectAdvergame/LevelData", order = 1)]
    public class SO_LevelData : ScriptableObject
    {
        [Header("Display")]
        public string title;
        public AssetReferenceSprite artwork;
        public Color backgroundColor;

        [Header("Price")]
        public int cost;
        public bool isUnlockByStar;
        [ShowIf(nameof(isUnlockByStar))] public int starAmount;

        [Header("Beat")]
        public List<Beat> beats;

        [Header("Environment")]
        public AssetReferenceGameObject stonePrefab;
        public AssetReferenceGameObject environmentPrefab;
        public AssetReferenceAudioClip musicClip;
        public AssetReferenceMaterial skybox;
    }

    [System.Serializable]
    public class Beat
    {
        public float interval;
        [Foldout("Details")]
        public EnumManager.StoneType type;
        [Foldout("Details")]
        public EnumManager.Direction direction;
    }

    [System.Serializable]
    public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
    {
        public AssetReferenceAudioClip(string guid) : base(guid) { }
    }

    [System.Serializable]
    public class AssetReferenceMaterial : AssetReferenceT<Material>
    {
        public AssetReferenceMaterial(string guid) : base(guid) { }
    }
}
