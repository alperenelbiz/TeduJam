using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : MonoBehaviour
{
    Transform cam;

    [Header("General Stats")]
    [SerializeField] float range = 50f;
    [SerializeField] float damage = 10f;

    [SerializeField] int maxAmmo;
    int currentAmmo;

    [SerializeField] float fireRate = 5f;
    [SerializeField] float reloadTime;
    WaitForSeconds reloadWait;

    [SerializeField] float inaccuracyDistance = 5f;

    [Header("Rapid Fire")]
    [SerializeField] bool rapidFire = false;
    WaitForSeconds rapidFireWait;

    [Header("Shotgun")]
    [SerializeField] bool shotgun = false;
    [SerializeField] int bulletsPerShot = 6;

    private void Awake()
    {
        cam = Camera.main.transform;
        rapidFireWait = new WaitForSeconds(1 / fireRate);
        reloadWait = new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
    }

    public void Shoot()
    {
        currentAmmo--;

        if (shotgun)
        {
            for(int i = 0; i < bulletsPerShot; i++)
            {
                RaycastHit hit;
                if(Physics.Raycast(cam.position, GetShootingDirection(), out hit, range))
                {
                    if(hit.collider.GetComponent<Damageable>() != null)
                    {
                        hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);
                    }
                }
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.position, GetShootingDirection(), out hit, range))
            {
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                    hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);
                }
            }
        }
    }

    public IEnumerator RapidFire()
    {
        if (CanShoot())
        {
            Shoot();
            if (rapidFire)
            {
                while (CanShoot())
                {
                    yield return rapidFireWait;
                    Shoot();
                }
                StartCoroutine(Reload());
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        if(currentAmmo == maxAmmo)
        {
            yield return null;
        }

        print("reloading...");
        yield return reloadWait;
        currentAmmo = maxAmmo;
        print("finished reloading");
    }

    bool CanShoot()
    {
        bool enoughAmmo = currentAmmo > 0;
        return enoughAmmo;
    }

    Vector3 GetShootingDirection()
    {
        Vector3 targetPos = cam.position + cam.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
            );
        Vector3 direction = targetPos - cam.position;
        return direction.normalized;


    }

}



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

*/
/*
public class Gun : MonoBehaviour
{
    public Transform spawnPoint;
    public float distance = 15f;

    public GameObject muzzle;
    public GameObject impact;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;
        RaycastHit hit_1;
        RaycastHit hit_2;
        RaycastHit hit_3;

        GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.localRotation);
        muzzleInstance.transform.parent = spawnPoint;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit_2, distance))
        {
            Instantiate(impact, hit_2.point, Quaternion.LookRotation(hit_2.normal));
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, .1f, 0f), out hit_3, distance))
        {
            Instantiate(impact, hit_3.point, Quaternion.LookRotation(hit_3.normal));
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit_2, distance))
        {
            Instantiate(impact, hit_2.point, Quaternion.LookRotation(hit.normal));
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -.1f, 0f), out hit_1, distance))
        {
            Instantiate(impact, hit_1.point, Quaternion.LookRotation(hit_1.normal));
        }
    }
}
*/

/*
public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;



    Transform cam;

    [Header("General Stats")]
    [SerializeField] float range = 50f;
    [SerializeField] float damage = 10f;

    [SerializeField] int maxAmmo;
    int currentAmmo;

    [SerializeField] float fireRate = 5f;
    [SerializeField] float reloadTime;
    WaitForSeconds reloadWait;

    [SerializeField] float inaccuracyDistance = 5f;

    [Header("Rapid Fire")]
    [SerializeField] bool rapidFire = false;
    WaitForSeconds rapidFireWait;

    [Header("Shotgun")]
    [SerializeField] bool shotgun = false;
    [SerializeField] int bulletsPerShot = 6;



    private void Awake()
    {
        cam = Camera.main.transform;
        rapidFireWait = new WaitForSeconds(1 / fireRate);
        reloadWait = new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("A");
            Shoot();
        }
    }
    public void Shoot()
    {
        currentAmmo--; // currentAmmo = currentAmmo - 1

        if (shotgun)
        {
            for (int i = 0; i < bulletsPerShot; i++)
            {
                RaycastHit hit;
                Vector3 shootingDir = GetShootingDirection();
                if (Physics.Raycast(cam.position, shootingDir, out hit, range))
                {
                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                    if (hit.collider.GetComponent<Damageable>() != null)
                    {
                        hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);
                    }

                }
            }
        }
        else
        {
            RaycastHit hit;
            Vector3 shootingDir = GetShootingDirection();
            if (Physics.Raycast(cam.position, shootingDir, out hit, range))
            {
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                    hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);
                }

            }

        }
    }

    public IEnumerator RapidFire()
    {
        if (CanShoot())
        {
            Shoot();
            if (rapidFire)
            {
                while (CanShoot())
                {
                    yield return rapidFireWait;
                    Shoot();
                }
                StartCoroutine(Reload());
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        if (currentAmmo == maxAmmo)
        {
            yield return null;
        }

        print("reloading...");
        yield return reloadWait;
        currentAmmo = maxAmmo;
        print("finished reloading");
    }

    bool CanShoot()
    {
        bool enoughAmmo = currentAmmo > 0;
        return enoughAmmo;
    }

    Vector3 GetShootingDirection()
    {
        Vector3 targetPos = cam.position + cam.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
            );

        Vector3 direction = targetPos - cam.position;
        return direction.normalized;
    }
}

/*
public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    //
    #region Datamembers

    #region Editor Settings

    [SerializeField] private LayerMask groundMask;

    #endregion
    #region Private Fields

    private Camera mainCamera;

    #endregion

    #endregion


    #region Methods

    #region Unity Callbacks
    //

    private void Start()
    {
        // Cache the camera, Camera.main is an expensive operation.
        mainCamera = Camera.main;
    }


    void Update()
    {

        Aim();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

    #endregion

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    #endregion

}
*/
