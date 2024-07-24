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
        private List<BeatCollection> _beatCollections;
        
        public void SetBeatCollections(List<BeatCollection> beatCollections)
        {
            _beatCollections = beatCollections;
        }

        public override void SetView(StoneManagerView view)
        {
            base.SetView(view);

            EnumManager.Direction currentDirection;
            List<StoneView> stones = new List<StoneView>();

            int currentBeatCollectionIndex = 0;
            int currentBeatIndex = 1;
            float currentTotalInterval = 0;

            foreach (var beatCollection in _beatCollections)
            {
                currentDirection = beatCollection.direction;

                int localBeatIndex = 1;

                foreach (var beat in beatCollection.beats)
                {
                    currentTotalInterval += beat.interval;

                    Vector3 position = currentDirection == EnumManager.Direction.FromEast
                        ? new Vector3(currentTotalInterval, 0, currentBeatIndex)
                        : new Vector3(-currentTotalInterval, 0, currentBeatIndex);

                    StoneView previousStone = currentBeatIndex > 1 ? stones[currentBeatIndex - 2] : null;

                    StoneView stone = view.SpawnStone(beat.prefab, position, currentTotalInterval, currentBeatIndex, beat.type, previousStone);
                    StoneController instance = new StoneController();
                    InjectDependencies(instance);
                    instance.Init(stone);

                    stones.Add(stone);

                    currentBeatIndex++;

                    localBeatIndex++;

                    if (IsEndOfBeatCollection(currentBeatCollectionIndex, localBeatIndex, beatCollection))
                    {
                        stone.isSwitchCamera = true;
                        stone.direction = _beatCollections[currentBeatCollectionIndex + 1].direction;
                        stone.SwitchCamera(SwitchCamera);
                    }
                    else
                    {
                        stone.direction = currentDirection;
                    }
                }

                currentBeatCollectionIndex++;
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
            SwitchCamera(_beatCollections[0].direction);
        }

        internal void StartPlay(StartPlayMessage message)
        {

            foreach (var stone in _view.stones)
            {
                stone.Play();
            }
        }

        private bool IsEndOfBeatCollection(int currentBeatCollectionIndex, int currentBeatIndex, BeatCollection beatCollection)
        {
            return currentBeatCollectionIndex < _beatCollections.Count - 1 && currentBeatIndex == beatCollection.beats.Count;
        }

        private void SwitchCamera(EnumManager.Direction direction)
        {
            Publish(new SwitchCameraMessage(direction));
        }
    }
}
