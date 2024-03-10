using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSystem : MonoBehaviour
{
    public TMP_Text Event1Choice1;
    public TMP_Text Event1Choice2;
    public TMP_Text Event2Choice1;
    public TMP_Text Event2Choice2;
    public TMP_Text Event3Choice1;
    public TMP_Text Event3Choice2;
    public TMP_Text Event4Choice1;
    public TMP_Text Event4Choice2;
    public TMP_Text Event5Choice1;
    public TMP_Text Event5Choice2;
    public GameObject pauseMenu;
    public GameObject crosshair;
    public bool gamePaused = false;
    public int versionControl;
    public GameObject menu1button1;
    public GameObject menu1button2;
    public GameObject menu2button1;
    public GameObject menu2button2;
    public GameObject menu3button1;
    public GameObject menu3button2;
    public GameObject menu4button1;
    public GameObject menu4button2;
    public GameObject menu5button1;
    public GameObject menu5button2;

    Gun gunScript;
    PlayerHealth playerHealth;
    PlayerMovement movementScript;
    Enemy enemyScript;
    EnemyBullet enemyBulletScript;
    Bullet bullet;
    OrbTrigger orbTrig;

    public void Start()
    {
        gunScript = GameObject.Find("Player / Camera / Main Camera").GetComponent<Gun>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        movementScript = GameObject.Find("Player / FirstPersonCharacter").GetComponent<PlayerMovement>();
        enemyScript = GameObject.Find("Eye").GetComponent<Enemy>();
        enemyBulletScript = GameObject.Find("Fireball").GetComponent<EnemyBullet>();
        bullet = GameObject.Find("Bullet").GetComponent<Bullet>();
        orbTrig = GameObject.Find("Orb1").GetComponent<OrbTrigger>();
    }
    public void Choices1()
    {
        Event1Choice1.text = "oyuncu -%5 can ama mermi basina hasar +%10";
        Event1Choice2.text = "dusmanlarin verdigi hasar +%10 ama dusman saldiri hizi +%10";
    }
    public void Choices2()
    {
        Event2Choice1.text = "+silah seviyesi ama dusmanlarin saldiri hizi +%10";
        Event2Choice2.text = "dusmanlarin verdigi hasar -%10 ama oyuncu kosma hizi -%10";
    }
    public void Choices3()
    {
        Event3Choice1.text = "+silah seviyesi ama dusman kosma hizi +%10";
        Event3Choice2.text = "+silah seviyesi ama mermi basina -%10 hasar";
    }
    public void Choices4()
    {
        Event4Choice1.text = "dusman kosma hizi -%15 ama oyuncu kosma hizi -%10";
        Event4Choice2.text = "dusman kosma hizi -%10 ama oyuncunun mermi basina verdigi hasar -%10";
    }
    public void Choices5()
    {
        Event5Choice1.text = "+silah seviyesi ama dusmanlarin verdigi hasar +%10";
        Event5Choice2.text = "+silah seviyesi ama dusman kosma hizi +%15";
    }
    public void ChoiceMenuOn1()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        menu1button1.SetActive(true);
        menu1button2.SetActive(true);
        menu2button1.SetActive(false);
        menu2button2.SetActive(false);
        menu3button1.SetActive(false);
        menu3button2.SetActive(false);
        menu4button1.SetActive(false);
        menu4button2.SetActive(false);
        menu5button1.SetActive(false);
        menu5button2.SetActive(false);
        Choices1();
    }
    public void Menu1Button1()
    {
        //player health -%5
        playerHealth.maxHealth -= (playerHealth.maxHealth * 5) / 100;
        //+%10 damage per bullet
        bullet.ammoDamage += (bullet.ammoDamage * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void Menu1Button2()
    {
        //dusmanlarýn saldiri hasari -%10
        enemyScript.attackDamage += (enemyScript.attackDamage* 10) / 100;
        enemyBulletScript.ammoDamage += (enemyBulletScript.ammoDamage * 10) / 100;
        enemyScript.moveSpeed += (enemyScript.moveSpeed * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void ChoiceMenuOn2()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        menu1button1.SetActive(false);
        menu1button2.SetActive(false);
        menu2button1.SetActive(true);
        menu2button2.SetActive(true);
        menu3button1.SetActive(false);
        menu3button2.SetActive(false);
        menu4button1.SetActive(false);
        menu4button2.SetActive(false);
        menu5button1.SetActive(false);
        menu5button2.SetActive(false);
        Choices2();
    }
    public void Menu2Button1()
    {
        enemyScript.moveSpeed += (enemyScript.moveSpeed * 10) / 100;
        gunScript.currentLevel += 1;
        orbTrig.orbTrigger1 = false;
    }
    public void Menu2Button2()
    {
        enemyScript.attackDamage -= (enemyScript.attackDamage * 10) / 100;
        enemyBulletScript.ammoDamage -= (enemyBulletScript.ammoDamage * 10) / 100;
        movementScript.moveSpeed -= (movementScript.moveSpeed * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void ChoiceMenuOn3()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        menu1button1.SetActive(false);
        menu1button2.SetActive(false);
        menu2button1.SetActive(false);
        menu2button2.SetActive(false);
        menu3button1.SetActive(true);
        menu3button2.SetActive(true);
        menu4button1.SetActive(false);
        menu4button2.SetActive(false);
        menu5button1.SetActive(false);
        menu5button2.SetActive(false);
        Choices3();
    }
    public void Menu3Button1()
    {
        gunScript.currentLevel += 1;
        //dusman kosma hizi +%10
        enemyScript.moveSpeed += (enemyScript.moveSpeed * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void Menu3Button2()
    {
        //dusmanlarin verdiði hasar +%10
        gunScript.currentLevel += 1;
        //mermi basina +%10 hasar
        bullet.ammoDamage -= (bullet.ammoDamage * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void ChoiceMenuOn4()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        menu1button1.SetActive(false);
        menu1button2.SetActive(false);
        menu2button1.SetActive(false);
        menu2button2.SetActive(false);
        menu3button1.SetActive(false);
        menu3button2.SetActive(false);
        menu4button1.SetActive(true);
        menu4button2.SetActive(true);
        menu5button1.SetActive(false);
        menu5button2.SetActive(false);
        Choices4();
    }
    public void Menu4Button1()
    {
        enemyScript.moveSpeed -= (enemyScript.moveSpeed * 15) / 100;
        //oyuncu kosma hizi -%10
        movementScript.moveSpeed-= (movementScript.moveSpeed * 10)/100;
        orbTrig.orbTrigger1 = false;
    }
    public void Menu4Button2()
    {
        //dusmanlarýn kosma hizi -%10
        enemyScript.moveSpeed -= (enemyScript.moveSpeed * 10) / 100;
        //mermi basina -%10 hasar
        bullet.ammoDamage -= (bullet.ammoDamage * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void ChoiceMenuOn5()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        menu1button1.SetActive(false);
        menu1button2.SetActive(false);
        menu2button1.SetActive(false);
        menu2button2.SetActive(false);
        menu3button1.SetActive(false);
        menu3button2.SetActive(false);
        menu4button1.SetActive(false);
        menu4button2.SetActive(false);
        menu5button1.SetActive(true);
        menu5button2.SetActive(true);
        Choices5();
    }
    public void Menu5Button1()
    {
        gunScript.currentLevel += 1;
        enemyScript.attackDamage += (enemyScript.attackDamage * 10) / 100;
        enemyBulletScript.ammoDamage += (enemyBulletScript.ammoDamage * 10) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void Menu5Button2()
    {
        gunScript.currentLevel += 1;
        enemyScript.moveSpeed += (enemyScript.moveSpeed * 15) / 100;
        orbTrig.orbTrigger1 = false;
    }
    public void ChoiceMenuOff()
    {
        pauseMenu.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gamePaused = false;
        Time.timeScale = 1f;
    }
    public void FixedUpdate()
    {
        if (versionControl == 1)
        {
            ChoiceMenuOn1();
        }
        else if (versionControl == 2)
        {
            ChoiceMenuOn2();
        }
        else if (versionControl == 3)
        {
            ChoiceMenuOn3();
        }
        else if (versionControl == 4)
        {
            ChoiceMenuOn4();
        }
        else if (versionControl == 5)
        {
            ChoiceMenuOn5();
        }
        else if (versionControl == 6)
        {
            ChoiceMenuOff();
        }
    }
}
