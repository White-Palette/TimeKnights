using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoSingleton<UserManager>
{
    private UserInfo _userInfo = null;
    void Start()
    {
        _userInfo = new UserInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _userInfo.AddResource(10);
        }
    }

    public int GetUserResource()
    {
        return _userInfo._resource;
    }
}
