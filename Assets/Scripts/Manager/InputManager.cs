using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private ClickHandler[] _clickableObjects;
    private GraphicRaycaster[] _graphicRaycaster;
    private PointerEventData _pointerEventData;

    private ClickHandler _inputTarget;

    private void Start()
    {
        _graphicRaycaster = FindObjectsOfType<GraphicRaycaster>();
        _clickableObjects = FindObjectsOfType<ClickHandler>();
        _pointerEventData = new PointerEventData(null);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    List<RaycastResult> results = new List<RaycastResult>();
                    _pointerEventData.position = Input.GetTouch(i).position;
                    foreach (GraphicRaycaster raycaster in _graphicRaycaster)
                    {
                        raycaster.Raycast(_pointerEventData, results);
                    }

                    if (results.Count > 0)
                    {
                        foreach (ClickHandler clickableObject in _clickableObjects)
                        {
                            if (results[0].gameObject == clickableObject.gameObject)
                            {
                                if (Input.GetTouch(i).phase == TouchPhase.Began)
                                {
                                    clickableObject.OnClickObject();
                                }
                                _inputTarget = clickableObject;
                            }
                        }
                    }
                    else
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit))
                        {
                            foreach (ClickHandler clickableObject in _clickableObjects)
                            {
                                if (hit.collider.gameObject == clickableObject.gameObject)
                                {
                                    _inputTarget = clickableObject;
                                    clickableObject.OnClickObject();
                                }
                            }
                        }
                    }
                }
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = new List<RaycastResult>();
            _pointerEventData.position = Input.mousePosition;
            foreach (GraphicRaycaster raycaster in _graphicRaycaster)
            {
                raycaster.Raycast(_pointerEventData, results);
            }

            if (results.Count > 0)
            {
                foreach (ClickHandler clickableObject in _clickableObjects)
                {
                    if (results[0].gameObject == clickableObject.gameObject)
                    {
                        _inputTarget = clickableObject;
                        clickableObject.OnClickObject();
                    }
                }
            }
            else
            {
                var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;

                if (Physics2D.Raycast(position, Vector2.zero))
                {
                    foreach (ClickHandler clickableObject in _clickableObjects)
                    {
                        if (Physics2D.Raycast(position, Vector2.zero).collider.gameObject == clickableObject.gameObject)
                        {
                            _inputTarget = clickableObject;
                            clickableObject.OnClickObject();
                        }
                    }
                }
            }
        }
#endif
    }
}
