using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCheck : MonoBehaviour
{
    void Start()
    {
        FindSpawnersInRoom(gameObject.transform);
    }
    public void FindSpawnersInRoom(Transform roomTransform)
    {
        Spawner[] spawners = roomTransform.GetComponentsInChildren<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            spawner.isNewLvl = true;
        }
    }
}
