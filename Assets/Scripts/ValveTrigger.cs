using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ValveTrigger : MonoBehaviour
{
    public bool valveAtPressure;
    [SerializeField] HoseConnections hose1Connection;
    [SerializeField] HoseConnections hose2Connection;
    public bool hose1Connected;
    public bool hose2Connected;

    [SerializeField] private TextMeshProUGUI procedureText;
    
    private void FixedUpdate() // look into using events instead of Update
    {
        hose1Connected = hose1Connection.hose1Connected;
        hose2Connected = hose2Connection.hose2Connected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Valve Indicator") && hose1Connected & hose2Connected)
        {
            Debug.Log("Hoses pressurized");
            procedureText.text = "Hoses pressurized!";
            valveAtPressure = true;
        }

        if (other.CompareTag("Valve Indicator") && !(hose1Connected & hose2Connected))
        {
            Debug.Log("Connect hoses first");
            procedureText.text = "Connect hoses first!";
        }
    }
}