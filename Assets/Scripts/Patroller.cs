using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _maxDistanceToTarget = 0.5f;

    private Vector3 _targetPointPosition;
    private int _pointIndex = 0;
    private bool _isPatrolling = true;

    private void OnEnable()
    {
        _chaser.Pursued += ChangePatrollingState;
    }

    private void Start()
    {
        _targetPointPosition = _points[_pointIndex].position;
    }

    private void Update()
    {
        if (_isPatrolling == true)
        {
            MoveToPoint();
        }
    }

    private void OnDisable()
    {
        _chaser.Pursued -= ChangePatrollingState;
    }

    private void ChangePatrollingState(bool isPatrolling)
    {
        _isPatrolling = isPatrolling;
    }

    private void MoveToPoint()
    {
        if (Vector2.Distance(transform.position, _targetPointPosition) <= _maxDistanceToTarget)
        {
            _pointIndex = ++_pointIndex % _points.Length;

            _targetPointPosition = _points[_pointIndex].position;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPointPosition, _enemy.Speed * Time.deltaTime);
    }

    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
