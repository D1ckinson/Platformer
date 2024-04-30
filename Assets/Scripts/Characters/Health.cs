using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    public event Action ValueChanged;
    public event Action ValueOver;

    [field: SerializeField] public float MaxValue { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    public bool IsFull => Value == MaxValue;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        Value = Mathf.Clamp(Value - damage, 0, MaxValue);

        if (Value == 0)
        {
            ValueOver?.Invoke();
            return;
        }

        ValueChanged?.Invoke();
    }

    public void Heal(Medkit medkit)
    {
        if (IsFull)
            return;

        if (medkit.Heal < 0)
            return;

        AddValue(medkit.Heal);
        Destroy(medkit.gameObject);
    }

    public void Heal(float heal)
    {
        if (heal < 0)
            return;

        AddValue(heal);
    }

    private void AddValue(float value)
    {
        Value = Mathf.Clamp(Value + value, 0, MaxValue);

        ValueChanged?.Invoke();
    }
}
