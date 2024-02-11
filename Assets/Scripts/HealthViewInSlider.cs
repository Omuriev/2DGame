using UnityEngine;
using UnityEngine.UI;

public class HealthViewInSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _health.ChangedHealth += ChangeHealth;
    }

    private void ChangeHealth(float currentHealth, float maxHealth)
    {
        _slider.value = (currentHealth / maxHealth);
    }
}
