using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private GameObject teamEditor;

    private void Awake()
    {
        teamEditor.SetActive(false);        
    }

    public void OnClickEditor()
    {
        teamEditor.SetActive(true);
    }
    public void OnClickClose()
    {
        teamEditor.SetActive(false);
    }
    public void OnClickBattle()
    {
        SceneManager.LoadScene("Main");
    }
}
