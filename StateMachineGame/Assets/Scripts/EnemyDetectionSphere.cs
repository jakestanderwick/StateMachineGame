using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSphere : MonoBehaviour
{
    private StateController stateController;

    private void Start()
    {
        stateController = GetComponentInParent<StateController>();
    }
    private void OnTriggerEnter(Collider c)
    {
        stateController.DetectionSphereTriggerHandler(c.gameObject);
    }
    private void OnTriggerExit(Collider c)
    {
        stateController.NoDetection();
    }
}
