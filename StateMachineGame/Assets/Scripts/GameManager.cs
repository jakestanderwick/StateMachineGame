using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayerController pc;
    public int playerLevel = 1;
    public int playerCarrotsCollected = 0;
    private GameObject playerToInstant;
    private Vector3 playerSpawnLoc;
    public int deathTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawnLoc = player.transform.position;
        playerToInstant = player;
    }

    // Update is called once per frame
    void Update()
    {
        //checks for death. could be moved into a new method if we wanted it to.
        if(!player.activeInHierarchy)
        {
            if (deathTimer >= 200)
            {
                player.SetActive(true);
            }
            deathTimer++;
        }
        else deathTimer = 0;
    }

    public Vector3 PickNewCarrotSpawn(GameObject go)
    {
        int rand = Random.Range(0, pc.carrotSpawnLocations.Length);
        Vector3 spawnLoc = new Vector3(pc.carrotSpawnLocations[rand].transform.position.x, transform.position.y, pc.carrotSpawnLocations[rand].transform.position.z);
        if(go.tag == "player")
        {
          playerCarrotsCollected++;
        }
        CheckPlayerLevelUp();
        return spawnLoc;
    }
    public void rabbitPickedUpCarrot(StateController sc)
    {
        sc.rabbitCarrotsCollected++;
        CheckRabbitLevelUp(sc);
    }
    public void CheckPlayerLevelUp()
    {
        if(playerCarrotsCollected > 4)
        {
            playerLevel = 2;
        }
        if(playerCarrotsCollected > 9)
        {
            playerLevel = 3;
        }
    }
    public void CheckRabbitLevelUp(StateController sc)
    {
        if (sc.rabbitCarrotsCollected > 3) sc.rabbitLevel = 2;
    }
}
