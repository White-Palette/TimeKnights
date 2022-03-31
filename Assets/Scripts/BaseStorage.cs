using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorage : MonoSingleton<BaseStorage>
{
    private List<Base> _baseList = new List<Base>();

    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        Base baseTemp = null;
        foreach (var baseObj in allChildren)
        {
            baseTemp = baseObj.GetComponent<Base>();
            _baseList.Add(baseTemp);
        }
    }
}
