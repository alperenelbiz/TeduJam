using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger3 : MonoBehaviour
{
    [SerializeField] public bool orbTrigger3 = false;
    CardSystem cardScript;
    public GameObject orb3;

    public void Start()
    {
        cardScript = GameObject.Find("UIController").GetComponent<CardSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            orbTrigger3 = true;
            if (orbTrigger3)
            {
                cardScript.versionControl = 3;
                gameObject.SetActive(false);
            }
            else if (!orbTrigger3)
            {
                cardScript.versionControl = 6;
                gameObject.SetActive(false);
            }
        }
    }
}
