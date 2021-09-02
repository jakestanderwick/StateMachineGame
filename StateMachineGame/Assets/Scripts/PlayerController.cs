using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController charController;
    public float moveSpeed = 12;
    public Transform characterBody;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movementVector = transform.right * x + transform.forward * z;

        charController.Move(movementVector * moveSpeed * Time.deltaTime);
    }
}
