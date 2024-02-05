using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private Health _health;
    [SerializeField] private FirstAidKit _firstAidKitPrefab;
    [SerializeField] private Vector2 _firstAidKitSpawnOffset = new Vector2(1f, 1f);

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
        Instantiate(_firstAidKitPrefab, transform.position + new Vector3(_firstAidKitSpawnOffset.x, _firstAidKitSpawnOffset.y), Quaternion.identity);
        Destroy(gameObject);
    }
}
