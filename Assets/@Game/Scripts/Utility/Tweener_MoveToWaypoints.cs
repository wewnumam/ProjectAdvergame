using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace ProjectAdvergame.Utility
{
    public class Tweener_MoveToWaypoints : MonoBehaviour
    {
        [SerializeField] EnumManager.TweenerMovementType movementType;

        [SerializeField] float duration = 5f; // Adjust as needed
        [SerializeField] float startDelay;
        [SerializeField] Transform[] waypoints;

        private int currentWaypointIndex = 0;
        private bool isMoving;

        private Coroutine currentMovingPlatformCoroutine;

        // Called when values are changed in the editor
        private void OnValidate()
        {
            if (waypoints != null && waypoints.Length > 0)
            {
                // Update GameObject's position to the last waypoint's position
                Transform lastWaypoint = waypoints[waypoints.Length - 1];
                if (lastWaypoint != null)
                {
                    transform.position = lastWaypoint.position;
                }
            }
        }

        private void OnEnable()
        {
            OnTrigger();
        }

        private void OnTrigger()
        {
            if (!isMoving)
            {
                isMoving = true;
                currentMovingPlatformCoroutine = StartCoroutine(MovePlatform());
            }
        }

        private IEnumerator MovePlatform()
        {
            yield return new WaitForSeconds(startDelay);

            while (isMoving)
            {
                Vector3 targetPosition = waypoints[currentWaypointIndex].position;

                // DOTween animation
                transform.DOMove(targetPosition, duration);

                // Wait for the DOTween animation to complete
                yield return new WaitForSeconds(duration);

                // Switch to the next waypoint
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

                // Stop on initial waypoints
                if (movementType == EnumManager.TweenerMovementType.ONE_WAY)
                {
                    currentWaypointIndex = 0;
                    transform.position = waypoints[waypoints.Length - 1].position;
                }
            }
        }

        public void StopMovement()
        {
            isMoving = false;
        }
    }
}