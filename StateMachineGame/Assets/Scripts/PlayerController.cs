using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController charController;
    public float moveSpeed = 12;
    public float turnSpeed = 0.05f;
    public Transform characterBody;
    public Transform[] carrotSpawnLocations;
    private GameObject carrot;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movementVector = transform.forward * z;
        Vector3 turnVector = transform.right * x;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        charController.Move(movementVector * moveSpeed * Time.deltaTime);
    }
    
}
