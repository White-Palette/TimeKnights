using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    public enum BaseOwner
    {
        None,
        Player,
        Enemy
    }

    // 베이스의 고유 ID
    private int _baseID;

    [Tooltip("베이스의 소유자")]
    [SerializeField]
    BaseOwner _owner = BaseOwner.None;
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

    public BaseOwner GetOwner()
    {
        return _owner;
    }

    public void OnClick()
    {
        Debug.Log("Base clicked");
        Debug.Log(_baseID);
        SelectEffector.Instance.Effect(transform.position);
        UnitCreateManager.Instance.SetSpawnPosition(transform);
    }
}
