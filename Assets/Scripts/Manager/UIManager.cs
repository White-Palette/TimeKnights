using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("UI")]

    [Tooltip("현재 보유중인 자원량을 표시해주는 텍스트")]
    [SerializeField]
    private Text _resourceText = null;

    public int Resource 
    { 
        set 
        {
            _resourceText.text = $"{value.ToString("#,##0")} 원";
        }
    }
}
