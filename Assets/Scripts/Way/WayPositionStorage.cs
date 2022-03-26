using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPositionStorage : MonoSingleton<WayPositionStorage>
{
    private List<Way> _wayList = new List<Way>();

    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        Way wayTemp = null;
        foreach (var way in allChildren)
        {
            wayTemp = way.GetComponent<Way>();
            _wayList.Add(wayTemp);
        }
    }

    public Way GetWay(int index)
    {
        return _wayList[index];
    }
}
