using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorView : BaseView
    {
        public SO_LevelData levelData;
        public float minPerfectTapPhase = .5f;
        public int tapIndex;
        private UnityAction onTapLate;

        [Header("Indicator")]
        public Slider indicator;
        public TMP_Text accuracyText;

        public int currentBeatCollectionIndex { get; private set; }
        public int currentBeatIndex { get; private set; }
        public float currentInterval { get; private set; }

        private void Start()
        {
            accuracyText.SetText(string.Empty);
        }

        private void Update()
        {
            if (!HasNextBeatCollection())
                return;

            currentInterval -= Time.deltaTime;

            if (IsCurrentIntervalHasElapsed())
            {
                if (IsPhaseLate())
                    onTapLate?.Invoke();

                if (HasNextBeat())
                {
                    currentInterval = levelData.beatCollections[currentBeatCollectionIndex].beats[currentBeatIndex].interval;
                    currentBeatIndex++;
                }
                else
                {
                    currentBeatIndex = 0;
                    tapIndex = 0;
                    currentBeatCollectionIndex++;
                }
            }

            #region Indicator

            indicator.value = currentInterval;
            if (IsPhasePerfect())
                indicator.fillRect.GetComponent<Image>().color = Color.green;
            else
                indicator.fillRect.GetComponent<Image>().color = Color.red;

            #endregion
        }

        public void SetCallback(UnityAction onTapLate)
        {
            this.onTapLate = onTapLate;
        }

        private bool IsCurrentIntervalHasElapsed() => currentInterval < 0;

        private bool HasNextBeatCollection() => currentBeatCollectionIndex < levelData.beatCollections.Count;

        private bool HasNextBeat() => currentBeatIndex < levelData.beatCollections[currentBeatCollectionIndex].beats.Count;

        public bool IsPhaseEarly() => currentInterval >= minPerfectTapPhase;

        public bool IsPhasePerfect() => currentInterval < minPerfectTapPhase;

        public bool IsPhaseLate() => tapIndex < currentBeatIndex;
    }
}