using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
[ExecuteInEditMode]

public class HeadMountedTrigger : MonoBehaviour
{
    [SerializeField] Transform hmdTransform;
    [SerializeField] Vector3 faceOffset;
    [SerializeField] InputActionAsset playerControlsVR;
    private InputAction rhTrigger;
    [SerializeField] private TextMeshProUGUI procedureText;
    private int triggerCount;
    [SerializeField] private ParticleSystem fireworks;

    void Start()
    {
        EnableVRControls();
    }

    void Update()
    {
        // Follow HMD
        transform.position = hmdTransform.position + faceOffset;
        transform.rotation = hmdTransform.rotation;
    }

    void EnableVRControls()
    {
        var gameplayActionMapRH = playerControlsVR.FindActionMap("XRI RightHand");

        rhTrigger = gameplayActionMapRH.FindAction("Activate");
        rhTrigger.Enable();
    }

    void TriggerColliderInteraction(InputAction.CallbackContext context)
    {
        triggerCount++;
        Debug.Log("Triggered");
        procedureText.text = $"Triggered {triggerCount} times";
        fireworks.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            rhTrigger.performed += TriggerColliderInteraction;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            rhTrigger.performed -= TriggerColliderInteraction;
        }
    }
}