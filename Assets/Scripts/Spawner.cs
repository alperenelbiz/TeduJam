using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public bool isNewLvl;
    public bool cantSpawn;
    public int maxSpawn;
    public int spawnCooldown;
    private float nextSpawnTime;
    private int spawned;

    void Start()
    {
        isNewLvl = false;
        cantSpawn = false;
    }

   
    void Update()
    {
        if(spawned==maxSpawn)
        {
            cantSpawn = true;
        }
        if (isNewLvl == true && Time.time >= nextSpawnTime && !cantSpawn)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);
            Debug.Log(randomIndex);
            nextSpawnTime = Time.time + spawnCooldown;
            spawned++;
        }
    }
}
