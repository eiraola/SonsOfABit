using UnityEngine;
/// <summary>
/// A base class to create diferent weapons
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The damage per second of the weapons")]
    protected float dps = 0.0f;
    public float Dps { get => dps; set => dps = value; }
    /// <summary>
    /// Uses the current weapon
    /// </summary>
    public abstract void UseWeapon();
}
