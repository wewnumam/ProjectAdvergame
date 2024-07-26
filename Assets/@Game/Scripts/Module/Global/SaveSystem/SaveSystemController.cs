using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System.Collections;
using System.IO;
using UnityEngine;

namespace ProjectAdvergame.Module.SaveSystem
{
    public class SaveSystemController : DataController<SaveSystemController, SaveSystemModel, ISaveSystemModel>
    {
        public override IEnumerator Initialize()
        {
            _model.SetSaveData(LoadGame());

            yield return base.Initialize();
        }

        public void SaveGame(SaveData data)
        {
            string json = JsonUtility.ToJson(data, true);
            string path = Path.Combine(Application.persistentDataPath, $"{nameof(SaveData)}.json");

            _model.SetSaveData(data);

            File.WriteAllText(path, json);
            Debug.Log("Game saved to " + path);
        }

        public SaveData LoadGame()
        {
            string path = Path.Combine(Application.persistentDataPath, $"{nameof(SaveData)}.json");

            if (!File.Exists(path))
            {
                Debug.LogWarning("Save file not found. Creating a new one.");
                SaveData saveData = new SaveData();
                SaveGame(saveData);
                return saveData;
            }

            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game loaded from " + path);
            return data;
        }

        public void SetCurrentLevelName(string levelName) => _model.SetCurrentLevelName(levelName);
    }
}
