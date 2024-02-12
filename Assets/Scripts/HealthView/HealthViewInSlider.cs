using UnityEngine;
using UnityEngine.UI;

public class HealthViewInSlider : HealthSliderView
{
    private void OnEnable()
    {
        Health.ChangedHealth += ChangeHealth;
    }

    public override void ChangeHealth(float currentHealth, float maxHealth)
    {
        Slider.value = (currentHealth / maxHealth);
    }
}
