public class HealthBar : SliderBar
{
    protected override void RenderHealth() =>
        _slider.value = _health._value / _health._maxValue;
}
