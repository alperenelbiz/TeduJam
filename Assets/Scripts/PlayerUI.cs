using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
     int ammo;
     int health;

    [SerializeField] TextMeshPro ammoText;
    [SerializeField] TextMeshPro healthText;


    private void Awake()
    {
        ammo = GetComponent<Gun>().currentAmmo;
        health = GetComponent<PlayerHealth>().currentHealth;
    }

    private void Update()
    {
        ammoText.SetText(ammo.ToString());
        healthText.SetText(health.ToString());
    }
}
