using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    public interface ILevelDataModel : IBaseModel
    {
        SO_LevelData CurrentLevelData { get; }
        List<SO_LevelData> LevelCollection { get; }

        Sprite CurrentArtwork { get; }
        List<GameObject> CurrentStonePrefabs { get; }
        GameObject CurrentEnvironmentPrefab { get; }
        AudioClip CurrentMusicClip { get; }
        Material CurrentSkybox { get; }
    }
}