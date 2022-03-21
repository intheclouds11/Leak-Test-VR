using System;
using UnityEngine;
using UnityEngine.XR;

public class VRDebugging : MonoBehaviour
{
    [SerializeField] private GameObject XRDeviceSim;
    [SerializeField] private Transform XRRigTransform;
    [SerializeField] private float HeightOffset;
    [SerializeField] private bool cursorLocked;

    void Start()
    {
        DetectHmd();
    }

    private void Update()
    {
        UpdateCursorLockState();
    }

    private void UpdateCursorLockState()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
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
            Cursor.lockState = CursorLockMode.Locked;
            cursorLocked = true;
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