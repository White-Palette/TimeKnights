using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ClickHandler))]
public class DragHandler : MonoBehaviour
{
    public UnityEvent<Vector2> OnDragStart;
    public UnityEvent<Vector2> OnDrag;
    public UnityEvent<Vector2> OnDragEnd;

    public bool IsDraggable = true;
    public bool IsDragging = false;

    private ClickHandler clickHandler;
    private bool isInCanvas;

    void Start()
    {
        clickHandler = GetComponent<ClickHandler>();
        clickHandler.OnClick.AddListener(OnClick);

        if (GetComponent<RectTransform>() == null && GetComponent<Collider2D>() == null)
        {
            Debug.LogError("ClickableObject: " + gameObject.name + " has no RectTransform or Collider component.");
        }
        else if (GetComponent<RectTransform>() != null)
        {
            isInCanvas = true;
        }
        else if (GetComponent<Collider2D>() != null)
        {
            isInCanvas = false;
        }
    }

    public void OnClick()
    {
        if (IsDraggable)
        {
            IsDragging = true;
            if (isInCanvas)
                OnDragStart.Invoke(Input.mousePosition);
            else
                OnDragStart.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && IsDragging)
        {
            if (isInCanvas)
                OnDrag.Invoke(Input.mousePosition);
            else
                OnDrag.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (Input.GetMouseButtonUp(0) && IsDragging)
        {
            if (isInCanvas)
                OnDragEnd.Invoke(Input.mousePosition);
            else
                OnDragEnd.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            IsDragging = false;
        }
    }
}
