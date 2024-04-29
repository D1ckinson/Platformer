using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderBar
{
    protected override void RenderHealth() =>
        StartCoroutine(MoveSlider());

    private IEnumerator MoveSlider()
    {
        float currentValue = Health.Value / Health.MaxValue;

        while (Slider.value != currentValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, currentValue, Time.deltaTime);

            yield return null;
        }
    }
}
