using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The panel that shows the weight")]
    private TextMeshProUGUI weigthPanel;
    [SerializeField]
    [Tooltip("The panel where the items information will be shown")]
    private TextMeshProUGUI textPanel;
    [SerializeField]
    [Tooltip("The grid that will contain all the elements in the inventory")]
    private GridLayoutGroup grid;
    [SerializeField]
    [Tooltip("The inventory that will be the UI reflecting")]
    private Inventory inventory;
    [SerializeField]
    [Tooltip("A slot prefab to be instanced each time a item is added to the inventory")]
    private UISlot slotPrefab;
    private List<UISlot> currentSlots = new List<UISlot>();
    private void OnEnable()
    {
        inventory.onInventoryUpdated.AddListener(UpdateInventoryUI);
        UpdateInventoryUI(inventory.InventorySlots);
    }
    private void OnDisable()
    {
        inventory.onInventoryUpdated.RemoveListener(UpdateInventoryUI);
    }
    /// <summary>
    /// It will update the inventory UI
    /// </summary>
    /// <param name="items">The list of items currently in the inventory</param>
    private void UpdateInventoryUI(List<Item> items)
    {
        //SPECIAL NOTE: Even though we have a referecen to the inventory, I decided that the onInventoryUpdated event sends the list of items just in case we want to use differently in other scripts
        foreach (UISlot slot in currentSlots)
        {
            //This is not the best way to reset the inventory. Probabilly the slots should go inactive and reset only the ones that we need.
            //But as the way to show the inventory was left to the developer I didn't want to spend much time in this part.
            Destroy(slot.gameObject);
        }
        currentSlots = new List<UISlot>();
        foreach (Item item in items)
        {
            UISlot slot = Instantiate(slotPrefab);
            slot.SetItem(item);
            slot.transform.parent = grid.transform;
            slot.textUI = textPanel;
            currentSlots.Add(slot);
        }
        weigthPanel.text = $"Weight {inventory.MaxWeight} / {inventory.CurrentWeight}";
    }
}
