using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject unitObj;

    InputManager inputManager;


    public void UnitCreate()
    {
        // ���� ���꿡 �ʿ��Ѱ�

        // ���� ������Ʈ ��������?

        // ���� ������Ʈ�� ��ȯ�Ͽ����� ��ȯ�� ��ġ ��������?

        Instantiate(unitObj, transform.position, Quaternion.identity);

    }

}