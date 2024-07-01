using Agate.MVC.Base;
using Agate.MVC.Core;
using Cinemachine;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.CameraManager
{
    public class CameraManagerView : BaseView
    {
        public CinemachineVirtualCamera cameraEast;
        public CinemachineVirtualCamera cameraWest;
        public CinemachineVirtualCamera cameraSouth;
    }
}