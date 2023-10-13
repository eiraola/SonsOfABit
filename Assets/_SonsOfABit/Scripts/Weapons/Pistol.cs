using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField]
    [Tooltip("The ammo prefab that the weapon is going to use")]
    private Projectile ammo;
    /// <summary>
    /// Uses the current weapon if it is some ammo in the inventory
    /// </summary>
    public override void UseWeapon()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            return;
        }
        Inventory inventory = player.GetComponent<Inventory>();
        if (!inventory)
        {
            return;
        }
        if (inventory.GetAmmo())
        {
            Instantiate(ammo, transform.position, transform.rotation);
        }
    }
}
