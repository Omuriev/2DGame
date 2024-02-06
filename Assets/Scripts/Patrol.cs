using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistanceToTarget = 0.5f;
    [SerializeField] private float _distanceForChase = 3.0f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BoxCollider2D _detectionZone;

    private Vector3 _targetPointPosition;
    private int _pointIndex = 0;
    private bool _isChasing = false;
    private GameObject _player;

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
        Vector3 distance = (_player.transform.position - transform.position).normalized;
        transform.position += new Vector3(distance.x, _rigidbody.velocity.y) * _speed * Time.deltaTime;
    }

    private void MoveToPoint()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovePlayer movePlayer))
        {
            _player = movePlayer.gameObject;
            _isChasing = true;
        }
    }

    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
