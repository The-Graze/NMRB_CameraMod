using Il2CppSystem;
using Squido.NMR;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;

namespace NMRB_CameraMod
{
     class CameraController : MonoBehaviour
     {
        Camera cam;
        void Update()
        {
            if (gameObject.GetComponent<Character>()._mainCamera != null && cam == null)
            {
                MakeCam();
            }
        }
        void MakeCam()
        {
            cam = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Camera>();
            cam.stereoTargetEye = StereoTargetEyeMask.None;
            cam.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            cam.transform.SetParent(transform);
            cam.allowDynamicResolution = true;
            cam.targetDisplay = 8;
            cam.fieldOfView = 85;
            cam.transform.localPosition = new Vector3(0, -5, 0);
        }
     }
}
