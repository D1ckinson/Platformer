using TMPro;
using UnityEngine;

public class TextHealth : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Health _health;

    private void Awake()
    {
        RenderHealth();

        _health.ValueChanged += RenderHealth;
    }

    private void OnDisable() =>
        _health.ValueChanged -= RenderHealth;

    private void RenderHealth() =>
        _text.text = $"{_health.Value}/{_health.MaxValue}";
}
