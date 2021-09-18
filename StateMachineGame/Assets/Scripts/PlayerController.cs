using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController charController;
    public GameManager gm;
    public float moveSpeed = 12;
    public float moveSpeedAtLevel2 = 15;
    public float moveSpeedAtLevel3 = 15;
    public float turnSpeed = 0.05f;
    public Transform characterBody;
    public Transform[] carrotSpawnLocations;
    private GameObject carrot;
    public GameObject attackRadius;
    public GameObject objInRadius = null;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movementVector = transform.forward * z;
        Vector3 turnVector = transform.right * x;

        if(gm.playerLevel == 2)
        {
            moveSpeed = moveSpeedAtLevel2;
        }
        if (gm.playerLevel == 3) moveSpeed = moveSpeedAtLevel3;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        charController.Move(movementVector * moveSpeed * Time.deltaTime);

        if(gm.playerLevel > 1)
        {
            if (Input.GetButtonUp("Jump")) Attack(objInRadius);
        }
        
    }
    
    private void Attack(GameObject go)
    {
        if(go.tag == "rabbit")
        {
            Destroy(go);
        }
    }
}
