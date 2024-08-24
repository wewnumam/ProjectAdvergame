using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ProjectAdvergame.Module.CharacterData
{
    [CreateAssetMenu(fileName = "CharacterData_", menuName = "ProjectAdvergame/CharacterData", order = 1)]
    public class SO_CharacterData : ScriptableObject
    {
        [Header("Display")]
        public string fullName;
        public AssetReferenceGameObject prefab;

        [Header("Price")]
        public int cost;
        public bool isUnlockByStar;
        [ShowIf(nameof(isUnlockByStar))] public int starAmount;
    }
}
