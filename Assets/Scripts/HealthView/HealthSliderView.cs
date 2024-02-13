using UnityEngine;
using UnityEngine.UI;

public class HealthSliderView : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Slider Slider;

    private void OnEnable()
    {
        Health.ChangedHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        Health.ChangedHealth -= ChangeHealth;
    }

    public virtual void ChangeHealth(float currentHealth, float maxHealth) { }
}
