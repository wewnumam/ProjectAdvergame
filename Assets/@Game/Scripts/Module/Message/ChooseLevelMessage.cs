using ProjectAdvergame.Module.LevelData;

namespace ProjectAdvergame.Message
{
    public struct ChooseLevelMessage
    {
        public string LevelName { get; }

        public ChooseLevelMessage(string levelName) 
        { 
            LevelName = levelName;
        }
    }
}