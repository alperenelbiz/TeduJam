using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{    
    public Transform[] bulletSpawnPoints; // Birden fazla ate�leme noktas�
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int pelletsPerShot = 8; // Her at��ta ka� adet mermi ate�lenece�i
    public float spreadAngle = 20f; // Mermilerin yay�lma a��s�
    public float fireRate = 1f; // At�� h�z�
    public int maxAmmo = 8;
    public int currentAmmo;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (currentAmmo > 0)
        {
            for (int i = 0; i < bulletSpawnPoints.Length; i++)
            {
                // bulletSpawnPoints[i] de�erini kontrol et
                if (bulletSpawnPoints[i] != null)
                {
                    // spreadRotation de�i�kenini tan�mla
                    Quaternion spreadRotation = Quaternion.Euler(0f, Random.Range(-spreadAngle, spreadAngle), 0f);

                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoints[i].position, bulletSpawnPoints[i].rotation * spreadRotation);
                    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
                }
            }
            
            currentAmmo--;
            
        }
        else
        {
            StartCoroutine(ReloadWithDelay(25f / fireRate));
        }
    }

    IEnumerator ReloadWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        currentAmmo = maxAmmo;
    }
}
