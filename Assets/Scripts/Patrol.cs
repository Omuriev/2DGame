using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistanceToTarget = 0.5f;

    private Vector3 _targetPointPosition;
    private int _pointIndex = 0;

    private void Start()
    {
        _targetPointPosition = _points[_pointIndex].position;
    }

    private void Update()
    {
        MoveToPoint();
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
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPointPosition, _speed * Time.deltaTime);
    }
}
