using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
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
        }
    }
}