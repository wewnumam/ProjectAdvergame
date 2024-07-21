using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorView : BaseView
    {
        [ReadOnly] public float minPerfectTapPhase;
        [ReadOnly] public List<BeatCollection> beatCollections;
        private UnityAction onTapLate;
        private UnityAction onBeatCollectionEnd;

        [Header("Indicator")]
        public Slider indicator;
        public TMP_Text accuracyText;
        public TMP_Text currentIntervalText;
        
        [Header("Current State"), ReadOnly] public bool isPlaying;
        [ReadOnly] public int tapIndex;
        [ReadOnly] public int currentBeatCollectionIndex;
        [ReadOnly] public int currentBeatIndex;
        [ReadOnly] public float currentInterval;

        private void Start()
        {
            accuracyText.SetText(string.Empty);
        }

        private void Update()
        {
            if (!isPlaying)
                return;

            if (!HasNextBeatCollection())
            {
                isPlaying = false;
                onBeatCollectionEnd?.Invoke();
                return;
            }

            currentInterval -= Time.deltaTime;
            currentIntervalText.SetText(currentInterval.ToString());

            if (IsCurrentIntervalHasElapsed())
            {
                if (IsPhaseLate())
                    onTapLate?.Invoke();

                if (HasNextBeat())
                {
                    currentInterval = beatCollections[currentBeatCollectionIndex].beats[currentBeatIndex].interval;
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

        public void SetCallback(UnityAction onTapLate, UnityAction onBeatCollectionEnd)
        {
            this.onTapLate = onTapLate;
            this.onBeatCollectionEnd = onBeatCollectionEnd;
        }

        private bool IsCurrentIntervalHasElapsed() => currentInterval < 0;

        private bool HasNextBeatCollection() => currentBeatCollectionIndex < beatCollections.Count;

        public bool HasNextBeat() => currentBeatIndex < beatCollections[currentBeatCollectionIndex].beats.Count;

        public bool IsPhaseEarly() => currentInterval >= minPerfectTapPhase;

        public bool IsPhasePerfect() => currentInterval < minPerfectTapPhase;

        public bool IsPhaseLate() => tapIndex < currentBeatIndex;

        public bool IsCurrentBeatAddHealth()
        {
            if (currentBeatIndex == 0) 
                return false;
            
            return beatCollections[currentBeatCollectionIndex].beats[currentBeatIndex - 1].type == Utility.EnumManager.StoneType.AddHealth;
        } 
    }
}