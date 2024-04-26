using UnityEngine;
using UnityEngine.UI;

public abstract class SliderBar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Health _health;

    private void Awake()
    {
        RenderHealth();

        _health.ValueChanged += RenderHealth;
    }

    private void OnDisable() =>
        _health.ValueChanged -= RenderHealth;

    protected abstract void RenderHealth();
}
