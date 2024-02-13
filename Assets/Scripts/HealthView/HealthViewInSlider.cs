using UnityEngine;
using UnityEngine.UI;

public class HealthViewInSlider : HealthSliderView
{
    public override void ChangeHealth(float currentHealth, float maxHealth)
    {
        Slider.value = (currentHealth / maxHealth);
    }
}
