using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using UnityEngine;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerController : ObjectController<StoneManagerController, StoneManagerView>
    {
        private EnumManager.Direction currentDirection;

        public override void SetView(StoneManagerView view)
        {
            base.SetView(view);

            SwitchCamera(view.levelData.beatCollections[0].direction);

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

                    StoneView stone = view.SpawnStone(beat.prefab, position, currentTotalInterval, currentBeatIndex);

                    currentBeatIndex++;

                    if (IsEndOfBeatCollection(currentBeatCollectionIndex, currentBeatIndex, beatCollection))
                    {
                        stone.direction = view.levelData.beatCollections[currentBeatCollectionIndex + 1].direction;
                        stone.SetCallback(SwitchCamera);
                    }
                    else
                    {
                        stone.direction = currentDirection;
                    }
                }

                currentBeatCollectionIndex++;
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
