public class HealthBar : SliderBar
{
    protected override void RenderHealth() =>
        _slider.value = _health.Value / _health.MaxValue;
}
