using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger2 : MonoBehaviour
{
    [SerializeField] public bool orbTrigger2 = false;
    CardSystem cardScript;
    public GameObject orb2;

    public void Start()
    {
        cardScript = GameObject.Find("UIController").GetComponent<CardSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            orbTrigger2 = true;
            if (orbTrigger2)
            {
                cardScript.versionControl = 2;
                gameObject.SetActive(false);
            }
            else if (!orbTrigger2)
            {
                cardScript.versionControl = 6;
                gameObject.SetActive(false);
            }
        }
    }
}
