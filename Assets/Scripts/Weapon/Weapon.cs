using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Ammo ammo;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Camera FPSCamera;
    [SerializeField] GameObject hitImpact;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float shotDelay = 0.5f;

    bool canShoot = true;

    private void Start()
    {
        ammo = FindObjectOfType<Ammo>();    
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy == null) return;
            enemy.TakeDamage(damage);
        }
        else return;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.GetCurrentAmmo(ammoType) > 0)
        {
            muzzleFlash.Play();
            ProcessRaycast();
            ammo.ReduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }
}