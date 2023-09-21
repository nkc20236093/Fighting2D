using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GauMan : MonoBehaviour
{
    public Slider HPGaugeSlider;
    public Slider EnemyHPGaugeSlider;
    public Slider StaGaugeSlider;
    public Slider EnemyStaGaugeSlider;
    public Slider SkiGaugeSlider;
    public Slider EnemySkiGaugeSlider;


    public static float maxHPGauge = 130f;
    public static float currentHPGauge;

    public static float maxEnemyHPGauge = 130f;
    public static float currentEnemyHPGauge;

    public static float maxStaGauge = 100f;
    public static float currentStaGauge;

    public static float maxEnemyStaGauge = 100f;
    public static float currentEnemyStaGauge;
    
    public static float maxSkiGauge = 100f;
    public static float currentSkiGauge;

    public static float maxEnemySkiGauge = 100f;
    public static float currentEnemySkiGauge;


    // Start is called before the first frame update
    void Start()
    {
        currentHPGauge = maxHPGauge;

        currentEnemyHPGauge = maxEnemyHPGauge;

        currentStaGauge = maxStaGauge;

        currentEnemyStaGauge = maxEnemyStaGauge;

        currentSkiGauge = maxSkiGauge;

        currentEnemySkiGauge = maxEnemySkiGauge;
        UpdateGaugeUI();
    }

    private void UpdateGaugeUI()
    {
        HPGaugeSlider.value = currentHPGauge / maxHPGauge;

        EnemyHPGaugeSlider.value =
            currentEnemyHPGauge / maxEnemyHPGauge;

        StaGaugeSlider.value =
            currentStaGauge / maxStaGauge;

        EnemyStaGaugeSlider.value =
            currentEnemyStaGauge / maxEnemyStaGauge;

        SkiGaugeSlider.value = currentSkiGauge / maxSkiGauge;

        EnemySkiGaugeSlider.value =
            currentEnemySkiGauge / maxEnemySkiGauge;




    }



    // Player HP decrease increase

    public void DecreaseHPGauge(float amount)
    {
        currentHPGauge -= amount;
        if (currentHPGauge < 0)
            currentHPGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseHPGauge(float amount)
    {
        currentHPGauge += amount;
        if (currentHPGauge > maxHPGauge)
            currentHPGauge = maxHPGauge;

        UpdateGaugeUI();
    }

    // Enemy HP increase  decrease

    public void DecreaseEnemyHPGauge(float amount)
    {
        currentEnemyHPGauge -= amount;
        if (currentEnemyHPGauge < 0)
            currentEnemyHPGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseEnemyHPGauge(float amount)
    {
        currentEnemyHPGauge += amount;
        if (currentEnemyHPGauge > maxEnemyHPGauge)
            currentEnemyHPGauge = maxEnemyHPGauge;

        UpdateGaugeUI();
    }

    // Player Sta increase decrease 

    public void DecreaseStaGauge(float amount)
    {
        currentStaGauge -= amount;
        if (currentStaGauge < 0)
            currentStaGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseStaGauge(float amount)
    {
        currentStaGauge += amount;
        if (currentStaGauge > maxStaGauge)
            currentStaGauge = maxStaGauge;

        UpdateGaugeUI();
    }



    // Enemy Sta Increase and Decrease

    public void DecreaseEnemyStaGauge(float amount)
    {
        currentEnemyStaGauge -= amount;
        if (currentEnemyStaGauge < 0)
            currentEnemyStaGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseEnemyStaGauge(float amount)
    {
        currentEnemyStaGauge += amount;
        if (currentEnemyStaGauge > maxEnemyStaGauge)
            currentEnemyStaGauge = maxEnemyStaGauge;

        UpdateGaugeUI();
    }



    // Player Ski Increase Decrease 


    public void DecreaseSkiGauge(float amount)
    {
        currentSkiGauge -= amount;
        if (currentSkiGauge < 0)
            currentSkiGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseSkiGauge(float amount)
    {
        currentSkiGauge += amount;
        if (currentSkiGauge > maxSkiGauge)
            currentSkiGauge = maxSkiGauge;

        UpdateGaugeUI();
    }



    //Enemy Sta increase decrease



    public void DecreaseEnemySkiGauge(float amount)
    {
        currentEnemySkiGauge -= amount;
        if (currentEnemySkiGauge < 0)
            currentEnemySkiGauge = 0;

        UpdateGaugeUI();
    }

    public void IncreaseEnemySkiGauge(float amount)
    {
        currentEnemySkiGauge += amount;
        if (currentEnemySkiGauge > maxEnemySkiGauge)
            currentEnemySkiGauge = maxEnemySkiGauge;

        UpdateGaugeUI();
    }



    public void DecreaseEnemyHPGaugeAndStaGauge(float amount)
    {
        currentEnemyHPGauge -= amount;
        if (currentEnemyHPGauge < 0)
            currentEnemyHPGauge = 0;



        //UpdateGaugeUI();


        currentStaGauge -= amount;
        if (currentStaGauge < 0)
            currentStaGauge = 0;

        UpdateGaugeUI();



        UpdateGaugeUI();
    }

}
