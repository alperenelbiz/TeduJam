using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FatherMove : MonoBehaviour
{
    MoveToScreen moveScript;
    public float delayTime;
    public GameObject nesne1;
    public GameObject nesne2;
    public GameObject ui;

    private void Start()
    {
        StartCoroutine(Movement());
    }
    private void Update()
    {
        
    }

    IEnumerator Movement()
    {
        ui.SetActive(false);
        Debug.Log("basladi");
        moveScript = GameObject.Find("UIController").GetComponent<MoveToScreen>();
        while(true) 
        {
            if (moveScript.HedefeHareketEt(nesne1))
            {
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(delayTime);
        while (true)
        {
            if (moveScript.HedefeHareketEt(nesne2))
            {
                break;
            }
            yield return null;
        }
        ui.SetActive(true);
        Debug.Log("bitti");
    }
}
