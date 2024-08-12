using Agate.MVC.Base;
using DG.Tweening;
using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.OnReady
{
    public class OnReadyView : BaseView
    {
        [ReadOnly] public float readyOn;
        public TMP_Text countdownText;
        public TMP_Text levelHighscore;
        public GameObject onReadyPanel;
        public Tweener_ShowList tweener;

        public void Ready(UnityAction callback)
        {
            StartCoroutine(StartPlay(callback));
            countdownText.gameObject.SetActive(true);
        }

        private IEnumerator StartPlay(UnityAction callback)
        {
            float remainingTime = readyOn;

            while (remainingTime >= 0)
            {
                if (countdownText != null)
                    countdownText.SetText(remainingTime.ToString("0"));
                
                yield return new WaitForSeconds(1);
                remainingTime--;
            }

            countdownText.gameObject.SetActive(false);

            callback?.Invoke();
        }
    }
}