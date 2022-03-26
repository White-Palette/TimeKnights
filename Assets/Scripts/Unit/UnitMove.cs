using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    // 이동 경로
    private Way _way;
    // 현재 위치
    private Vector3 _currentPosition = Vector3.zero;
    // 이동포인트 인덱스
    private int _wayPointIndex = 0;
    // 이동 속도
    [SerializeField]
    private float _speed = 3f;

    void Start()
    {
        _way = WayManager.Instance.GetWay(1);
        _currentPosition = transform.position;
    }


    void Update()
    {
        if (_wayPointIndex < _way.GetPathCount())
        {
            // 이동
            Vector3 direction = _way._path[_wayPointIndex] - _currentPosition;
            direction.Normalize();
            _currentPosition += direction * _speed * Time.deltaTime;
            transform.position = _currentPosition;

            // 이동 거리가 다다르면 다음 이동 경로로 이동
            if (Vector3.Distance(_currentPosition, _way._path[_wayPointIndex]) < 0.1f)
            {
                _wayPointIndex++;
            }
        }
    }
}
