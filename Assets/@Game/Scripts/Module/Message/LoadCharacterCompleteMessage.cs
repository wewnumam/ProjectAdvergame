using ProjectAdvergame.Module.CharacterData;
using UnityEngine;

namespace ProjectAdvergame.Message
{
    public struct LoadCharacterCompleteMessage
    {
        public string CharacterName { get; }
        public string CharacterFullName { get; }
        public GameObject CharacterPrefab { get; }
        public CharacterReactions CharacterReactions { get; }
        
        public LoadCharacterCompleteMessage(string characterName, string characterFullName, GameObject prefab, CharacterReactions characterReactions)
        {
            CharacterName = characterName;
            CharacterFullName = characterFullName;
            CharacterPrefab = prefab;
            CharacterReactions = characterReactions;
        }
    }
}