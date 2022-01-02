using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProcedureTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI procedureText;

    [SerializeField] private HoseConnections inletTrigger;
    [SerializeField] private HoseConnections outletTrigger;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inletTrigger.hose1Connected && outletTrigger.hose2Connected)
        {
            procedureText.text = "Hoses connected!";
        }
    }
}