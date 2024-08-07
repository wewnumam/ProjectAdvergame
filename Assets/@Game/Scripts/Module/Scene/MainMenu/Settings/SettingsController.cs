using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.Settings
{
    public class SettingsController : ObjectController<SettingsController, SettingsView>
    {
        public override void SetView(SettingsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnVolume, OnVibrate);
        }

        private void OnVolume(float volume)
        {
            if (volume > 0)
                _view.audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
            else
                _view.audioMixer.SetFloat("MasterVolume", -80f);

            Publish(new GameSettingVolumeMessage(volume));
        }

        private void OnVibrate(bool vibrate)
        {
            Publish(new GameSettingVibrateMessage(vibrate));
        }

        internal void SetVibrate(bool isVibrateOn)
        {
            _view.vibrateToggle.isOn = isVibrateOn;
        }

        internal void SetVolume(float audioVolume)
        {
            _view.audioVolumeSlider.value = audioVolume;
        }
    }
}