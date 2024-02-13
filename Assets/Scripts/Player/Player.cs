using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _deathDelay;

    private void OnEnable()
    {
        _health.Dead += Die;
    }

    private void OnDisable()
    {
        _health.Dead -= Die;
    }

    private void Die()
    {
        Destroy(gameObject, _deathDelay);
    }
}
