using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : SellableItem
{
    public override string GetData()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
       
    }

    public override void UseItem()
    {
        EquipWewapon();
    }
    private void EquipWewapon()
    {

    }
}
