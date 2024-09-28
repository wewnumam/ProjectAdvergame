using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerController : ObjectController<StoneManagerController, StoneManagerView>
    {
        private List<Beat> _beats;
        private List<GameObject> _stonePrefabs;

        public void SetBeatCollections(List<Beat> beats)
        {
            _beats = beats;
        }

        public void SetStonePrefab(List<GameObject> stonePrefabs)
        {
            _stonePrefabs = stonePrefabs;
        }

        public override void SetView(StoneManagerView view)
        {
            base.SetView(view);

            List<StoneView> stones = new List<StoneView>();
            List<float> zPosCollection = new List<float>();

            int currentBeatIndex = 1;
            float zIndex = 0;

            foreach (var beat in _beats)
            {
                StoneView previousStone = currentBeatIndex > 1 ? stones[currentBeatIndex - 2] : null;
                
                Vector3 position = beat.direction == EnumManager.Direction.FromEast
                    ? new Vector3(beat.interval*3, 0, zIndex + currentBeatIndex)
                    : new Vector3(-beat.interval*3, 0, zIndex + currentBeatIndex);

                zPosCollection.Add(position.z);

                StoneView stone = view.SpawnStone(_stonePrefabs, position, beat.interval, currentBeatIndex, beat.type, previousStone, zIndex);
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

                if (beat.type == EnumManager.StoneType.LongBeat)
                {
                    float interval = _beats[currentBeatIndex].interval - beat.interval;
                    zIndex += interval + 1;
                    Debug.Log($"OFFSET: {interval}");
                    Debug.Log($"BEAT: {_beats[currentBeatIndex].interval} - {beat.interval}");
                }

                currentBeatIndex++;
            }

            Publish(new UpdateZPosCollectionMessage(zPosCollection));
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
