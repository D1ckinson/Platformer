using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Awake()
    {
        RenderHealth();

        _health.ValueChanged += RenderHealth;
    }

    private void OnDisable() =>
        _health.ValueChanged -= RenderHealth;

    private void RenderHealth() =>
        _slider.value = _health._value / _health._maxValue;
}
