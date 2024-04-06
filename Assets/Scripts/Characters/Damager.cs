using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health health))
            health.TakeDamage(_damage);
    }
}
