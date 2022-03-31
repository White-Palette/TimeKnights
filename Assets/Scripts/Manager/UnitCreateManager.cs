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
        // 유닛 생산에 필요한것

        // 유닛 오브젝트 가져오기?

        // 유닛 오브젝트를 소환하였을때 소환될 위치 가져오기?

        Instantiate(unitObj, transform.position, Quaternion.identity);

    }

}