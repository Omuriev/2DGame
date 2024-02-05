using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _prefab;

    private void Start()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_prefab, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
