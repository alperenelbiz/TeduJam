using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSystem : MonoBehaviour
{
    public TMP_Text EventChoice1;
    public TMP_Text EventChoice2;
    public GameObject pauseMenu;
    public GameObject crosshair;
    public bool gamePaused = false;
    Gun gunScript = FindObjectOfType<Gun>();
    PlayerMovement movementScript = FindObjectOfType<PlayerMovement>();

    public void Start()
    {
        Gun gunScript = FindObjectOfType<Gun>();
        PlayerMovement movementScript = FindObjectOfType<PlayerMovement>();
    }
    public void Choices1()
    {
        EventChoice1.text = "+silah seviyesi ama dusmanlarin saldiri hizi +%10";
        EventChoice2.text = "dusmanlarin verdigi hasar -%10 ama oyuncu kosma hizi -%10";
    }
    public void Choices2()
    {
        EventChoice1.text = "oyuncu -%5 can ama mermi basina hasar +%10";
        EventChoice2.text = "dusmanlarin verdigi hasar +%10 ama dusman saldiri hizi +%10";
    }
    public void Choices3()
    {
        EventChoice1.text = "+silah seviyesi ama dusman kosma hizi +%10";
        EventChoice2.text = "-silah seviyesi ama mermi basina +%10 hasar";
    }
    public void Choices4()
    {
        EventChoice1.text = "+silah seviyesi ama oyuncu kosma hizi -%10";
        EventChoice2.text = "dusman kosma hizi -%10 ama oyuncunun mermi basina verdigi hasar -%10";
    }
    public void Choices5()
    {
        if (gunScript.currentLevel == 1 || gunScript.currentLevel == 2)
        {
            EventChoice1.text = "+silah seviyesi ama dusmanlarin verdiði hasar +%10";
            EventChoice2.text = "+silah seviyesi ama dusman kosma hizi +%15";
        }
        else
        {
            EventChoice1.text = "-silah seviyesi ama dusmanlarin verdiði hasar -%10";
            EventChoice2.text = "dusman kosma hizi -%10 ama dusman saldiri hizi +%10";
        }
    }
    public void ChoiceMenuOn1()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        Choices1();
    }
    public void Menu1Button1()
    {
        //dusmanlarýn saldiri hizi +%10
        gunScript.currentLevel = 2;
    }
    public void Menu1Button2()
    {
        //dusmanlarýn saldiri hasari -%10
        movementScript.moveSpeed *= 0.9f;
    }
    public void ChoiceMenuOn2()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        Choices2();
    }
    public void Menu2Button1()
    {
        //player health -%5
        //+%10 damage per bullet
    }
    public void Menu2Button2()
    {
        //dusman kosma hizi -%10
        //dusman saldiri hizi +%10
    }
    public void ChoiceMenuOn3()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        Choices3();
    }
    public void Menu3Button1()
    {
        gunScript.currentLevel += 1;
        //dusman kosma hizi +%10
    }
    public void Menu3Button2()
    {
        //dusmanlarin verdiði hasar +%10
        //mermi basina +%10 hasar
    }
    public void ChoiceMenuOn4()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        Choices4();
    }
    public void Menu4Button1()
    {
        gunScript.currentLevel += 1;
        //oyuncu kosma hizi -%10
    }
    public void Menu4Button2()
    {
        //dusmanlarýn kosma hizi -%10
        //mermi basina -%10 hasar
    }
    public void ChoiceMenuOn5()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        Choices5();
    }
    public void Menu5Button1()
    {
       //burasi kaldi
    }
    public void Menu5Button2()
    {
        //burasi kaldi
    }
    public void ChoiceMenuOff()
    {
        pauseMenu.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChoiceMenuOn1();
        }
    }
}
