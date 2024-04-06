using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    public bool IsFull => _health == _maxHealth;
    private bool IsAlive => _health > 0;

    private void Update()
    {
        if (IsAlive == false)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage) =>
        _health -= damage;

    public void Heal(Medkit medkit)
    {
        if (IsFull)
            return;

        float health = _health + medkit.Heal;
        _health = health > _maxHealth ? _maxHealth : health;

        Destroy(medkit.gameObject);
    }
}
