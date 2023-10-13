using UnityEngine;

public abstract class ItemScriptable : ScriptableObject
{
    //This first value probabilly is not necessary since each class should have it initialized by default, but I put it just in case I find an special case.
    [Tooltip("The type of the item we are creating")]
    public EItemType itemType = EItemType.None;
    [Tooltip("The name of the item we will instantiate")]
    public string itemName = "Item name";
    [Tooltip("The weigth of the items")]
    public float weight = 0.0f;
    [Tooltip("A sprite that will be shown in the inventory")]
    public Sprite itemVisual;
    /// <summary>
    /// A function that creates an Item instance depending of the different subclasses
    /// </summary>
    /// <returns>An instance of the Item class</returns>
    public abstract Item GetItem();
}