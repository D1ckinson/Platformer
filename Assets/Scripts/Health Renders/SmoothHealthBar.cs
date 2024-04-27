using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderBar
{
    protected override void RenderHealth() =>
        StartCoroutine(MoveSlider());

    private IEnumerator MoveSlider()
    {
        while (_slider.value > _health.Value / _health.MaxValue)
        {
            _slider.value -= Time.deltaTime;

            yield return null;
        }
    }
}
