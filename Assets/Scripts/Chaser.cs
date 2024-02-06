using UnityEngine;
using System;

public class Chaser : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool _isChasing = false;
    private MovePlayer _player;

    public Action<bool> Pursued;

    private void Update()
    {
        if (_isChasing == true)
            Chase();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovePlayer movePlayer))
        {
            _player = movePlayer;
            _isChasing = true;

            Pursued?.Invoke(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovePlayer movePlayer))
        {
            _player = null;
            _isChasing = false;
            Pursued?.Invoke(true);
        }
    }

    private void Chase()
    {
        if (_enemy.TryGetComponent(out Rigidbody2D rigidbody))
        {
            Vector3 distance = (_player.transform.position - transform.position).normalized;
            _enemy.transform.position += new Vector3(distance.x, rigidbody.velocity.y) * _enemy.Speed * Time.deltaTime;
        }
    }
}
