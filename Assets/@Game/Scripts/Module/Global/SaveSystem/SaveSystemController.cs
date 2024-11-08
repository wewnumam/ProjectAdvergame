using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace ProjectAdvergame.Module.SaveSystem
{
    public class SaveSystemController : DataController<SaveSystemController, SaveSystemModel, ISaveSystemModel>
    {
        public override IEnumerator Initialize()
        {
            if (!PlayerPrefs.HasKey(TagManager.KEY_VERSION) || !PlayerPrefs.GetString(TagManager.KEY_VERSION).Equals(Application.version))
                DeleteSaveFile();

            PlayerPrefs.SetString(TagManager.KEY_VERSION, Application.version);
            _model.SetSaveData(LoadGame());

            yield return base.Initialize();
        }

        public void SaveGame(SaveData data)
        {
            string json = JsonUtility.ToJson(data, true);
            string path = Path.Combine(Application.persistentDataPath, TagManager.DEFAULT_SAVEFILENAME);

            _model.SetSaveData(data);

            File.WriteAllText(path, json);
            Debug.Log("Game saved to " + path);
        }

        public SaveData LoadGame()
        {
            string path = Path.Combine(Application.persistentDataPath, TagManager.DEFAULT_SAVEFILENAME);

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

        public bool DeleteSaveFile()
        {
            if (PlayerPrefs.HasKey(TagManager.KEY_REVIEW))
                PlayerPrefs.DeleteKey(TagManager.KEY_REVIEW);

            string path = Path.Combine(Application.persistentDataPath, TagManager.DEFAULT_SAVEFILENAME);

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    Debug.Log("Save file deleted successfully: " + path);
                    return true;
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Failed to delete save file: " + e.Message);
                    return false;
                }
            }
            else
            {
                Debug.Log("Save file not found, nothing to delete.");
                return false;
            }
        }

        public void SetCurrentLevelName(string levelName)
        {
            _model.SetCurrentLevelName(levelName);
            SaveGame(_model.SaveData);
        }

        public void SetCurrentCharacterName(string characterName)
        {
            _model.SetCurrentCharacterName(characterName);
            SaveGame(_model.SaveData);
        }

        internal void SaveHeartResult(GameResultHeartMessage message)
        {
            _model.AddHeart(message.HeartAmount);
            SaveGame(_model.SaveData);
        }

        internal void SaveStarResult(GameResultStarMessage message)
        {
            if (_model.IsNewStar(message.StarAmount))
            {
                _model.SetStarRecord(message.StarAmount);
                SaveGame(_model.SaveData);
            }
        }

        internal void SaveScoreResult(GameResultScoreMessage message)
        {
            if (_model.IsNewHighScore(message.Score))
            {
                _model.SetHighscore(message.Score);
                SaveGame(_model.SaveData);
            }

            _model.AddHistory(message.Score);
            SaveGame(_model.SaveData);
        }

        internal void UnlockLevel(UnlockLevelMessage message)
        {
            _model.SubtractHeart(message.LevelItem.cost);
            _model.AddStarRecord(message.LevelItem.name);
            SaveGame(_model.SaveData);
        }

        internal void UnlockCharacter(UnlockCharacterMessage message)
        {
            _model.SubtractHeart(message.CharacterData.cost);
            _model.AddUnlockedCharacter(message.CharacterData.name);
            SaveGame(_model.SaveData);
        }

        internal void DeleteSaveData(DeleteSaveDataMessage message)
        {
            DeleteSaveFile();
            _model.SetSaveData(LoadGame());
        }

        internal void FullStar(FullStarMessage message)
        {
            _model.FullStar();
            SaveGame(_model.SaveData);
        }

        internal void UpdateUsername(UpdateUsernameMessage message)
        {
            _model.SetCurrentUsername(message.Username);
            SaveGame(_model.SaveData);
        }
    }
}
