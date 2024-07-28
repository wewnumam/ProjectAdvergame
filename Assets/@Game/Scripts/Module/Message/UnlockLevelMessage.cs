namespace ProjectAdvergame.Message
{
    public struct UnlockLevelMessage
    {
        public Module.LevelData.LevelItem LevelItem { get; }

        public UnlockLevelMessage(Module.LevelData.LevelItem levelItem)
        {
            LevelItem = levelItem;
        }
    }
}