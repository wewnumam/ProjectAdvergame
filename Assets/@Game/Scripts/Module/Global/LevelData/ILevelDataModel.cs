using Agate.MVC.Base;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    public interface ILevelDataModel : IBaseModel
    {
        SO_LevelData CurrentLevelData { get; }
        SO_LevelCollection LevelCollection { get; }

        Sprite CurrentArtwork { get; }
        GameObject CurrentStonePrefab { get; }
        GameObject CurrentEnvironmentPrefab { get; }
        AudioClip CurrentMusicClip { get; }
        Material CurrentSkybox { get; }
    }
}