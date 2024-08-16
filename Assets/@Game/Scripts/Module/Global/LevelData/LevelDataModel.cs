using Agate.MVC.Base;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataModel : BaseModel, ILevelDataModel
    {
        public SO_LevelData CurrentLevelData { get; private set; }
        public SO_LevelCollection LevelCollection { get; private set; }

        public Sprite CurrentArtwork { get; private set; }
        public GameObject CurrentStonePrefab { get; private set; }
        public GameObject CurrentEnvironmentPrefab { get; private set; }
        public AudioClip CurrentMusicClip { get; private set; }
        public Material CurrentSkybox { get; private set; }

        public void SetCurrentLevelData(SO_LevelData levelData)
        {
            CurrentLevelData = levelData;
            SetDataAsDirty();
        }

        public void SetLevelCollection(SO_LevelCollection levelCollection)
        {
            LevelCollection = levelCollection;
            SetDataAsDirty();
        }

        public void SetCurrentArtwork(Sprite currentArtwork)
        {
            CurrentArtwork = currentArtwork;
            SetDataAsDirty();
        }

        public void SetCurrentStonePrefab(GameObject currentStonePrefab)
        {
            CurrentStonePrefab = currentStonePrefab;
            SetDataAsDirty();
        }

        public void SetCurrentEnvironmentPrefab(GameObject currentEnvironmentPrefab)
        {
            CurrentEnvironmentPrefab = currentEnvironmentPrefab;
            SetDataAsDirty();
        }

        public void SetCurrentMusicClip(AudioClip currentMusicClip)
        {
            CurrentMusicClip = currentMusicClip;
            SetDataAsDirty();
        }

        public void SetCurrentSkybox(Material currentSkybox)
        {
            CurrentSkybox = currentSkybox;
            SetDataAsDirty();
        }
    }
}