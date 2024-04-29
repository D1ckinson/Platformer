public class HealthBar : SliderBar
{
    protected override void RenderHealth() =>
        Slider.value = Health.Value / Health.MaxValue;
}
