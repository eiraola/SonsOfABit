using UnityEngine;
[CreateAssetMenu(fileName = "ResourceItem", menuName = "Items/Resource", order = 1)]
public class ResourceItemScriptable : ItemScriptable
{
    [Tooltip("The value of the item")]
    public float value = 0.0f;
    [Tooltip("The time the item will take to rott")]
    public float timeToRot = 0.0f;
    public override Item GetItem()
    {
        ItemResource resourceInstance = new ItemResource(itemName, weight, itemType, itemVisual, timeToRot, value);
        return resourceInstance;
    }
}
