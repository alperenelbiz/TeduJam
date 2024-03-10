using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    public List<Spawner> spawners = new List<Spawner>();
    
    Event event0;

    private void Update()
    {
        while(event0.enemies.Length>0) {
            gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            if (openTrigger)
            {
                foreach (Spawner spawner in spawners)
                    spawner.isNewLvl = false;
                
                myDoor.Play("doorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                foreach (Spawner spawner in spawners)
                    spawner.isNewLvl = true;
               
                myDoor.Play("doorClose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
