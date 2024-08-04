using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerController : ObjectController<StoneManagerController, StoneManagerView>
    {
        private List<Beat> _beats;
        
        public void SetBeatCollections(List<Beat> beats)
        {
            _beats = beats;
        }

        public override void SetView(StoneManagerView view)
        {
            base.SetView(view);

            List<StoneView> stones = new List<StoneView>();

            int currentBeatIndex = 1;

            foreach (var beat in _beats)
            {
                Vector3 position = beat.direction == EnumManager.Direction.FromEast
                    ? new Vector3(beat.interval, 0, currentBeatIndex)
                    : new Vector3(-beat.interval, 0, currentBeatIndex);

                StoneView previousStone = currentBeatIndex > 1 ? stones[currentBeatIndex - 2] : null;

                StoneView stone = view.SpawnStone(beat.prefab, position, beat.interval, currentBeatIndex, beat.type, previousStone);
                StoneController instance = new StoneController();
                InjectDependencies(instance);
                instance.Init(stone);

                stones.Add(stone);

                if (currentBeatIndex > 1 && currentBeatIndex < _beats.Count)
                {
                    stone.direction = beat.direction;

                    if (_beats[currentBeatIndex - 1].direction != _beats[currentBeatIndex].direction)
                    {
                        stone.direction = _beats[currentBeatIndex].direction;
                        stone.isSwitchCamera = true;
                        stone.SwitchCamera(SwitchCamera);
                    }
                }

                currentBeatIndex++;

            }

        }

        internal void OnPause(GameOverMessage message)
        {
            foreach (var stone in _view.stones)
            {
                stone.Pause();
            }
        }

        internal void OnReady(OnReadyMessage message)
        {
            SwitchCamera(_beats[0].direction);
        }

        internal void StartPlay(StartPlayMessage message)
        {

            foreach (var stone in _view.stones)
            {
                stone.Play();
            }
        }

        private void SwitchCamera(EnumManager.Direction direction)
        {
            Publish(new SwitchCameraMessage(direction));
        }
    }
}
