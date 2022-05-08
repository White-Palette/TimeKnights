using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    public float gauge = 50;
    public float maxGauge = 100;

    public Slider Bar;

    void Update()
    {
        Bar.value = (float)gauge / (float)maxGauge;
    }
}
