using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ClickHandler))]
[RequireComponent(typeof(DragHandler))]
public class Base : MonoBehaviour
{
    public int BaseID { get => _baseID; set => _baseID = value; }
    public bool IsSelected { get => _isSelected; set => _isSelected = value; }

    private int _baseID;
    private bool _isSelected = false;

    ClickHandler clickHandler;
    DragHandler dragHandler;

    public enum BaseOwner
    {
        None,
        Player,
        Enemy
    }

    [Tooltip("베이스의 소유자")]
    [SerializeField]
    BaseOwner _owner = BaseOwner.None;

    void Start()
    {
        clickHandler = GetComponent<ClickHandler>();
        clickHandler.OnClick.AddListener(OnClick);

        dragHandler = GetComponent<DragHandler>();
        dragHandler.OnDragStart.AddListener(OnDragStart);
        dragHandler.OnDrag.AddListener(OnDrag);
        dragHandler.OnDragEnd.AddListener(OnDragEnd);
    }

    private void OnClick()
    {
        if (IsSelected)
        {
            IsSelected = false;
            dragHandler.IsDraggable = false;
        }
        else
        {
            IsSelected = true;
            dragHandler.IsDraggable = true;
        }
    }

    private void OnDragStart(Vector2 position)
    {
        Debug.Log("OnDragStart");
    }

    private void OnDrag(Vector2 position)
    {
        Debug.Log("OnDrag");
    }

    private void OnDragEnd(Vector2 position)
    {
        Debug.Log("OnDragEnd");
    }
}
