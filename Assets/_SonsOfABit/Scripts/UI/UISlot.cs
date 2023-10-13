using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [Tooltip("The pannel where the slot has to write the item data")]
    public TextMeshProUGUI textUI;
    [Tooltip("The item that the slot is referencing")]
    public Item item;
    [Tooltip("The image that will show the item UI")]
    public Image image;
    public bool shouldWrite;
    /// <summary>
    /// Sets the item reference of the slot and sets the image to show
    /// </summary>
    /// <param name="newItem">The item that is going to be added</param>
    public void SetItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.ItemVisual;
    }
    private void Update()
    {
        WriteToPanel();
    }
    /// <summary>
    /// It will write the current info to the panel if it is required 
    /// </summary>
    public void WriteToPanel()
    {
        if (shouldWrite)
        {
            textUI.text = item.GetData();
        }
    }
    /// <summary>
    /// Makes the item write or not write in the panel
    /// </summary>
    /// <param name="shouldWrite">True if it has to write, false if it has not to write</param>
    public void MakeSlotWrite(bool shouldWrite)
    {
        this.shouldWrite = shouldWrite;
    }
    /// <summary>
    /// Uses the item related to this slot
    /// </summary>
    public void UseItem()
    {
        item.UseItem();
    }
    public void RemoveItem()
    {
        //A good way to avoid all this search is using a singleton so we can find the player instance or the inventory in an easier way.
        //But as I am concern that some people are no confortable with the singelton pattern I decided to do it this way.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            return;
        }
        Inventory inventory = player.GetComponent<Inventory>();
        if (!inventory)
        {
            return;
        }
        inventory.RemoveItem(item);
    }
}
