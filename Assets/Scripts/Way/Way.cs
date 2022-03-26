using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public List<Vector3> _path { get; private set; } = new List<Vector3>();
    private LineRenderer _lineRenderer = null;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        SetWayPath();
    }

    private void SetWayPath()
    {
        _path.Clear();
        Vector3[] wayPoints = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(wayPoints);
        foreach (Vector3 wayPoint in wayPoints)
        {
            _path.Add(wayPoint);
        }
    }

    public int GetPathCount()
    {
        return _path.Count;
    }
}
