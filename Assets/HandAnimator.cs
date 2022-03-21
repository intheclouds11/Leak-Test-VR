using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimator : MonoBehaviour
{
    public bool showController;
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;
    [SerializeField] private GameObject handModel;
    [SerializeField] private GameObject controllerModel;
    private Animator handAnimator;

    void Start()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            // more from Valem hand presence video but don't want to deal with controller prefabs
        }

        handAnimator = handModel.GetComponent<Animator>();
    }

    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }

        if (showController)
        {
            handModel.SetActive(false);
            controllerModel.SetActive(true);
        }
        else
        {
            handModel.SetActive(true);
            controllerModel.SetActive(false);
            UpdateHandAnimation();
        }
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }
}