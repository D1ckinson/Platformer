using UnityEngine;

public class DamageButton : HealthInteractButton
{
    [SerializeField] private float _damage = 10;

    public override void Interact() =>
        Health.TakeDamage(_damage);
}
