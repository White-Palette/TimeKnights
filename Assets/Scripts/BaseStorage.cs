using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorage : MonoSingleton<BaseStorage>
{
    private List<Base> _baseList = new List<Base>();

    void Start()
    {
        Base[] allChildren = GetComponentsInChildren<Base>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            allChildren[i].SetBaseID(i);
            _baseList.Add(allChildren[i]);
        }
    }
}
