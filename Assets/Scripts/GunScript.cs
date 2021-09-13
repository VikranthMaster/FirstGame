using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public int damage = 10;
    public int range = 10;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading....");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {

        currentAmmo--;

       RaycastHit hit;
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //range is optional
       {
           Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
           if (target != null)
           {
               target.TakeDamage(damage);
           }
       }
    }
}
