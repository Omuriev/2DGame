using UnityEngine;

public class FirstAidKitCollector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _health.Heal(firstAidKit.HealValue);
            Destroy(firstAidKit.gameObject);
        }
    }
}
