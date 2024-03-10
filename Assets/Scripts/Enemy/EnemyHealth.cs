using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
   /* public Image HealthBar;
    public GameObject canvas;*/
    public static float healthValue = 1f;
    public int dedcount;
   
    Spawner spawner;
    Event event0;
    void Start()
    {
        maxHealth = maxHealth * healthValue;
        currentHealth = maxHealth;
        UpdateHealthBar();
        
    }

    private void Update()
    {
        //canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - Camera.main.transform.position);
        Debug.Log(dedcount);
    }
    public void takeDamage(float amount)
    {
        currentHealth -= amount;
       
        if (currentHealth <= 0)
        {
            
            currentHealth = 0;
            Die();
            
        }

        UpdateHealthBar();

    }

    private void UpdateHealthBar()
    {
        float fill = (float)currentHealth / maxHealth;
        //HealthBar.fillAmount = fill;
    }

    public void Die()
    {   
        Destroy(gameObject);
        dedcount++;
    }
    public void HealthIncrease(float x)
    {
        healthValue = healthValue + x;
    }
}
