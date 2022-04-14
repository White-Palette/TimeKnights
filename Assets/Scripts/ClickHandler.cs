using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    public UnityEvent OnClick = new UnityEvent();
    public bool IsClickable = true;
    
    private void Start()
    {
        if (GetComponent<RectTransform>() == null && GetComponent<Collider2D>() == null)
        {
            Debug.LogError("ClickableObject: " + gameObject.name + " has no RectTransform or Collider component.");
        }
    }

    public void OnClickObject()
    {
        if (IsClickable)
        {
            OnClick.Invoke();
        }
    }
}