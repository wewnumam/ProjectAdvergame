using ProjectAdvergame.Module.CharacterData;

namespace ProjectAdvergame.Message
{
    public struct UnlockCharacterMessage
    {
        public SO_CharacterData CharacterData { get; }

        public UnlockCharacterMessage(SO_CharacterData characterData)
        {
            CharacterData = characterData;
        }
    }
}