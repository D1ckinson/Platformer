using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderBar
{
    protected override void RenderHealth() =>
        StartCoroutine(MoveSlider());

    private IEnumerator MoveSlider()
    {
        float currentValue = _health.Value / _health.MaxValue;

        while (_slider.value != currentValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);

            yield return null;
        }
    }
}
