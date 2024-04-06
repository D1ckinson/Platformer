using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerСollector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ICollectable item) == false)
            return;

        if (item is Coin)
        {
            Destroy(collider.gameObject);
        }
        else if (item is Medkit medkit)
        {
            _health.Heal(medkit);
        }
    }
}
