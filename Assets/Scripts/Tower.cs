using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private ClickHandler clickHandler;
    private DragHandler dragHandler;
    private RectTransform rectTransform = null;

    private GameObject virtualImage = null;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        clickHandler = GetComponent<ClickHandler>();
        dragHandler = GetComponent<DragHandler>();

        clickHandler.OnClick.AddListener(OnClick);

        dragHandler.OnDragStart.AddListener(OnDragStart);
        dragHandler.OnDrag.AddListener(OnDrag);
    }

    private void OnClick()
    {
        Debug.Log("OnClick");
        if (virtualImage == null)
        {
            virtualImage = Instantiate(this.gameObject, rectTransform);
            virtualImage.transform.SetParent(transform.parent.parent, true);
        }
    }

    private void OnDragStart(Vector2 position)
    {
        Debug.Log("OnDragStart");
        virtualImage.transform.localPosition = position;
    }

    private void OnDrag(Vector2 position)
    {
        Debug.Log("OnDrag");
        virtualImage.transform.localPosition = position;
    }
}
