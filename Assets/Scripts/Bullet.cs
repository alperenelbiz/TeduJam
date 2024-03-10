using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public int ammoDamage = 20;
    

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider collision)
    {
        /*if (!collided)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collided = false;
            }
            else
            {
                collided = true;
                Destroy(gameObject);
            }
        
        }*/
           
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(ammoDamage);
            
            //collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(gameObject);
            
        }

    }
}