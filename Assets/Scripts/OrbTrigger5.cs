using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger5 : MonoBehaviour
{
    [SerializeField] public bool orbTrigger5 = false;
    CardSystem cardScript;
    public GameObject orb5;

    public void Start()
    {
        cardScript = GameObject.Find("UIController").GetComponent<CardSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            orbTrigger5 = true;
            if (orbTrigger5)
            {
                cardScript.versionControl = 5;
                gameObject.SetActive(false);
            }
            else if (!orbTrigger5)
            {
                cardScript.versionControl = 6;
                gameObject.SetActive(false);
            }
        }
    }
}
