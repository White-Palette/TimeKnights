using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SelectEffector : MonoBehaviour
{
    static private SelectEffector instance;
    static public SelectEffector Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SelectEffector>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] SpriteRenderer subSpriteRenderer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EffectOff();
    }

    public void Effect(Vector2 position)
    {
        spriteRenderer.enabled = true;
        subSpriteRenderer.enabled = true;
        transform.position = position;
        subSpriteRenderer.transform.position = position;
        transform.DOScale(10f, 1f).From(0f);
        spriteRenderer.DOFade(0f, 1f).From(1f);
        subSpriteRenderer.DOFade(1f, 1f).From(0f);
    }

    public void EffectOff()
    {
        Debug.Log("EffectOff");
        subSpriteRenderer.enabled = false;
        spriteRenderer.enabled = false;
    }
}
