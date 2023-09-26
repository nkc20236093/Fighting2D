using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraGaugeManager : MonoBehaviour
{
    public Slider traGaugeSlider;
    public static float maxTraGauge = 100f;
    public static float currentTraGauge;



    // Start is called before the first frame update
    void Start()
    {
        currentTraGauge = maxTraGauge;
        UpdateGaugeUI();
    }

    private void UpdateGaugeUI()
    {
        traGaugeSlider.value = currentTraGauge / maxTraGauge;
    }

    public void DecreaseGauge(float amount)
    {
        currentTraGauge -= amount;
        if (currentTraGauge < 0)
            currentTraGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseGauge(float amount)
    {
        currentTraGauge += amount;
        if (currentTraGauge > maxTraGauge)
            currentTraGauge = maxTraGauge;

        UpdateGaugeUI();
    }



  
}
