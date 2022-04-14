using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerUIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private GameObject _tower = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start");
        //_tower = Instantiate(this.gameObject, , this.transform.rotation);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Draging");
        _tower.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        // throw new System.NotImplementedException();
        Destroy(_tower);
    }
}
