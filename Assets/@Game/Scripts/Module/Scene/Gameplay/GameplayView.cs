using Agate.MVC.Base;
using ProjectAdvergame.Module.PlayerCharacter;
using ProjectAdvergame.Module.StoneManager;
using ProjectAdvergame.Module.CameraManager;
using ProjectAdvergame.Module.BeatAccuracyEvaluator;
using ProjectAdvergame.Module.MusicPlayer;
using ProjectAdvergame.Module.Score;
using ProjectAdvergame.Module.Health;
using ProjectAdvergame.Module.GameOver;
using ProjectAdvergame.Module.GameWin;
using ProjectAdvergame.Module.OnReady;
using ProjectAdvergame.Module.GamePause;
using ProjectAdvergame.Module.Settings;
using UnityEngine;

namespace ProjectAdvergame.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public PlayerCharacterView PlayerCharacterView;
        public StoneManagerView StoneManagerView;
        public CameraManagerView CameraManagerView;
        public BeatAccuracyEvaluatorView BeatAccuracyEvaluatorView;
        public MusicPlayerView MusicPlayerView;
        public ScoreView ScoreView;
        public HealthView HealthView;
        public GamePauseView GamePauseView;
        public GameOverView GameOverView;
        public GameWinView GameWinView;
        public OnReadyView OnReadyView;
        public SettingsView SettingsView;

        public GameObject defaultStonePrefab;
    }
}
