using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : PoolableBehaviour<UnitMove>
{
    [SerializeField] float _speed = 3f;
    private List<Vector3> _path = new List<Vector3>();

    private void Start()
    {
        OnUnpool += OnUnpooled;
    }

    private void OnUnpooled(UnitMove obj)
    {
        _path.Clear();
    }

    public void SetPath(List<Vector3> path)
    {
        _path = path;
    }

    private void FixedUpdate()
    {
        if (_path.Count == 0)
            return;
        transform.position = Vector3.MoveTowards(transform.position, _path[0], _speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, _path[0]) < _speed * Time.fixedDeltaTime)
        {
            transform.position = _path[0];
            _path.RemoveAt(0);
        }
    }
}
