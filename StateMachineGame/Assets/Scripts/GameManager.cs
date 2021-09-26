using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayerController pc;
    public int playerLevel = 1;
    public int playerCarrotsCollected = 0;
    private GameObject playerToInstant;
    private Vector3 playerSpawnLoc;
    public int deathTimer = 0;
    public int playerLives = 3;
    public Text livesText;

    Vector3 playerRespawn = new Vector3(0,1,7);

    // Start is called before the first frame update
    void Start()
    {
        playerSpawnLoc = player.transform.position;
        playerToInstant = player;
        livesText.text = "Remaining Lives: " + playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        //checks for death. could be moved into a new method if we wanted it to.
        if(!player.activeInHierarchy)
        {
            if (deathTimer >= 300)
            {
                player.transform.position = playerRespawn;
                player.SetActive(true);
                playerLives--;
                livesText.text = "Remaining Lives: " + playerLives;
            }
            deathTimer++;
        }
        else deathTimer = 0;

        if(playerLives <= 0)
        {
            SceneManager.LoadScene("End");
        }
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
        if(playerCarrotsCollected >= 3)
        {
            playerLevel = 2;
        }
        if(playerCarrotsCollected >= 6)
        {
            playerLevel = 3;
        }
    }
    public void CheckRabbitLevelUp(StateController sc)
    {
        if (sc.rabbitCarrotsCollected > 3) sc.rabbitLevel = 2;
    }
}
