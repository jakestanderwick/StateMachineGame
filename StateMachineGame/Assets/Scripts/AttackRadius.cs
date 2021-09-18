using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc = GetComponentInParent<PlayerController>();
        pc.objInRadius = other.gameObject;
    }
}
