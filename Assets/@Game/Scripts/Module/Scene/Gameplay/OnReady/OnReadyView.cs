using Agate.MVC.Base;
using NaughtyAttributes;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.OnReady
{
    public class OnReadyView : BaseView
    {
        [ReadOnly] public float readyOn;
        [SerializeField] TMP_Text countdownText;

        public void Ready(UnityAction callback)
        {
            StartCoroutine(StartPlay(callback));
        }

        private IEnumerator StartPlay(UnityAction callback)
        {
            float remainingTime = readyOn;

            while (remainingTime > 0)
            {
                if (countdownText != null)
                    countdownText.SetText(remainingTime.ToString("0"));
                
                yield return new WaitForSeconds(1);
                remainingTime--;
            }

            if (countdownText != null)
                countdownText.gameObject.SetActive(false);

            callback?.Invoke();
        }
    }
}