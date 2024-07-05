using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorController : ObjectController<BeatAccuracyEvaluatorController, BeatAccuracyEvaluatorView>
    {
        internal void OnTap(MovePlayerCharacterMessage message)
        {
            if (_view.currentInterval >= _view.minPerfectTapPhase)
            {
                Debug.Log("EARLY");
            }
            else if (_view.currentInterval < _view.minPerfectTapPhase)
            {
                Debug.Log("PERFECT");
            }
            else if (_view.currentInterval < 0)
            {
                Debug.Log("LATE");
            }
        }
    }
}