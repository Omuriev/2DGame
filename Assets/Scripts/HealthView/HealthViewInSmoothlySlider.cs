using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewInSmoothlySlider : HealthSliderView
{
    private Coroutine _changeValueCoroutine;

    public override void ChangeHealth(float currentHealth, float maxHealth)
    {
        if (_changeValueCoroutine != null)
        {
            StopCoroutine(_changeValueCoroutine);
            _changeValueCoroutine = null;
        }

        _changeValueCoroutine = StartCoroutine(ChangeValueInSlider(currentHealth, maxHealth));
    }

    private IEnumerator ChangeValueInSlider(float currentHealth, float maxHealth)
    {
        WaitForFixedUpdate waitTime = new WaitForFixedUpdate();
        float delta = 0.1f;
        float targetValue = currentHealth / maxHealth;
        bool isChangeValue = Slider.value != targetValue;

        while (isChangeValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, currentHealth / maxHealth, delta * Time.deltaTime);

            yield return waitTime;
        }
    }
}
