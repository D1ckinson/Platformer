using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    public event Action ValueChanged;

    [field: SerializeField] public float MaxValue { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    public bool IsFull => Value == MaxValue;

    public void TakeDamage(float damage)
    {
        float value = Value - damage;

        if (value <= 0)
        {
            Destroy(gameObject);
            return;
        }

        Value = value;

        ValueChanged?.Invoke();
    }

    public void Heal(Medkit medkit)
    {
        if (IsFull)
            return;

        float health = Value + medkit.Heal;
        Value = health > MaxValue ? MaxValue : health;

        ValueChanged?.Invoke();
        Destroy(medkit.gameObject);
    }
}
