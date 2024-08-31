using Agate.MVC.Base;
using Agate.MVC.Core;
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
        [ReadOnly] public List<Beat> beats;
        private UnityAction onTapLate;
        private UnityAction onBeatLong;
        private UnityAction onBeatCollectionEnd;

        [Header("UI Test")]
        public Slider indicator;
        public TMP_Text tapText;
        public TMP_Text accuracyText;
        public TMP_Text currentIntervalText;
        public TMP_Text currentBeatText;
        
        [Header("Env Indicator")]
        public MeshRenderer objectIndicator;
        public Material normalMaterial;
        public Material perfectMaterial;
        public ParticleSystem particle;
        
        [Header("Current State"), ReadOnly] public bool isPlaying;
        [ReadOnly] public int tapIndex;
        [ReadOnly] public int currentBeatIndex;
        [ReadOnly] public float currentInterval;

        private void Update()
        {
            if (!isPlaying)
                return;

            if (!HasNextBeat())
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

                float previousInterval = currentBeatIndex != 0 ? beats[currentBeatIndex - 1].interval : 0;
                currentInterval = beats[currentBeatIndex].interval - previousInterval;
                currentBeatIndex++;
                currentBeatText?.SetText(currentBeatIndex.ToString());
                
                if (IsCurrentBeatLong())
                    onBeatLong?.Invoke();

                #region Indicator
                
                indicator.fillRect.GetComponent<Image>().color = Color.red;
                objectIndicator.material = normalMaterial;
                
                #endregion
            }

            #region Indicator

            objectIndicator.transform.localScale = Vector3.one * (currentInterval + 1);
            indicator.value = currentInterval;

            if (IsPhasePerfect())
            {
                indicator.fillRect.GetComponent<Image>().color = Color.green;
                objectIndicator.material = perfectMaterial;
            }

            #endregion
        }

        public void SetCallback(UnityAction onTapLate, UnityAction onBeatLong, UnityAction onBeatCollectionEnd)
        {
            this.onTapLate = onTapLate;
            this.onBeatLong = onBeatLong;
            this.onBeatCollectionEnd = onBeatCollectionEnd;
        }

        private bool IsCurrentIntervalHasElapsed() => currentInterval < 0;

        public bool HasNextBeat() => currentBeatIndex < beats.Count;

        public bool IsPhaseEarly() => currentInterval >= minPerfectTapPhase;

        public bool IsPhasePerfect() => currentInterval < minPerfectTapPhase;

        public bool IsPhaseLate() => tapIndex < currentBeatIndex;

        public bool IsCurrentBeatAddHealth()
        {
            if (currentBeatIndex == 0) 
                return false;
            
            return beats[currentBeatIndex - 1].type == Utility.EnumManager.StoneType.AddHealth;
        }

        public bool IsCurrentBeatLong()
        {
            if (currentBeatIndex < 2)
                return false;

            return beats[currentBeatIndex - 2].type == Utility.EnumManager.StoneType.LongBeat;
        }
    }
}