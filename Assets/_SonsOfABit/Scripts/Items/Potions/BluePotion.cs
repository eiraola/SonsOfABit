using UnityEngine;

public class BluePotion : ItemConsumable
{
    public BluePotion(string name, float weight, EItemType itemType, Sprite itemVisual, float timeToRot) : base(name, weight,itemType,itemVisual,timeToRot)
    {

    }
    /// <summary>
    /// The blue potion makes the player twice bigger.
    /// </summary>
    public override void UseItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            return;
        }
        player.transform.localScale = player.transform.localScale * 2.0f;
        Inventory inventory = player.GetComponent<Inventory>();
        if (!inventory)
        {
            return;
        }
        inventory.RemoveItem(this);
    }
}
