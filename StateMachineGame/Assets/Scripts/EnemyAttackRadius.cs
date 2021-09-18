using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRadius : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StateController sc = GetComponentInParent<StateController>();
        sc.objInRadius = other.gameObject;
    }
}
