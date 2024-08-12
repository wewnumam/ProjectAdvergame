using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Utility
{
    public class Tweener_ShowList : MonoBehaviour
    {
        [ReadOnly] public bool isActive;
        [ReadOnly] public List<float> initialRecTransformX;
        [SerializeField] List<RectTransform> rectTransforms;
        [SerializeField] float duration = 1f;
        [SerializeField] float interval = 1f;
        
        private void Start()
        {
            for (int i = 0; i < rectTransforms.Count; i++)
            {
                initialRecTransformX.Add(rectTransforms[i].anchoredPosition.x);
            }
        }

        public void ShowList()
        {
            float currentDelay = 0;
            
            if (!isActive)
            {
                foreach (var item in rectTransforms)
                {
                    item.DOAnchorPosX(0, duration).SetDelay(currentDelay).SetUpdate(true);
                    currentDelay += interval;
                }
            }
            else
            {
                for (int i = 0; i < rectTransforms.Count; i++)
                {
                    rectTransforms[i].DOAnchorPosX(initialRecTransformX[i], duration).SetDelay(currentDelay).SetUpdate(true);
                    currentDelay += interval;
                }
            }
            
            isActive = !isActive;
        }
    }
}