using UnityEngine;
[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Items/RedPotion", order = 1)]
public class RedPotionItemScriptable : ItemScriptable
{
    [Tooltip("The time the item will take to rott")]
    public float timeToRot;
    public override Item GetItem()
    {
        RedPotion consumableInstance = new RedPotion(itemName,weight,itemType,itemVisual, timeToRot);
        return consumableInstance;
    }
}
