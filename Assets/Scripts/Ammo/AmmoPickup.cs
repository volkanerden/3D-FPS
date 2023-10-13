using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int addAmount = 5;
    [SerializeField] AmmoType type;
    Ammo ammo;

    private void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ammo.IncreaseAmmo(type, addAmount);
            Destroy(gameObject);
        }
    }
}
