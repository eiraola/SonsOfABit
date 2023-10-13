using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The player movement speed in m/s")]
    private float speed = 10.0f;
    [SerializeField]
    [Tooltip("A player input asset to attach the controls to different actions")]
    private PlayerInputAsset playerInputAsset;
    private Vector3 currentDirection = Vector3.zero;
    /// <summary>
    /// We bind the input controls to the setdirection function 
    /// </summary>
    private void OnEnable()
    {
        if (playerInputAsset)
        {
            playerInputAsset.MovementEvent += SetCurrentDirection;
        }
    }
    /// <summary>
    /// We unbind the input controls to the set direction function
    /// </summary>
    private void OnDisable()
    {
        if (playerInputAsset)
        {
            playerInputAsset.MovementEvent -= SetCurrentDirection;
        }
    }
    /// <summary>
    /// When a control is detected the current direction is set to "newDir".
    /// </summary>
    /// <param name="newDir"></param>
    private void SetCurrentDirection(Vector2 newDir)
    {
        currentDirection = Vector3.right * newDir.x + Vector3.forward * newDir.y;
    }
    /// <summary>
    /// In the update function we just make the player move in the current direction.
    /// </summary>
    private void Update()
    {
        transform.position += currentDirection * speed * Time.deltaTime;
    }
}
