using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    public event Action ValueChanged;
    //[SerializeField] private float _value;
    //public float CurrentValue => _value;

    [field: SerializeField] public float _maxValue { get; private set; }
    [field: SerializeField] public float _value { get; private set; }

    public bool IsFull => _value == _maxValue;
    private bool IsAlive => _value > 0;

    private void Update()
    {
        if (IsAlive == false)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _value -= damage;

        ValueChanged?.Invoke();
    }

    public void Heal(Medkit medkit)
    {
        if (IsFull)
            return;

        float health = _value + medkit.Heal;
        _value = health > _maxValue ? _maxValue : health;

        ValueChanged?.Invoke();
        Destroy(medkit.gameObject);
    }
}
