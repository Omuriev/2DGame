using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _healhValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.Heal(_healhValue);
            Destroy(gameObject);
        }
    }
}
