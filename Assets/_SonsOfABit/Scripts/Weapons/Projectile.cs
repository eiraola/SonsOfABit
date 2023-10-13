using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The speed of the projectile")]
    private float speed = 10.0f;
    [SerializeField]
    [Tooltip("The lifetime of the projectile")]
    private float lifeTime = 10.0f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
