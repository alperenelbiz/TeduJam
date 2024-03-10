using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level01");
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted Game");
    }

    public void SettingsGame()
    {
        SceneManager.LoadScene("Settings");
    }
}
