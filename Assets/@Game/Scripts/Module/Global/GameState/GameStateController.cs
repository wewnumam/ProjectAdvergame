using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Module.GameState
{
    public class GameStateController : DataController<GameStateController, GameStateModel, IGameStateModel>
    {
        public bool IsStatePreGame() => _model.GameState == EnumManager.GameState.PreGame;
        public bool IsStatePlaying() => _model.GameState == EnumManager.GameState.Playing;
        public bool IsStatePause() => _model.GameState == EnumManager.GameState.Pause;
        public bool IsStateGameOver() => _model.GameState == EnumManager.GameState.GameOver;
        public bool IsStateGameWin() => _model.GameState == EnumManager.GameState.GameWin;
        
        public override IEnumerator Initialize()
        {
            _model.SetGameState(EnumManager.GameState.PreGame);
            Debug.Log($"STATE: {EnumManager.GameState.PreGame}");

            return base.Initialize();
        }

        internal void SetGameState(GameStateMessage message)
        {
            _model.SetGameState(message.GameState);
            Debug.Log($"STATE: {message.GameState}");
        }
    }
}
