using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    //public Image HealthBar;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        ResetHealth();

    }

    private void Update()
    {
        UpdateHealthBar();
        _animator.SetInteger("Health", currentHealth);
    }


    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float fill = (float)currentHealth / maxHealth;
        //HealthBar.fillAmount = fill;
    }
    public void Die()
    {
        
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
}
