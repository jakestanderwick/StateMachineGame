using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.transform.position.x, 16.94f, player.transform.position.z);
        }
    }
}
