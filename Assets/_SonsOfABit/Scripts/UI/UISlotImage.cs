using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
/// <summary>
/// This class controls the actions that the user does over the UI image
/// </summary>
public class UISlotImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    [Tooltip("An input asset to bind functions to inputs")]
    private PlayerInputAsset playerInputAsset;
    public UnityEvent onHoverImageEnter = new UnityEvent();
    public UnityEvent onHoverImageExit = new UnityEvent();
    public UnityEvent onRightClick = new UnityEvent();
    private bool isHover = false;
    private void OnEnable()
    {
        playerInputAsset.RightClickEvent += LaunchRightClickEvent;
    }
    private void OnDisable()
    {
        playerInputAsset.RightClickEvent -= LaunchRightClickEvent;
        isHover = false;
    }
    private void LaunchRightClickEvent()
    {
        if (isHover)
        {
            onRightClick?.Invoke();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        onHoverImageEnter?.Invoke();
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onHoverImageExit?.Invoke();
        isHover = false;
    }

}
