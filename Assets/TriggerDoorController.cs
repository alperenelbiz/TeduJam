using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    public Spawner[] spawner;

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            if (openTrigger)
            {
                foreach (Spawner spawner in spawner)
                    spawner.isNewLvl = false;
                myDoor.Play("doorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                foreach (Spawner spawner in spawner)
                    spawner.isNewLvl = true;
                myDoor.Play("doorClose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
