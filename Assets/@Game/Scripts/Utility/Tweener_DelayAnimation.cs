using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Utility
{
    public class Tweener_DelayAnimation : MonoBehaviour
    {
        [SerializeField] string animTag;
        [SerializeField] float startDelay;
        
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
            Invoke(nameof(StartAnimation), startDelay);
        }

        private void StartAnimation()
        {
            animator.Play(animTag);
        }
    }
}