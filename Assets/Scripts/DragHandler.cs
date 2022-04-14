using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragHandler : MonoBehaviour
{
    public UnityEvent<Vector2> OnDragStart;
    public UnityEvent<Vector2> OnDrag;
    public UnityEvent<Vector2> OnDragEnd;

    public bool IsDraggable = true;
    public bool IsDragging = false;

    private ClickHandler clickHandler;

    void Start()
    {
        clickHandler = GetComponent<ClickHandler>();
        clickHandler.OnClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (IsDraggable)
        {
            IsDragging = true;
            OnDragStart.Invoke(Input.mousePosition);
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && IsDragging)
        {
            OnDrag.Invoke(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && IsDragging)
        {
            OnDragEnd.Invoke(Input.mousePosition);
            IsDragging = false;
        }
    }
}
