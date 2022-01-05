using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeakDetector : MonoBehaviour
{
    [SerializeField] private ValveTrigger valveTrigger;
    private bool valveAtPressure;
    [SerializeField] private TextMeshProUGUI procedureText;
    
    private void FixedUpdate()
    {
        valveAtPressure = valveTrigger.valveAtPressure;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leak") && valveAtPressure)
        {
            procedureText.text = "Leak detected!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Leak") && valveAtPressure)
        {
            procedureText.text = "Detecting leak...";
        }
    }
}
