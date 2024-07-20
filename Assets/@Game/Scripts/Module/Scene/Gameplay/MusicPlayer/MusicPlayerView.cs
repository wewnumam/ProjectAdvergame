using Agate.MVC.Base;
using Agate.MVC.Core;
using Cinemachine;
using NaughtyAttributes;
using System.Text;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Module.MusicPlayer
{
    public class MusicPlayerView : BaseView
    {
        public AudioSource audioSource;

        public TMP_Text timerText;

        private float elapsedTime;
        private StringBuilder stringBuilder;

        [ReadOnly] public bool isPlaying;

        void Start()
        {
            stringBuilder = new StringBuilder(10);
        }

        void Update()
        {
            if (!isPlaying)
                return;

            elapsedTime += Time.deltaTime;

            // Calculate minutes, seconds, and milliseconds.
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000F) % 1000F);

            // Use StringBuilder to format the timer string.
            stringBuilder.Length = 0;  // Clear the StringBuilder
            stringBuilder.AppendFormat("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            // Update the timer text less frequently, e.g., every 0.1 seconds
            if (Time.frameCount % 6 == 0)  // Adjust the modulus value as needed
            {
                timerText.SetText(stringBuilder.ToString());
            }
        }
    }
}