using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
     int ammo;
     int health;

    [SerializeField] TextMeshProUGUI ammoText;
    //[SerializeField] TextMeshPro healthText;


    private void Awake()
    {
        ammo = GetComponent<Gun>().currentAmmo;
      //  health = GetComponent<PlayerHealth>().currentHealth;
    }

    private void Update()
    {

    }
}
