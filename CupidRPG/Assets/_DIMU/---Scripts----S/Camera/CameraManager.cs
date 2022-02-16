using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{

    public Animator cameraAnimator;
    public GameObject[] cameraList;
    //GameObject nowCam;
    int nowCamIdx;
    public void CameraSwitch(CameraType cameraType)
    {
        if (nowCamIdx == (int)cameraType) return;

        cameraList[nowCamIdx].GetComponent<CinemachineFreeLook>().Priority = 0;
        //cameraAnimator.Play(cameraType.ToString());
        nowCamIdx = (int)cameraType;
        cameraList[nowCamIdx].GetComponent<CinemachineFreeLook>().Priority = 1;

    }
    private void Update()
    {
        //test code
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CameraSwitch(CameraType.Default);
            print("Default");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            CameraSwitch(CameraType.Aim);
            print("Aim");
        }
    }
}

public enum CameraType
{
    Default, Aim, ZoomIn
}
