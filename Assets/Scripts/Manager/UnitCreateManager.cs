using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateManager : MonoSingleton<UnitCreateManager>
{
    [SerializeField]
    private GameObject _unitObj;

    private Transform _spawnPosition = null;
    private Pool<UnitMove> _pool;

    InputManager _inputManager;

    private void Start()
    {
        _pool = new Pool<UnitMove>(_unitObj);
    }

    public void UnitCreate(int unitID, Vector3 position, List<Vector3> path)
    {
        if (path.Count == 0)
            return;
        _pool.Get(position, unit => {
            unit.SetPath(path);
        });
    }

    public void SetSpawnPosition(Transform spawnPosition)
    {
        _spawnPosition = spawnPosition;
    }
}