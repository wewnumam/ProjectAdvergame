using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ProjectAdvergame.Module.LevelData
{
    [CreateAssetMenu(fileName = "LevelCollection", menuName = "ProjectAdvergame/LevelCollection", order = 2)]
    public class SO_LevelCollection : ScriptableObject
    {
        public List<AssetReference> levelItems;
    }
}
