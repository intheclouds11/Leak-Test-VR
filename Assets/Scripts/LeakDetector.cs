using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeakDetector : MonoBehaviour
{
    [SerializeField] private ValveTrigger valveTrigger;
    private bool valveAtLeakPressure;
    [SerializeField] private TextMeshProUGUI procedureText;
    
    private void FixedUpdate()
    {
        valveAtLeakPressure = valveTrigger.valveAtLeakPressure;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leak") && valveAtLeakPressure)
        {
            procedureText.text = "Leak detected!";
        }
        if (other.CompareTag("Leak") && !valveAtLeakPressure)
        {
            procedureText.text = "No pressure!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Leak") && valveAtLeakPressure)
        {
            procedureText.text = "Detecting leak...";
        }
    }
}
