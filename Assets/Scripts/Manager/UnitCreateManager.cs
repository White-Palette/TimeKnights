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
        _pool = new Pool<UnitMove>(_unitObj, gameObject => {
            gameObject.transform.position = _spawnPosition.position;
        });
    }

    public void UnitCreate()
    {
        // 유닛 생산에 필요한것

        // 유닛 오브젝트 가져오기?

        // 유닛 오브젝트를 소환하였을때 소환될 위치 가져오기?

        var unit = _pool.Get();
        unit.Destroy();
    }

    public void SetSpawnPosition(Transform spawnPosition)
    {
        _spawnPosition = spawnPosition;
    }

}