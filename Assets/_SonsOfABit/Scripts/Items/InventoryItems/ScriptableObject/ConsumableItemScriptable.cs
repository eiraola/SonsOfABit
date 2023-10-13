using UnityEngine;
[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Items/Consumable", order = 1)]
public class ConsumableItemScriptable : ItemScriptable
{
    [Tooltip("The time the item will take to rott")]
    public float timeToRot;
    public override Item GetItem()
    {
        ItemConsumable consumableInstance = new ItemConsumable(itemName,weight,itemType,itemVisual, timeToRot);
        return consumableInstance;
    }
}
