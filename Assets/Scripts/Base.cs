using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    int _baseID;
    ClickableObject clickableObject;

    void Start()
    {
        clickableObject = GetComponent<ClickableObject>();
        clickableObject.OnClick.AddListener(OnClick);
    }

    public void SetBaseID(int baseID)
    {
        _baseID = baseID;
    }

    public void OnClick()
    {
        Debug.Log("Base clicked");
        SelectEffector.Instance.Effect(transform.position);
        UnitCreateManager.Instance.SetSpawnPosition(transform);
    }
}
