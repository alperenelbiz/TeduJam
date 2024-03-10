using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour
{
  public AudioSource audioSource;
    public GameObject canvas;
    int flag=0;

    private void Update()
    {
        if (canvas.active && flag==1 )
        { 
            audioSource.Play();
            Debug.Log('a');
        }

        else if (canvas.active)
        {
            Debug.Log('b');
            flag = 1;
        }
    }
}
