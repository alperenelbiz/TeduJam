using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger : MonoBehaviour
{
    [SerializeField] public bool orbTrigger1 = false;
    CardSystem cardScript;
    public void Start()
    {
        cardScript = GameObject.Find("UIController").GetComponent<CardSystem>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            orbTrigger1 = true;
            if (orbTrigger1)
            {
                cardScript.versionControl = 1;
                gameObject.SetActive(false);
            }
            else if (!orbTrigger1)
            {
                cardScript.versionControl = 6;
                gameObject.SetActive(false);
            }
        }
    }
}
