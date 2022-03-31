using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateManager : MonoSingleton<UnitCreateManager>
{
    [SerializeField]
    private GameObject _unitObj;

    private Transform _spawnPosition = null;

    InputManager _inputManager;

    public void UnitCreate()
    {
        // ���� ���꿡 �ʿ��Ѱ�

        // ���� ������Ʈ ��������?

        // ���� ������Ʈ�� ��ȯ�Ͽ����� ��ȯ�� ��ġ ��������?

        GameObject unit = Instantiate(_unitObj, _spawnPosition);
    }

    public void SetSpawnPosition(Transform spawnPosition)
    {
        _spawnPosition = spawnPosition;
    }

}