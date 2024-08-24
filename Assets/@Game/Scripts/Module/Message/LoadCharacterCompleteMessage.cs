using UnityEngine;

namespace ProjectAdvergame.Message
{
    public struct LoadCharacterCompleteMessage
    {
        public string CharacterName { get; }
        
        public LoadCharacterCompleteMessage(string characterName)
        {
            CharacterName = characterName;
        }
    }
}