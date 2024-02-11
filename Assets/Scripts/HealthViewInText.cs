using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthViewInText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _healthInText;

    private void OnEnable()
    {
        _health.ChangedHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.ChangedHealth -= ChangeHealth;
    }

    private void ChangeHealth(float currentHealth, float maxHealth)
    {
        _healthInText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
