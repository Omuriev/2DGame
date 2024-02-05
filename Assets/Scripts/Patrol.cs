using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistanceToTarget = 0.5f;
    [SerializeField] private float _distanceForChase = 3.0f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _player;

    private Vector3 _targetPointPosition;
    private int _pointIndex = 0;
    private bool _isChasing = false;

    private void Start()
    {
        _targetPointPosition = _points[_pointIndex].position;
    }

    private void Update()
    {
        if (_isChasing == false)
        {
            MoveToPoint();
        }
        else
        {
            Chase();
        }
    }

    private void Chase()
    {
        var distance = (_player.transform.position - transform.position).normalized;
        transform.position += new Vector3(distance.x, _rigidbody.velocity.y) * _speed * Time.deltaTime;
    }

    private void MoveToPoint()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) <= _distanceForChase)
        {
            _isChasing = true;
        }

        if (_isChasing == false)
        {
            if (Vector2.Distance(transform.position, _targetPointPosition) <= _maxDistanceToTarget)
            {
                _pointIndex++;

                if (_pointIndex == _points.Length)
                {
                    _pointIndex = 0;
                }

                _targetPointPosition = _points[_pointIndex].position;
                Flip();
            }

            transform.position = Vector2.MoveTowards(transform.position, _targetPointPosition, _speed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
