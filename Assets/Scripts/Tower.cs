using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private DragHandler dragHandler;
    private RectTransform rectTransform = null;

    [SerializeField]
    private GameObject virtualImage = null;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        dragHandler = GetComponent<DragHandler>();

        dragHandler.OnDragStart.AddListener(OnDragStart);
        dragHandler.OnDrag.AddListener(OnDrag);
    }

    private void OnDragStart(Vector2 position)
    {
        if (virtualImage.scene.name == null || virtualImage.scene.name == virtualImage.name)
        {
            virtualImage = Instantiate(virtualImage);
            virtualImage.transform.SetParent(null);
            virtualImage.transform.localPosition = Vector3.zero;
        }
    }

    private void OnDrag(Vector2 position)
    {
        position = Camera.main.ScreenToWorldPoint(position);
        virtualImage.transform.position = position;
    }
}
