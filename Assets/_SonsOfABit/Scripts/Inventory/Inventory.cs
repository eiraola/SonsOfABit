using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class OnInventoryUpdatedEvent : UnityEvent<List<Item>> { }
public class Inventory : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The number of slots available in the inventory")]
    private int maxSlots = 8;
    [SerializeField]
    [Tooltip("The maximum weight that the inventory can support")]
    private float maxWeight = 30;
    [SerializeField]
    [Tooltip("A event that will be launch every time we need to update the inventory UI")]
    public OnInventoryUpdatedEvent onInventoryUpdated = new OnInventoryUpdatedEvent();
    private List<Item> inventorySlots = new List<Item>();
    public float CurrentWeight { 
        get
        {
            float currentWeight = 0.0f;
            foreach (Item item in InventorySlots)
            {
                currentWeight += item.weight;
            }
            return currentWeight;
        } 
    }
    public List<Item> InventorySlots { get => inventorySlots;}
    public float MaxWeight { get => maxWeight;}

    void Update()
    {
        PassTime();
    }
    /// <summary>
    /// It will add a new Item to the inventory if it is possible. 
    /// </summary>
    /// <param name="newItem">The item that will be added to the inventory</param>
    /// <returns>True if the item was succesfuly added, or false if it was not possible</returns>
    public bool AddItem(Item newItem)
    {
        if ((newItem.weight + CurrentWeight) > MaxWeight)
        {
            return false;
        }
        if ((InventorySlots.Count) >= maxSlots)
        {
            return false;
        }
        InventorySlots.Add(newItem);
        onInventoryUpdated?.Invoke(InventorySlots);
        return true;
    }
    /// <summary>
    /// Removes an item from the inventory
    /// </summary>
    /// <param name="newItem">The item that is going to be removed</param>
    /// <returns>True if the item was removed, false if it wasnt possible</returns>
    public bool RemoveItem(Item newItem)
    {
        if (InventorySlots.Contains(newItem))
        {
            InventorySlots.Remove(newItem);
            onInventoryUpdated?.Invoke(InventorySlots);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Makes the time pass for all the items in the inventory
    /// </summary>
    public void PassTime()
    {
        foreach (Item item in InventorySlots)
        {
            item.OnUpdate();
        }
    }
    /// <summary>
    /// It will add an item to the inventory if we collide with an item container
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ItemContainer>(out ItemContainer itemContainer))
        {
            Item newItem = itemContainer.GetItem();
           if (AddItem(newItem))
           {
                Destroy(other.gameObject);
           }
        }
    }
    /// <summary>
    /// Checks if there is ammo for a certain weapon (since there is just a pistol in this game, we didnt create different ammo types).
    /// </summary>
    /// <returns>True if the ammo was found, false if it istn (It also deletes the item from the inventory)</returns>
    public bool GetAmmo()
    {
        Item ammoItem = InventorySlots.Find(x => (x is Ammo));
        if (ammoItem != null && (ammoItem is Ammo))
        {
            RemoveItem(ammoItem);
            return true;
        }
        return false;
    }
}
