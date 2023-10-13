using UnityEngine;
/// <summary>
/// An enum type to set the different item types
/// </summary>
public enum EItemType
{
    None,
    Weapon,
    Consumible,
    Resource,
    Trash
}
[System.Serializable]
//A base class that will be use as a base for the rest of the items
public abstract class Item
{
    public float weight = 0.0f;
    protected string itemName = "";
    protected EItemType itemType = EItemType.None;
    protected Sprite itemVisual;
    public Item(string name, float weight, EItemType itemType, Sprite itemVisual )
    {
        this.itemName = name;
        this.weight = weight;
        this.itemType = itemType;
        this.itemVisual = itemVisual;
    }

    public Sprite ItemVisual { get => itemVisual;}
    /// <summary>
    /// Returns a string to be peint in the inventory with all the item data
    /// </summary>
    /// <returns>A string with all the item data</returns>
    public virtual string GetData()
    {
        return $"Name: {itemName} \n Weigth: {weight} \n";
    }
    /// <summary>
    /// A function to be called from an update function, so the items can be updated over time without inheriting from MonoBehaviour
    /// </summary>
    public abstract void OnUpdate();
    /// <summary>
    /// A to declare de functionality of each different item.
    /// </summary>
    public abstract void UseItem();
}
