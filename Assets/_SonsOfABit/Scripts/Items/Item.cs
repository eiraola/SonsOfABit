using UnityEngine;

public enum EItemType
{
    None,
    Weapon,
    Consumible,
    Resource,
    Trash
}
public abstract class Item 
{
    [SerializeField]
    protected string itemName = "";
    [SerializeField]
    protected float weight = 0.0f;
    protected EItemType itemType = EItemType.None;
    public virtual string GetData()
    {
        return $"Name: {itemName} \n Weigth: {weight} \n";
    }
    public abstract void OnUpdate();
    public abstract void UseItem();
}
