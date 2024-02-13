using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force = 10.0f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            base.OnTriggerEnter2D(collision);

            _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}
