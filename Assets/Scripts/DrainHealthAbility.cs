using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainHealthAbility : MonoBehaviour
{
    [SerializeField] private float _drainValue = 0.1f;
    [SerializeField] private Health _health;

    private bool _isEnemyInDrainZone = false;
    private bool _isDrainStarted = false;

    private int _drainHealthTime = 6;
    private Health _enemyHealth;
    private Coroutine _drainEnemyHealthCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            _enemyHealth = health;
            _isEnemyInDrainZone = true;
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isEnemyInDrainZone == true && _isDrainStarted == false && Input.GetKey(KeyCode.E))
        {
            _isDrainStarted = true;

            if (_drainEnemyHealthCoroutine != null)
            {
                StopCoroutine(_drainEnemyHealthCoroutine);
            }

            if (_enemyHealth != null)
            {
                _drainEnemyHealthCoroutine = StartCoroutine(DrainEnemyHealth(_enemyHealth));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            _isEnemyInDrainZone = false;
            _enemyHealth = null;

            if (_drainEnemyHealthCoroutine != null)
            {
                StopCoroutine(_drainEnemyHealthCoroutine);
                _isDrainStarted = false;
            }
        }
    }

    private IEnumerator DrainEnemyHealth(Health enemyHealth)
    {
        WaitForSeconds waitTime = new WaitForSeconds(1.0f);
        int currentActionTime = 0;

        while (currentActionTime < _drainHealthTime && _isEnemyInDrainZone == true)
        {
            enemyHealth.TakeDamage(_drainValue);
            _health.Heal(_drainValue);

            currentActionTime++;

            yield return waitTime;
        }

        _isDrainStarted = false;
    }
}
