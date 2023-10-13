using UnityEngine;

public class RedPotion : ItemConsumable
{
    public RedPotion(string name, float weight, EItemType itemType, Sprite itemVisual, float timeToRot) : base(name, weight, itemType, itemVisual, timeToRot)
    {

    }
    /// <summary>
    /// Red potion will make the player reduce his size in half.
    /// </summary>
    public override void UseItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            return;
        }
        player.transform.localScale = player.transform.localScale * 0.5f;
        Inventory inventory = player.GetComponent<Inventory>();
        if (!inventory)
        {
            return;
        }
        inventory.RemoveItem(this);
    }
}