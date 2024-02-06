using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    private int _money;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _money += coin.Value;
            Destroy(coin.gameObject);
        }
    }
}
