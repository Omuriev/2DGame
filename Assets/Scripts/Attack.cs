using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            HitEnemy(health);
        }
    }

    private void HitEnemy(Health health)
    {
        health.TakeDamage(_damage);
    }
}
