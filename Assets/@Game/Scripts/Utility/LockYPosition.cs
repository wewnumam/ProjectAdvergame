using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Utility
{
    public class LockYPosition : MonoBehaviour
    {
        // Set the desired Y position you want to lock to
        public float lockedYPosition = 0f;
        private Vector3 currentPosition;

        void Update()
        {
            // Get the current position of the object
            currentPosition = transform.position;

            // Lock the Y position
            currentPosition.y = lockedYPosition;

            // Update the object's position with the locked Y value
            transform.position = currentPosition;
        }
    }

}