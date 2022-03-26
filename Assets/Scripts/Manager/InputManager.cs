using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private ClickableObject[] _clickableObjects;
    private GraphicRaycaster[] _graphicRaycaster;
    private PointerEventData _pointerEventData;

    private void Start()
    {
        _graphicRaycaster = FindObjectsOfType<GraphicRaycaster>();
        _clickableObjects = FindObjectsOfType<ClickableObject>();
        _pointerEventData = new PointerEventData(null);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    List<RaycastResult> results = new List<RaycastResult>();
                    _pointerEventData.position = Input.GetTouch(i).position;
                    foreach (GraphicRaycaster raycaster in _graphicRaycaster)
                    {
                        raycaster.Raycast(_pointerEventData, results);
                    }

                    if (results.Count > 0)
                    {
                        foreach (ClickableObject clickableObject in _clickableObjects)
                        {
                            if (results[0].gameObject == clickableObject.gameObject)
                            {
                                clickableObject.OnClickObject();
                            }
                        }
                    }
                    else
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit))
                        {
                            foreach (ClickableObject clickableObject in _clickableObjects)
                            {
                                if (hit.collider.gameObject == clickableObject.gameObject)
                                {
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
                foreach (ClickableObject clickableObject in _clickableObjects)
                {
                    if (results[0].gameObject == clickableObject.gameObject)
                    {
                        clickableObject.OnClickObject();
                    }
                }
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    foreach (ClickableObject clickableObject in _clickableObjects)
                    {
                        if (hit.collider.gameObject == clickableObject.gameObject)
                        {
                            clickableObject.OnClickObject();
                        }
                    }
                }
            }
        }
#endif
    }
}
