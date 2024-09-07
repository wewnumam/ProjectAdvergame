using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Utility
{
    public class Tweener_InfiniteRotatation : MonoBehaviour
    {
        public float duration = 360f; // Degrees per second
        public float startDelay = 2f; // Delay in seconds
        public bool reverse;

        void Start()
        {
            // Infinite rotation
            transform.DORotate(new Vector3(transform.rotation.x, reverse ? 360 : -360, transform.rotation.z), duration, RotateMode.FastBeyond360)
                     .SetRelative()  // Continue rotating beyond 360 degrees
                     .SetEase(Ease.Linear)  // Make the rotation constant speed
                     .SetLoops(-1)  // Loop infinitely
                     .SetDelay(startDelay); // Start delay before rotation
        }
    }
}