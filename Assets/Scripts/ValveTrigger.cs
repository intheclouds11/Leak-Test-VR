using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class ValveTrigger : MonoBehaviour
{
    public static event Action ValveAtLeakPressure;
    public static event Action ValveAtZeroPressure;

    public bool valveAtProofPressure;
    public bool valveAtLeakPressure;
    public bool valveAtZeroPressure;
    [SerializeField] HoseConnections inletConnection;
    [SerializeField] HoseConnections outletConnection;
    public bool hoseConnected;
    public bool bomConnected;
    public bool capConnected;

    [SerializeField] private TextMeshProUGUI procedureText;

    private void Update()
    {
        hoseConnected = inletConnection.hoseConnected;
        bomConnected = outletConnection.bomConnected;
        capConnected = outletConnection.capConnected;

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            ValveAtLeakPressure?.Invoke();
        }

        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            ValveAtZeroPressure?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zero Pressure"))
        {
            valveAtZeroPressure = true;
            ValveAtZeroPressure?.Invoke();
            valveAtLeakPressure = false;
            valveAtProofPressure = false;
            Debug.Log("At Zero Pressure");
            procedureText.text = "At Zero Pressure";
        }

        if (other.CompareTag("Leak Pressure"))
        {
            if (hoseConnected && bomConnected || capConnected)
            {
                valveAtZeroPressure = false;
                valveAtLeakPressure = true;
                ValveAtLeakPressure?.Invoke();
                valveAtProofPressure = false;
                Debug.Log("At Leak Pressure");
                procedureText.text = "At Leak Pressure";
            }
            else
            {
                Debug.Log("Make connections first");
                procedureText.text = "Make connections first!";
            }
        }

        if (other.CompareTag("Proof Pressure"))
        {
            if (hoseConnected && bomConnected)
            {
                Debug.Log("Over pressurized BOM!");
                procedureText.text = "Over pressurized BOM!";
            }
            else if (hoseConnected & capConnected)
            {
                valveAtZeroPressure = false;
                valveAtLeakPressure = false;
                valveAtProofPressure = true;
                Debug.Log("At Proof Pressure");
                procedureText.text = "At Proof Pressure";
            }
            else
            {
                Debug.Log("Make connections first");
                procedureText.text = "Make connections first!";
            }
        }
    }
}