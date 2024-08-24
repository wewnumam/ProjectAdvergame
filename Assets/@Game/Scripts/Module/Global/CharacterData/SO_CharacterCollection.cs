using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.CharacterData
{
    [CreateAssetMenu(fileName = "CharacterCollection", menuName = "ProjectAdvergame/CharacterCollection", order = 3)]
    public class SO_CharacterCollection : ScriptableObject
    {
        public List<SO_CharacterData> characterItems;
    }
}
