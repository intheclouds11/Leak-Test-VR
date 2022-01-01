using System;
using UnityEngine;
using UnityEngine.XR;

public class VRDebugging : MonoBehaviour
{
    // [SerializeField] private GameObject[] XRControllersToToggle;
    // [SerializeField] private bool enableVRControllers;
    [SerializeField] private GameObject XRDeviceSim;
    [SerializeField] private Transform XRRigTransform;
    [SerializeField] private float HeightOffset;

    void Start()
    {
        DetectHmd();
    }

    private void DetectHmd()
    {
        Debug.Log("XR Device detected: " + XRSettings.loadedDeviceName);

        if (XRSettings.loadedDeviceName == "OpenXR Display")
        {
            Debug.Log("Case 1: HMD detected");
            XRDeviceSim.SetActive(false); // disable XRDeviceSimulator while using HMD + controllers
        }
        else
        {
            Debug.Log("Case 2: No HMD detected");
            UseHeightOffset();
        }
    }

    private void UseHeightOffset()
    {
        var XRRigPosition = XRRigTransform.position;
        XRRigPosition = new Vector3(XRRigPosition.x, HeightOffset, XRRigPosition.z);
        XRRigTransform.position = XRRigPosition;
    }
}