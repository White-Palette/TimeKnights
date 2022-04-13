using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public int _resource { get; private set; }
    public uint _base { get; private set; }

    public UserInfo(int resource, uint baseVal)
    {
        _resource = resource;
        _base = baseVal;
    }

    public void AddResource(int resource)
    {
        _resource += resource;
    }
}
