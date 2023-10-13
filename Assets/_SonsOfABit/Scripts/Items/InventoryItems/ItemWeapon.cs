using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeapon : Item
{
    private float dps = 0.0f;
    private float value = 0.0f;
    private Weapon itemToEquip;
    public ItemWeapon(string name, float weight, EItemType itemType, Sprite itemVisual, float dps, float value, Weapon itemToEquip) : base(name, weight, itemType, itemVisual)
    {
        this.dps = dps;
        this.value = value;
        this.itemToEquip = itemToEquip;
    }
    public override string GetData()
    {
        return base.GetData() + $"DPS: {dps} \n Value: {value} \n ";
    }

    public override void OnUpdate()
    {
       
    }

    public override void UseItem()
    {
        EquipWewapon();
    }
    /// <summary>
    /// This will make the player to equip the weapon that itemToEquip contains.
    /// </summary>
    private void EquipWewapon()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.EquipWeapon(itemToEquip);
    }
}
