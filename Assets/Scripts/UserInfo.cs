using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public int _resource { get; private set; }

    public UserInfo(int resource)
    {
        _resource = resource;
    }

    public void AddResource(int resource)
    {
        _resource += resource;
    }
}
