using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]

    [Tooltip("현재 보유중인 자원량을 표시해주는 텍스트")]
    [SerializeField]
    private Text _resourceText = null;

    void Update()
    {
        _resourceText.text = "Resource : " + UserManager.Instance.GetUserResource();
    }
}
