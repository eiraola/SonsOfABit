using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class is made so different prefabs can have a scriptable object that will return an item instance
public class ItemContainer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The scriptable object that will build the item instance")]
    private ItemScriptable itemScript;
    /// <summary>
    /// Returns an item instance depending on the ItemScriptable attached.
    /// </summary>
    /// <returns></returns>
    public Item GetItem()
    {
        return itemScript.GetItem();
    }
}
