using UnityEngine;

public class InventoryShowHide : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A player input asset to set the player controls")]
    private PlayerInputAsset playerInputAsset;
    [SerializeField]
    [Tooltip("The menu game object that will toggle visibility")]
    private GameObject menu;
    private void OnEnable()
    {
        if (playerInputAsset)
        {
            playerInputAsset.MenuEvent += ToggleMenuVisibility;
        }
    }
    private void OnDisable()
    {
        if (playerInputAsset)
        {
            playerInputAsset.MenuEvent -= ToggleMenuVisibility;
        }
    }
    /// <summary>
    /// Toggles the visibility of the menu
    /// </summary>
    private void ToggleMenuVisibility()
    {
        if (menu.activeInHierarchy)
        {
            menu.gameObject.SetActive(false);
            return;
        }
        menu.gameObject.SetActive(true);
    }
}
