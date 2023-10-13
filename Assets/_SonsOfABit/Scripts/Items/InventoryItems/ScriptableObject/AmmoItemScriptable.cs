using UnityEngine;
[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Items/Ammo", order = 1)]
public class AmmoItemScriptable : ItemScriptable
{
    [Tooltip("The time the item will end up rotting")]
    public float timeToRot;
    [Tooltip("The value of the item")]
    public float value;
    public override Item GetItem()
    {
        Ammo consumableInstance = new Ammo(itemName,weight,itemType,itemVisual, timeToRot, value);
        return consumableInstance;
    }
}
