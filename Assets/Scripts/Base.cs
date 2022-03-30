using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    string _baseName;
    ClickableObject clickableObject;

    void Start()
    {
        clickableObject = GetComponent<ClickableObject>();
        clickableObject.OnClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log("Base clicked");
        SelectEffector.Instance.Effect(transform.position);
    }
}
