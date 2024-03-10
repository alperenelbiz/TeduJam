using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using Cursor = UnityEngine.Cursor;


public class KartMekanik : MonoBehaviour
{
    public GameObject panel;
    public List<Text> texts = new List<Text>();
    public Camera mainCamera;
   public GameObject character;


    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("aaa");
        Cursor.visible = true;
        panel.SetActive(true);
        character.SetActive(false);
        if (collider.gameObject.CompareTag("Player"))
        {
         
        }
    }
    
    public void OnButtonClick()
    {
        // Paneli devre dýþý býrak
        panel.SetActive(false);

        // Birincil þahýs kamerasýna geri dön
        mainCamera.enabled = true;
        Cursor.visible = false;
        character.SetActive(true);
    }
}
