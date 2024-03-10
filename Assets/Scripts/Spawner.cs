using System;
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
    private int keep;
    private int spawned;

    void Start()
    {
        isNewLvl = false;
        cantSpawn = false;
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {

            if (enemyPrefabs[i].name == "Eye")
            {
                keep = i;
                Debug.Log(i);
                break;
            }
        }
    }


    void Update()
    {
        CheckCollision();
        if (spawned == maxSpawn)
        {
            cantSpawn = true;
        }
        if (isNewLvl == true && Time.time >= nextSpawnTime && !cantSpawn)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);
            nextSpawnTime = Time.time + spawnCooldown;
            spawned++;
        }
    }
    void CheckCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Special"))
            {
                
                if (spawned == maxSpawn)
                {
                    cantSpawn = true;
                }

                if (isNewLvl && Time.time >= nextSpawnTime && !cantSpawn)
                {
                    GameObject enemy = Instantiate(enemyPrefabs[keep], transform.position, Quaternion.identity);
                    nextSpawnTime = Time.time + spawnCooldown;
                    spawned++;
                }
            }
        }
    }
}
