using UnityEngine;
using UnityEngine.UI;

public abstract class SliderBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected Health Health;

    private void Awake()
    {
        RenderHealth();

        Health.ValueChanged += RenderHealth;
    }

    private void OnDisable() =>
        Health.ValueChanged -= RenderHealth;

    protected abstract void RenderHealth();
}
