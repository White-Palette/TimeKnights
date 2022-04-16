using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private ClickHandler clickHandler;
    private DragHandler dragHandler;
    private RectTransform rectTransform = null;

    [SerializeField]
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
            virtualImage = Instantiate(virtualImage);
            virtualImage.transform.SetParent(null);
            virtualImage.transform.localPosition = Vector3.zero;
        }
    }

    private void OnDragStart(Vector2 position)
    {
        Debug.Log("OnDragStart");
        // follow cursur
        virtualImage.transform.position = position;
    }

    private void OnDrag(Vector2 position)
    {
        Debug.Log("OnDrag");
        virtualImage.transform.position = position;
    }
}
