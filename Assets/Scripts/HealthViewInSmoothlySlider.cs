using UnityEngine;
using UnityEngine.UI;

public class HealthViewInSmoothlySlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSmoothlySlider;

    private float _targetValue;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.ChangedHealth += ChangeHealth;
    }

    private void Update()
    {
        ChangeHealthSmoothly();
    }

    private void OnDisable()
    {
        _health.ChangedHealth -= ChangeHealth;
    }

    public void ChangeHealthSmoothly()
    {
        float delta = 0.1f;

        if (_healthSmoothlySlider.value != _targetValue)
            _healthSmoothlySlider.value = Mathf.MoveTowards(_healthSmoothlySlider.value, _targetValue / _maxHealth, delta * Time.deltaTime);
    }

    private void ChangeHealth(float currentHealth, float maxHealth)
    {
        _targetValue = currentHealth;
    }
}
