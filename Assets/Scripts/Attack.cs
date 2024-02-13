using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            HitEnemy(health);
        }
    }

    protected void HitEnemy(Health health)
    {
        health.TakeDamage(_damage);
    }
}
