using UnityEngine;
[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Items/BluePotion", order = 1)]
public class BluePotionItemScriptable : ItemScriptable
{
    [Tooltip("The time the item will take to rott")]
    public float timeToRot;
    public override Item GetItem()
    {
        BluePotion consumableInstance = new BluePotion(itemName,weight,itemType,itemVisual, timeToRot);
        return consumableInstance;
    }
}
