using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoSingleton<UserManager>
{
    private UserInfo _userInfo = null;
    void Start()
    {
        _userInfo = new UserInfo(0);
        StartCoroutine(CallAddResource());
    }

    private IEnumerator CallAddResource()
    {
        while (true)
        {
            _userInfo.AddResource(10);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public int GetUserResource()
    {
        return _userInfo._resource;
    }
}
