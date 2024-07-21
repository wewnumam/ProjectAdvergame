using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.MusicPlayer
{
    public class MusicPlayerController : ObjectController<MusicPlayerController, MusicPlayerView>
    {
        private AudioClip musicClip;

        public void SetMusicClip(AudioClip clip)
        {
            musicClip = clip;
        }
        internal void StartPlay(StartPlayMessage message)
        {
            _view.audioSource.clip = musicClip;
            _view.audioSource.Play();
            _view.isPlaying = true;
        }

        internal void OnPause(GamePauseMessage message)
        {
            _view.audioSource.Stop();
        }

        internal void OnGameOver(GameOverMessage message)
        {
            _view.audioSource.Stop();
            _view.isPlaying = false;
        }
    }
}