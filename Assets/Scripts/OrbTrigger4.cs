using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger4 : MonoBehaviour
{
    [SerializeField] public bool orbTrigger4 = false;
    CardSystem cardScript;
    public GameObject orb4;

    public void Start()
    {
        cardScript = GameObject.Find("UIController").GetComponent<CardSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            orbTrigger4 = true;
            if (orbTrigger4)
            {
                cardScript.versionControl = 4;
                gameObject.SetActive(false);
            }
            else if (!orbTrigger4)
            {
                cardScript.versionControl = 6;
                gameObject.SetActive(false);
            }
        }
    }
}
