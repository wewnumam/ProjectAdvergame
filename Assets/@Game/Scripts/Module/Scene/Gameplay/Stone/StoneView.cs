using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using ProjectAdvergame.Utility;
using NaughtyAttributes;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneView : BaseView
    {
        [ReadOnly] public float duration;
        [ReadOnly] public int index;
        [ReadOnly] public float zIndex;
        [ReadOnly] public EnumManager.Direction direction;
        [ReadOnly] public EnumManager.StoneType stoneType;
        [ReadOnly] public StoneView previousStone;
        [ReadOnly] public bool isSwitchCamera;

        public UnityAction onComplete;
        public UnityAction<StoneView> stoneFallEvent;
        private UnityAction<EnumManager.Direction> switchCameraEvent;

        private bool isMoving = false;
        private bool isFalling = false;
        private Vector3 targetPosition;
        private Vector3 startPosition;
        private float elapsedTime = 0f;
        private float moveDuration;

        private bool isPaused = false;

        public void SetCallback(UnityAction onComplete)
        {
            this.onComplete += onComplete;
        }

        public void Play()
        {
            startPosition = transform.position;
            targetPosition = new Vector3(0, 0, zIndex + index);
            moveDuration = duration;
            elapsedTime = 0f;
            isMoving = true;
        }

        public void Fall()
        {
            startPosition = transform.position;
            targetPosition = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            moveDuration = 3f; // Fall duration
            elapsedTime = 0f;
            isFalling = true;
        }

        private void FixedUpdate()
        {
            if (isPaused) return; // Skip if paused

            if (isMoving)
            {
                MoveStone();
            }

            if (isFalling)
            {
                FallStone();
            }
        }

        private void MoveStone()
        {
            elapsedTime += Time.fixedDeltaTime;

            if (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            }
            else
            {
                transform.position = targetPosition; // Ensure final position is set
                isMoving = false; // Stop moving

                // Trigger events
                switchCameraEvent?.Invoke(direction);
                previousStone?.Fall();
                onComplete?.Invoke();
            }
        }

        private void FallStone()
        {
            elapsedTime += Time.fixedDeltaTime;

            if (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            }
            else
            {
                transform.position = targetPosition; // Ensure final position is set
                isFalling = false; // Stop falling
                gameObject.SetActive(false);
            }
        }

        public void Pause()
        {
            isPaused = !isPaused; // Toggle pause state
        }

        public void SwitchCamera(UnityAction<EnumManager.Direction> switchCameraEvent)
        {
            this.switchCameraEvent = switchCameraEvent;
        }
    }
}
