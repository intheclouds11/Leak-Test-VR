using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

public class HoseConnections : MonoBehaviour
{
    private Transform _hoseTransform;
    private GameObject _hoseGO;
    public bool hoseConnected;
    private GameObject _bomGO;
    public bool bomConnected;
    private GameObject _capGO;
    public bool capConnected;
    public ValveTrigger valveTrigger;

    [SerializeField] private TextMeshProUGUI procedureText;

    [SerializeField] private BubbleOMeter _bubbleOMeter;
    

    private void OnTriggerEnter(Collider other)
    {
        if (this.name == "Inlet Trigger" && other.CompareTag("Hose"))
        {
            Debug.Log("Hose connected", this);
            hoseConnected = true;
            _hoseGO = other.gameObject;
            procedureText.text = "Hose connected!";
        }

        if (this.name == "Outlet Trigger" && other.CompareTag("Bubble-O-Meter"))
        {
            Debug.Log("Bubble-O-Meter connected", this);
            bomConnected = true;
            _bomGO = other.gameObject;
            procedureText.text = "Bubble-O-Meter connected!";
        }

        if (this.name == "Outlet Trigger" && other.CompareTag("Cap") && !bomConnected)
        {
            Debug.Log("Cap connected", this);
            capConnected = true;
            _capGO = other.gameObject;
            procedureText.text = "Cap connected!";
        }
    }

    private void Update()
    {
        if (hoseConnected)
        {
            ConnectionFollow(_hoseGO);
        }

        if (bomConnected)
        {
            ConnectionFollow(_bomGO);
        }

        if (capConnected)
        {
            ConnectionFollow(_capGO);
        }
    }


    void ConnectionFollow(GameObject obj)
    {
        ParentConstraint parentConstraint = obj.GetComponent<ParentConstraint>();
        parentConstraint.constraintActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.name == "Inlet Trigger" && other.CompareTag("Hose"))
        {
            Debug.Log("Hose Disconnected");
            hoseConnected = false;
            ParentConstraint parentConstraint = other.GetComponent<ParentConstraint>();
            parentConstraint.constraintActive = false;
            
            if (valveTrigger.valveAtLeakPressure || valveTrigger.valveAtProofPressure)
            {
                _bubbleOMeter.StopBubbleUp();
                Debug.Log("Disconnected while under pressure!");
            }
        }

        if (this.name == "Outlet Trigger" && other.CompareTag("Bubble-O-Meter"))
        {
            Debug.Log("Bubble-O-Meter Disconnected");
            bomConnected = false;
            ParentConstraint parentConstraint = other.GetComponent<ParentConstraint>();
            parentConstraint.constraintActive = false;
            
            if (valveTrigger.valveAtLeakPressure || valveTrigger.valveAtProofPressure)
            {
                _bubbleOMeter.StopBubbleUp();
                Debug.Log("Disconnected while under pressure!");
            }
        }

        if (this.name == "Outlet Trigger" && other.CompareTag("Cap"))
        {
            Debug.Log("Cap Disconnected");
            capConnected = false;
            ParentConstraint parentConstraint = other.GetComponent<ParentConstraint>();
            parentConstraint.constraintActive = false;
            
            if (valveTrigger.valveAtLeakPressure || valveTrigger.valveAtProofPressure)
            {
                Debug.Log("Disconnected while under pressure!");
            }
        }
    }
}