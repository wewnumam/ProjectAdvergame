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
        public List<SO_LevelData> levelItems;
    }
}
