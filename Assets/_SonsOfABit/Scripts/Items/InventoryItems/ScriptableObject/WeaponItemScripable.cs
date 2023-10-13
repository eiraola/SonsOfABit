using UnityEngine;
[CreateAssetMenu(fileName = "WeaponItem", menuName = "Items/Weapon", order = 1)]

public class WeaponItemScripable : ItemScriptable
{
    [Tooltip("The Weapon prefab that will be equiped")]
    public Weapon ItemToEquip;
    [Tooltip("The value of the item")]
    public float weaponValue;
    [Tooltip("The Damage per second that the weapon will do")]
    public float dps;

    public override Item GetItem()
    {
        ItemWeapon weaponInstance = new ItemWeapon(itemName, weight, itemType, itemVisual, dps, weaponValue, ItemToEquip);
        return weaponInstance;
    }
}
