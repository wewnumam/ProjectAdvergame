using ProjectAdvergame.Module.LevelData;

namespace ProjectAdvergame.Message
{
    public struct ChooseCharacterMessage
    {
        public string CharacterName { get; }

        public ChooseCharacterMessage(string characterName) 
        { 
            CharacterName = characterName;
        }
    }
}