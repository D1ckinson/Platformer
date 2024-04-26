using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderBar
{
    protected override void RenderHealth() =>
        StartCoroutine(MoveSlider());

    private IEnumerator MoveSlider()
    {
        while (_slider.value > _health._value / _health._maxValue)
        {
            _slider.value -= Time.deltaTime;

            yield return null;
        }
    }
}
