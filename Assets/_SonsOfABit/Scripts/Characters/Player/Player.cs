using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The transform where weapons will be attached.")]
    private Transform weaponSlot;
    [SerializeField]
    [Tooltip("An input asset to bind functions to inputs")]
    private PlayerInputAsset playerInputAsset;
    private Weapon currentWeapon;
    private void OnEnable()
    {
        playerInputAsset.ShootEvent += Shoot;
    }
    /// <summary>
    /// If a weapon is equiped it will shoot.
    /// </summary>
    private void Shoot()
    {
        if (currentWeapon)
        {
            currentWeapon.UseWeapon();
        }
    }
    /// <summary>
    /// It will equip "newWeapon" in the player's weaponSlot.
    /// </summary>
    /// <param name="newWeapon"></param>
    public void EquipWeapon(Weapon newWeapon)
    {
        //Destroying the current equiped weapont is not the most efficient way to do this, but I was not prioritizing this part of the game right now.
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeaponInstance = Instantiate(newWeapon, weaponSlot.position, weaponSlot.rotation);
        newWeaponInstance.transform.parent = weaponSlot;
        currentWeapon = newWeaponInstance;
    }

}
