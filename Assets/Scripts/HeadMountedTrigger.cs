using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMountedTrigger : MonoBehaviour
{
    private Transform hmdTransform;
    [SerializeField] Vector3 faceOffset;
    [SerializeField] InputActionAsset playerControlsVR;
    private InputAction rhTrigger;
    [SerializeField] private TextMeshProUGUI procedureText;
    private int triggerCount;

    void Start()
    {
        hmdTransform = FindObjectOfType<Camera>().transform;
        EnableVRControls();
    }

    // Follow HMD
    void FixedUpdate()
    {
        gameObject.transform.position = hmdTransform.position + faceOffset;
        gameObject.transform.rotation = hmdTransform.rotation;
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