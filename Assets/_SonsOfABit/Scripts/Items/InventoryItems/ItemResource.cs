using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemResource : RottableItem
{
    private float value;
    public ItemResource (string name, float weight, EItemType itemType, Sprite itemVisual, float timeToRot, float value): base(name, weight, itemType, itemVisual, timeToRot)
    {
        this.value = value;
    }
    public override void UseItem()
    {
       //Resources have not (yet) usage
    }
    public override string GetData()
    {
        return base.GetData() + $"Value: {value} \n ";
    }
    /// <summary>
    /// The resources change to 0 value when they rott
    /// </summary>
    protected override void Rott()
    {
        this.value = 0.0f;
    }
}
