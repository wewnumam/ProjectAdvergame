using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    [CreateAssetMenu(fileName = "LevelCollection", menuName = "ProjectAdvergame/LevelCollection", order = 2)]
    public class SO_LevelCollection : ScriptableObject
    {
        public List<LevelItem> levelItems;
    }

    [System.Serializable]
    public class LevelItem
    {
        public string name;
        public SO_LevelData levelData;
        public int cost;
    }
}
