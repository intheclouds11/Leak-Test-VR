using TMPro;
using UnityEngine;

public class HoseConnections : MonoBehaviour
{
    private Transform thisTransform;
    private Transform hoseTransform;
    private GameObject hose1;
    [SerializeField] Vector3 hose1Offset;
    public bool hose1Connected;
    private GameObject hose2;
    [SerializeField] Vector3 hose2Offset;
    public bool hose2Connected;

    private void Start()
    {
        thisTransform = this.transform;
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


    void ConnectionFollow(GameObject hose)
    {
        hoseTransform = hose.transform.parent;
        if (hose == hose1)
        {
            hoseTransform.position = thisTransform.position + hose1Offset;
            hoseTransform.eulerAngles = thisTransform.eulerAngles;
        }

        else
        {
            hoseTransform.position = thisTransform.position + hose2Offset;
            hoseTransform.eulerAngles = thisTransform.eulerAngles + new Vector3(0,180,0);
        }
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