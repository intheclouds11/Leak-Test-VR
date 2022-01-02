using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseConnections : MonoBehaviour
{
    private GameObject hose1;
    private bool hose1Connected;
    private GameObject hose2;
    private bool hose2Connected;

    private void Update()
    {
        if (hose1Connected)
        {
            ConnectionFollow(hose1);
        }

        if (hose2Connected)
        {
            ConnectionFollow(hose2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.name == "Inlet Trigger" && other.CompareTag("Hose 1"))
        {
            Debug.Log("Hose 1 Connected");
            hose1Connected = true;
            hose1 = other.gameObject;
        }

        if (this.name == "Outlet Trigger" && other.CompareTag("Hose 2"))
        {
            Debug.Log("Hose 2 Connected");
            hose2Connected = true;
            hose2 = other.gameObject;
        }
    }

    void ConnectionFollow(GameObject hose)
    {
        var hoseTransform = hose.transform.parent;
        var thisTransform = this.transform;
        hoseTransform.position = thisTransform.position;
        hoseTransform.rotation = thisTransform.rotation;
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.name == "Inlet Trigger" && other.CompareTag("Hose 1"))
        {
            Debug.Log("Hose 1 Disconnected");
            hose1Connected = false;
        }

        if (this.name == "Outlet Trigger" && other.CompareTag("Hose 2"))
        {
            Debug.Log("Hose 2 Disconnected");
            hose2Connected = false;
        }
    }
}