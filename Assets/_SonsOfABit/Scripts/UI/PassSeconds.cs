using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassSeconds : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private float timeToPass = 30.0f;

    public void MakeTimeForward()
    {
        foreach (Item item in inventory.InventorySlots)
        {
            if (item is RottableItem)
            {
                ((RottableItem)item).PassTime(timeToPass);
            }
        }
    }
}
