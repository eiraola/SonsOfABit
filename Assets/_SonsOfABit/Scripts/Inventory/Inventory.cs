using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int maxSlots = 8;
    private List<Item> inventorySlots = new List<Item>();

    void Start()
    {

    }
    void Update()
    {
        PassTime();
    }
    public bool AddItem(Item newItem)
    {
        if (inventorySlots.Count <= maxSlots)
        {
            return false;
        }
        inventorySlots.Add(newItem);
        return true;
    }
    public bool DelteItem(Item newItem)
    {
        if (inventorySlots.Contains(newItem))
        {
            inventorySlots.Remove(newItem);
            return true;
        }
        return false;
    }
    public void PassTime()
    {
        foreach (Item item in inventorySlots)
        {
            item.OnUpdate();
        }
    }
    

}
