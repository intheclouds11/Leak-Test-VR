using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveTrigger : MonoBehaviour
{
    private bool valve1AtPressure;
    [SerializeField] HoseConnections hose1Connections;
    [SerializeField] HoseConnections hose2Connections;
    public bool hose1Connected;
    public bool hose2Connected;

    private void Update() // look into using events instead of Update
    {
        hose1Connected = hose1Connections.hose1Connected;
        hose2Connected = hose2Connections.hose2Connected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Valve Indicator") && hose1Connected & hose2Connected)
        {
            Debug.Log("!!!");
            valve1AtPressure = true;
        }
    }
}