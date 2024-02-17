using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainHealthAbility : MonoBehaviour
{
    [SerializeField] private float _drainValue = 0.1f;
    [SerializeField] private Health _health;
    [SerializeField] private float _timeBetweenDraining = 1.0f; 

    private bool _isDrainStarted = false;

    private int _drainHealthTime = 6;
    private Coroutine _drainEnemyHealthCoroutine;

    private void Update()
    {
        ActivateAbility();
    }

    private void ActivateAbility()
    {
        if (Input.GetKey(KeyCode.E) && _isDrainStarted == false)
        {
            if (_drainEnemyHealthCoroutine != null)
            {
                StopCoroutine(_drainEnemyHealthCoroutine);
            }

            _drainEnemyHealthCoroutine = StartCoroutine(DrainEnemyHealth());
        }
    }

    private IEnumerator DrainEnemyHealth()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_timeBetweenDraining);
        int currentActionTime = 0;
        Health enemyHealth;
        _isDrainStarted = true;
        
        while (currentActionTime < _drainHealthTime && _isDrainStarted == true)
        {
            Collider2D[] hitColliders = FindEnemies();

            if (hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    enemyHealth = GetEnemyHealth(hitColliders[i]);

                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(_drainValue);
                        _health.Heal(_drainValue);
                    }
                }

                currentActionTime++; 
                yield return waitTime;
            }
            else
            {
                _isDrainStarted = false;
            }
        }

        _isDrainStarted = false;
    }

    private Health GetEnemyHealth(Collider2D enemyCollider)
    {
        if (enemyCollider.gameObject.TryGetComponent(out Enemy enemy) != false)
        {
            Health enemyHealth = enemy.gameObject.GetComponentInChildren<Health>();

            if (enemyHealth != null)
            {
                return enemyHealth;
            }
        }

        return null;
    }

    private Collider2D[] FindEnemies()
    {
        LayerMask enemyLayer = LayerMask.GetMask("Enemy");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 4, enemyLayer);

        return hitColliders;
    }
}
