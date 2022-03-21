using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
[ExecuteInEditMode]

public class HeadMountedTrigger : MonoBehaviour
{
    [SerializeField] Transform HMDTransform;
    [SerializeField] Vector3 faceOffset;
    [SerializeField] InputActionAsset playerControlsVR;
    private InputAction rhTrigger;
    [SerializeField] TextMeshProUGUI procedureText;
    private int triggerCount;
    [SerializeField] private ParticleSystem fireworks;

    void Start()
    {
        EnableVRControls();
    }

    void Update()
    {
        // Follow HMD
        transform.position = HMDTransform.position + faceOffset;
        transform.rotation = HMDTransform.rotation;
    }

    void EnableVRControls()
    {
        var gameplayActionMapRH = playerControlsVR.FindActionMap("XRI RightHand");

        rhTrigger = gameplayActionMapRH.FindAction("Activate");
        rhTrigger.Enable();
    }

    void ActivateHeadMountedInteraction(InputAction.CallbackContext context)
    {
        triggerCount++;
        Debug.Log("Triggered", this);
        procedureText.text = $"Triggered {triggerCount} times";
        fireworks.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right Hand"))
        {
            rhTrigger.performed += ActivateHeadMountedInteraction;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Right Hand"))
        {
            rhTrigger.performed -= ActivateHeadMountedInteraction;
        }
    }
}