using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private GameObject teamEditor;
    [SerializeField]
    private GameObject KnightScroll;
    [SerializeField]
    private GameObject ExileScroll;
    [SerializeField]
    private GameObject SpiritScroll;
    [SerializeField]
    private GameObject shop;


    private void Awake()
    {
        teamEditor.SetActive(false);
        shop.SetActive(false);
    }

    public void OnClickShop()
    {
        shop.SetActive(true);
    }
    public void OnClickEditor()
    {
        teamEditor.SetActive(true);
    }
    public void OnClickClose()
    {
        teamEditor.SetActive(false);
        shop.SetActive(false);
    }
    public void OnClickBattle()
    {
        SceneManager.LoadScene("Main");
    }
    private void DisableAllScroll()
    {
        KnightScroll.SetActive(false);
        ExileScroll.SetActive(false);
        SpiritScroll.SetActive(false);
    }
    public void ActiveKnight()
    {
        DisableAllScroll();
        KnightScroll.SetActive(true);
    }
    public void ActiveExile()
    {
        DisableAllScroll();
        ExileScroll.SetActive(true);
    }
    public void ActiveSpirit()
    {
        DisableAllScroll();
        SpiritScroll.SetActive(true);
    }
    public void StageStart(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
