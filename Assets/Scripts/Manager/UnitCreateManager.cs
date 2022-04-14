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
        // ���� ���꿡 �ʿ��Ѱ�

        // ���� ������Ʈ ��������?

        // ���� ������Ʈ�� ��ȯ�Ͽ����� ��ȯ�� ��ġ ��������?

        var unit = _pool.Get();
        unit.Destroy();
    }

    public void SetSpawnPosition(Transform spawnPosition)
    {
        _spawnPosition = spawnPosition;
    }

}