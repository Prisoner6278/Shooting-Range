using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject player;
    public GameObject[] playerCounts;

    void Awake()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCounts = GameObject.FindGameObjectsWithTag("Player");
        
        if (playerCounts.Length == 0)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        int spawn = Random.Range(0, spawnLocations.Length);
        GameObject.Instantiate(player, spawnLocations[spawn].transform.position, Quaternion.identity);
    }

}
