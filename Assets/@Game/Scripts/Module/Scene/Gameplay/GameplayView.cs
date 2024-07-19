using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ProjectAdvergame.Module.PlayerCharacter;
using ProjectAdvergame.Module.StoneManager;
using ProjectAdvergame.Module.CameraManager;
using ProjectAdvergame.Module.BeatAccuracyEvaluator;
using ProjectAdvergame.Module.MusicPlayer;
using ProjectAdvergame.Module.Score;
using ProjectAdvergame.Module.Health;
using ProjectAdvergame.Module.GameOver;

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
        public GameOverView GameOverView;

        [SerializeField]
        private Button _button;

        public void SetButtonCallback(UnityAction callback)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(callback);
        }
    }
}
