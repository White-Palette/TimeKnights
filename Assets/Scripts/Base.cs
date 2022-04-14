using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ClickHandler))]
[RequireComponent(typeof(DragHandler))]
[RequireComponent(typeof(LineRenderer))]
public class Base : MonoBehaviour
{

    [Header("베이스의 소유자")]
    [SerializeField] BaseOwner _owner = BaseOwner.None;

    [Header("연결된 베이스")]
    [SerializeField] List<Base> _connectedBases;

    public int BaseID => _baseID;
    public bool IsSelected => _isSelected;
    public BaseOwner Owner => _owner;
    public List<Base> ConnectedBases => _connectedBases;

    private ClickHandler clickHandler;
    private DragHandler dragHandler;
    private LineRenderer lineRenderer;
    private SpriteRenderer _spriteRenderer;
    private Color _baseColor;
    private int _baseID;
    private bool _isSelected = false;

    void Start()
    {
        clickHandler = GetComponent<ClickHandler>();
        clickHandler.OnClick.AddListener(OnClick);

        dragHandler = GetComponent<DragHandler>();
        dragHandler.OnDragStart.AddListener(OnDragStart);
        dragHandler.OnDrag.AddListener(OnDrag);
        dragHandler.OnDragEnd.AddListener(OnDragEnd);

        lineRenderer = GetComponent<LineRenderer>();

        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (Owner == BaseOwner.Player)
        {
            _baseColor = Color.blue;
        }
        else if (Owner == BaseOwner.Enemy)
        {
            _baseColor = Color.red;
        }
        _spriteRenderer.color = _baseColor;
    }

    private void OnClick()
    {
        _isSelected = true;

        Color color = _baseColor;
        color += new Color(0.5f, 0.5f, 0.5f, 0);
        _spriteRenderer.color = color;

        if (Owner == BaseOwner.Player) dragHandler.IsDraggable = true;
    }

    private void OnDragStart(Vector2 position)
    {
        Debug.Log("OnDragStart");
    }

    private void OnDrag(Vector2 position)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, position);
    }

    private void OnDragEnd(Vector2 position)
    {
        Debug.Log("OnDragEnd");
    }
}
