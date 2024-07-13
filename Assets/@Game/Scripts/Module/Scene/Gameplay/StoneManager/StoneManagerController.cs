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
        public override void SetView(StoneManagerView view)
        {
            base.SetView(view);

            SwitchCamera(view.levelData.beatCollections[0].direction);

            EnumManager.Direction currentDirection;
            List<StoneView> stones = new List<StoneView>();

            int currentBeatCollectionIndex = 0;
            int currentBeatIndex = 1;
            float currentTotalInterval = 0;

            foreach (var beatCollection in view.levelData.beatCollections)
            {
                currentDirection = beatCollection.direction;

                foreach (var beat in beatCollection.beats)
                {
                    currentTotalInterval += beat.interval;

                    Vector3 position = currentDirection == EnumManager.Direction.FromEast
                        ? new Vector3(currentTotalInterval, 0, currentBeatIndex)
                        : new Vector3(-currentTotalInterval, 0, currentBeatIndex);

                    StoneView previousStone = currentBeatIndex > 1 ? stones[currentBeatIndex - 2] : null;

                    StoneView stone = view.SpawnStone(beat.prefab, position, currentTotalInterval, currentBeatIndex, previousStone);
                    StoneController instance = new StoneController();
                    InjectDependencies(instance);
                    instance.Init(stone);

                    stones.Add(stone);

                    currentBeatIndex++;

                    if (IsEndOfBeatCollection(currentBeatCollectionIndex, currentBeatIndex, beatCollection))
                    {
                        stone.direction = view.levelData.beatCollections[currentBeatCollectionIndex + 1].direction;
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

        internal void StartPlay(StartPlayMessage message)
        {
            foreach (var stone in _view.stones)
            {
                stone.Play();
            }
        }

        private bool IsEndOfBeatCollection(int currentBeatCollectionIndex, int currentBeatIndex, BeatCollection beatCollection)
        {
            return currentBeatCollectionIndex < _view.levelData.beatCollections.Count - 1 && currentBeatIndex == beatCollection.beats.Count;
        }

        private void SwitchCamera(EnumManager.Direction direction)
        {
            Publish(new SwitchCameraMessage(direction));
        }
    }
}
