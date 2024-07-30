using ProjectAdvergame.Module.LevelData;

namespace ProjectAdvergame.Message
{
    public struct UnlockLevelMessage
    {
        public SO_LevelData LevelItem { get; }

        public UnlockLevelMessage(SO_LevelData levelItem)
        {
            LevelItem = levelItem;
        }
    }
}