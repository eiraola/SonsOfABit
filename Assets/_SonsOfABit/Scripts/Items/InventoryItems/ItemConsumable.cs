using UnityEngine;

public class ItemConsumable : RottableItem
{
    public ItemConsumable(string name, float weight, EItemType itemType, Sprite itemVisual, float timeToRot) : base(name, weight, itemType, itemVisual, timeToRot) { 
        
    }

    public override void UseItem()
    {
        // A raw consumable object has no sense to have an use function ( probablilly this should be an abstract class)
    }
    public override string GetData()
    {

        if (itemType == EItemType.Trash)
        {
            return $"This is just trash \n Weight: {weight}";
        }
        return base.GetData();
    }
    /// <summary>
    /// The consumables become trash after rotting.
    /// </summary>
    protected override void Rott()
    {
        this.itemType = EItemType.Trash;
    }
}
