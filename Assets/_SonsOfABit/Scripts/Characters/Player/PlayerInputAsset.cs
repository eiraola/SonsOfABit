using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;
[CreateAssetMenu(fileName = "New Input Reader,", menuName = "Input/InputReader")]
//This class has been created just to bind the input keys to different actions.
public class PlayerInputAsset : ScriptableObject, IPlayerActions
{
    private InputActions _input;
    public event Action<Vector2> MovementEvent;
    public event Action MenuEvent;
    public event Action ShootEvent;
    public event Action RightClickEvent;
    private void OnEnable()
    {
        Initialize();
    }
    private void Initialize()
    {
        if (_input == null)
        {
            _input = new InputActions();
            _input.Player.SetCallbacks(this);
        }
        _input.Player.Enable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MenuEvent?.Invoke();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShootEvent?.Invoke();
        }
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RightClickEvent?.Invoke();
        }
    }
}
