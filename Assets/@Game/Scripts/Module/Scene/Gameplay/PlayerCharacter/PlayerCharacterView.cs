using Agate.MVC.Base;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterView : BaseView
    {
        private UnityAction<string, GameObject> stoneState;

        public void SetCallback(UnityAction<string, GameObject> stoneState)
        {
            this.stoneState = stoneState;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.TAG_COLLIDER_EARLY))
                stoneState?.Invoke(TagManager.TAG_COLLIDER_EARLY, other.GetComponentInParent<StoneView>().gameObject);
            else if (other.CompareTag(TagManager.TAG_COLLIDER_PERFECT))
                stoneState?.Invoke(TagManager.TAG_COLLIDER_PERFECT, other.GetComponentInParent<StoneView>().gameObject);
            else if (other.CompareTag(TagManager.TAG_COLLIDER_LATE))
                stoneState?.Invoke(TagManager.TAG_COLLIDER_LATE, other.GetComponentInParent<StoneView>().gameObject);
        }
    }
}