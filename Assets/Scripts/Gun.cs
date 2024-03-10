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
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public float bulletSpeed = 10f;
    public int pelletsPerShot = 8; // Her atýþta kaç adet mermi ateþleneceði
    public float spreadAngle = 10f; // Mermilerin yayýlma açýsý
    float fireRate = 1f; // Atýþ hýzý
    public float ReloadRate = 5f;
    public int maxAmmo = 8;
    public int currentAmmo;
    private bool isAttacked=false;

    public ParticleSystem gun1muzzleFlash1;
    public ParticleSystem gun2muzzleFlash1;
    public ParticleSystem gun2muzzleFlash2;
    public ParticleSystem gun3muzzleFlash1;
    public ParticleSystem gun3muzzleFlash2;
    public ParticleSystem gun3muzzleFlash3;

    private AudioSource audio;

    public int currentLevel;
    

    void Start()
    { 
        currentAmmo = maxAmmo;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacked)
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
            
            
        }
    }

    void Fire()
    {
        if (currentAmmo > 0)
        {
            if (currentLevel == 1)
            {
                fireRate = 10f;
                gun1.SetActive(true);
                gun2.SetActive(false);
                gun3.SetActive(false);
                for (int i = 0; i < bulletSpawnPoints_level1.Length; i++)
                {
                    // bulletSpawnPoints[i] deðerini kontrol et
                    if (bulletSpawnPoints_level1[i] != null)
                    {
                            isAttacked = true;
                        // spreadRotation deðiþkenini tanýmla
                            gun1muzzleFlash1.Play();
                            Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f);
                            var bullet1 = Instantiate(bulletPrefab, bulletSpawnPoints_level1[i].position, bulletSpawnPoints_level1[i].rotation * spreadRotation);
                            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * bulletSpeed;
                        audio.PlayOneShot(audio.clip);
                            StartCoroutine(FireDelay(10f/fireRate));
                            

                    }
                    
                }
                

            }
            else if(currentLevel == 2)
            {
                fireRate = 15f;
                gun1.SetActive(false);
                gun2.SetActive(true);
                gun3.SetActive(false);

                for (int i = 0; i < bulletSpawnPoints_level2.Length; i++)
                {
                    // bulletSpawnPoints[i] deðerini kontrol et
                    if (bulletSpawnPoints_level2[i] != null)
                    {
                        gun2muzzleFlash1.Play();
                        gun2muzzleFlash2.Play();
                        // spreadRotation deðiþkenini tanýmla
                        Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f);

                        var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoints_level2[i].position, bulletSpawnPoints_level2[i].rotation * spreadRotation);
                        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * bulletSpeed;
                        StartCoroutine(FireDelay(10f / fireRate));
                    }
                }
            }
            else if(currentLevel == 3)
            {
                fireRate = 20f;
                gun1.SetActive(false);
                gun2.SetActive(false);
                gun3.SetActive(true);
                for (int i = 0; i < bulletSpawnPoints_level3.Length; i++)
                {
                    // bulletSpawnPoints[i] deðerini kontrol et
                    if (bulletSpawnPoints_level3[i] != null)
                    {
                        gun3muzzleFlash1.Play();
                        gun3muzzleFlash2.Play();
                        gun3muzzleFlash3.Play();
                        // spreadRotation deðiþkenini tanýmla
                        Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f);

                        var bullet = Instantiate(bulletPrefab, bulletSpawnPoints_level3[i].position, bulletSpawnPoints_level3[i].rotation * spreadRotation);
                        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
                        StartCoroutine(FireDelay(10f / fireRate));
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
        isAttacked = false;
    }

    IEnumerator ReloadWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        currentAmmo = maxAmmo;
    }
}
