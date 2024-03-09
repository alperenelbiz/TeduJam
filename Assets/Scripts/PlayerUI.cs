using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Gun gun;
    public TextMeshProUGUI ammoText;

    [SerializeField] Slider Slider;
    [SerializeField] Image Image;

    private void Update()
    {
        ammoText.text = gun.currentAmmo.ToString();
        Slider.maxValue = playerHealth.maxHealth;
        Slider.value = playerHealth.currentHealth;
    }
}
