using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent OnClick;
    
    private void Start()
    {
        if (GetComponent<RectTransform>() == null && GetComponent<Collider2D>() == null)
        {
            Debug.LogError("ClickableObject: " + gameObject.name + " has no RectTransform or Collider component.");
        }
    }

    public void OnClickObject()
    {
        OnClick.Invoke();
    }
}