using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /*
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject Gun3;

    public GameObject cylinderObject;
    */

    public Transform[] bulletSpawnPoints_level1; // Birden fazla ateþleme noktasý
    public Transform[] bulletSpawnPoints_level2;
    public Transform[] bulletSpawnPoints_level3;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int pelletsPerShot = 8; // Her atýþta kaç adet mermi ateþleneceði
    public float spreadAngle = 20f; // Mermilerin yayýlma açýsý
    public float fireRate = 1f; // Atýþ hýzý
    public float ReloadRate = 5f;
    public int maxAmmo = 8;
    public int currentAmmo;

    public int currentLevel;
    

    void Start()
    { 
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*
            if (currentLevel == 1)
            {
                Instantiate(Gun1, cylinderObject.transform.position, cylinderObject.transform.rotation, cylinderObject.transform);
            }
            else if (currentLevel == 2)
            {
                Instantiate(Gun2, cylinderObject.transform.position, cylinderObject.transform.rotation, cylinderObject.transform);
            }
            else if (currentLevel == 3)
            {
                Instantiate(Gun3, cylinderObject.transform.position, cylinderObject.transform.rotation, cylinderObject.transform);
            }
            */
            Fire(); 
            StartCoroutine(FireDelay(fireRate));
        }
    }

    void Fire()
    {
        if (currentAmmo > 0)
        {
            if (currentLevel == 1)
            {

                for (int i = 0; i < bulletSpawnPoints_level1.Length; i++)
                {
                    // bulletSpawnPoints[i] deðerini kontrol et
                    if (bulletSpawnPoints_level1[i] != null)
                    {
                        // spreadRotation deðiþkenini tanýmla
                        Quaternion spreadRotation = Quaternion.Euler(0f, Random.Range(-spreadAngle, spreadAngle), 0f);
                        
                        var bullet1 = Instantiate(bulletPrefab, bulletSpawnPoints_level1[i].position, bulletSpawnPoints_level1[i].rotation * spreadRotation);
                        bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * bulletSpeed;
                        StartCoroutine(FireDelay(fireRate/10f));

                    }
                    
                }
                

            }
            else if(currentLevel == 2)
            {
                for (int i = 0; i < bulletSpawnPoints_level2.Length; i++)
                {
                    // bulletSpawnPoints[i] deðerini kontrol et
                    if (bulletSpawnPoints_level2[i] != null)
                    {
                        // spreadRotation deðiþkenini tanýmla
                        Quaternion spreadRotation = Quaternion.Euler(0f, Random.Range(-spreadAngle, spreadAngle), 0f);

                        var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoints_level2[i].position, bulletSpawnPoints_level2[i].rotation * spreadRotation);
                        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * bulletSpeed;
                        StartCoroutine(FireDelay(fireRate));
                    }
                }
            }
            else
            {
                for (int i = 0; i < bulletSpawnPoints_level3.Length; i++)
                {
                    // bulletSpawnPoints[i] deðerini kontrol et
                    if (bulletSpawnPoints_level3[i] != null)
                    {
                        // spreadRotation deðiþkenini tanýmla
                        Quaternion spreadRotation = Quaternion.Euler(0f, Random.Range(-spreadAngle, spreadAngle), 0f);

                        var bullet = Instantiate(bulletPrefab, bulletSpawnPoints_level3[i].position, bulletSpawnPoints_level3[i].rotation * spreadRotation);
                        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
                        StartCoroutine(FireDelay(fireRate));
                    }
                }
            }

            currentAmmo--;
            
        }
        else
        {
            StartCoroutine(ReloadWithDelay(10f / ReloadRate));
        }
    }

    IEnumerator FireDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }

    IEnumerator ReloadWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        currentAmmo = maxAmmo;
    }
}
