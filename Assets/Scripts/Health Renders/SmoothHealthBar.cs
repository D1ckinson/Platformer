using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private float _step = 0.01f;
    private float _delay = 0.06f;

    private void Awake()
    {
        RenderHealth();

        _health.ValueChanged += RenderHealth;
    }

    private void OnDisable() =>
        _health.ValueChanged -= RenderHealth;

    private void RenderHealth() =>
        StartCoroutine(MoveSlider());

    private IEnumerator MoveSlider()
    {
        WaitForSeconds wait = new(_delay);

        while (_slider.value > _health._value / _health._maxValue)
        {
            yield return wait;
            _slider.value -= _step;
        }

        yield return null;
    }
}
