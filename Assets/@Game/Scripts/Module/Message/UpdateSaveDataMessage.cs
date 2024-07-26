using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct UpdateSaveDataMessage
    {
        public SaveData SaveData { get; }

        public UpdateSaveDataMessage(SaveData saveData) 
        { 
            SaveData = saveData;
        }
    }
}