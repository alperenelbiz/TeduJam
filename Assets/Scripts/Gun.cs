using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{    
    public Transform[] bulletSpawnPoints; // Birden fazla ateþleme noktasý
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int pelletsPerShot = 8; // Her atýþta kaç adet mermi ateþleneceði
    public float spreadAngle = 20f; // Mermilerin yayýlma açýsý
    public float fireRate = 1f; // Atýþ hýzý
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
                // bulletSpawnPoints[i] deðerini kontrol et
                if (bulletSpawnPoints[i] != null)
                {
                    // spreadRotation deðiþkenini tanýmla
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
