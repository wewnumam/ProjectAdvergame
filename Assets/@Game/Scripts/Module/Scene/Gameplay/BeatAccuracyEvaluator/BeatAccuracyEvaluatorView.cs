using Agate.MVC.Base;
using UnityEngine;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorView : BaseView
    {
        public SO_LevelData levelData;

        public float minPerfectTapPhase = .5f;
        
        public int currentBeatCollectionIndex { get; private set; }
        public int currentBeatIndex { get; private set; }
        public float currentInterval { get; private set; }

        private void Start()
        {
            currentInterval = levelData.beatCollections[0].beats[0].interval;
        }

        private void Update()
        {
            if (currentBeatCollectionIndex >= levelData.beatCollections.Count)
                return;

            currentInterval -= Time.deltaTime;

            if (currentInterval < 0)
            {
                if (currentBeatIndex < levelData.beatCollections[currentBeatCollectionIndex].beats.Count)
                {
                    currentInterval = levelData.beatCollections[currentBeatCollectionIndex].beats[currentBeatIndex].interval;
                    currentBeatIndex++;
                }
                else
                {
                    currentBeatIndex = 0;
                    currentBeatCollectionIndex++;
                }
            }
        }
    }
}