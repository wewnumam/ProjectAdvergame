using Agate.MVC.Base;
using DG.Tweening;
using NaughtyAttributes;
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
        public TMP_Text tapText;
        public Image onReadyPanel;

        public void Ready(UnityAction callback)
        {
            StartCoroutine(StartPlay(callback));
            countdownText.gameObject.SetActive(true);
            tapText.gameObject.SetActive(false);
            onReadyPanel.DOFade(0, readyOn);
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

            onReadyPanel.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);

            callback?.Invoke();
        }
    }
}