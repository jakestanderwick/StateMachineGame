using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeMaterial : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            count++;

            if (count == 20)
            {
                rend.sharedMaterial = material[1];
            }
            if (count == 40)
            {
                rend.sharedMaterial = material[2];
            }
            if (count == 60)
            {
                rend.sharedMaterial = material[3];
            }
            if (count == 80)
            {
                rend.sharedMaterial = material[0];
                count = 0;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            count++;

            if (count == 20)
            {
                rend.sharedMaterial = material[3];
            }
            if (count == 40)
            {
                rend.sharedMaterial = material[2];
            }
            if (count == 60)
            {
                rend.sharedMaterial = material[1];
            }
            if (count == 80)
            {
                rend.sharedMaterial = material[0];
                count = 0;
            }
        }
        else
        {
            rend.sharedMaterial = material[0];
        }

    }
}
