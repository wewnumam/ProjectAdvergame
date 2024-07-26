using Agate.MVC.Base;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.SaveSystem
{
    public class SaveSystemModel : BaseModel, ISaveSystemModel
    {
        public SaveData SaveData { get; private set; }

        public void SetSaveData(SaveData saveData)
        {
            SaveData = saveData;
            SetDataAsDirty();
        }

        public void SetCurrentLevelName(string levelName)
        {
            SaveData.CurrentLevelName = levelName;
            SetDataAsDirty();
        }
    }
}