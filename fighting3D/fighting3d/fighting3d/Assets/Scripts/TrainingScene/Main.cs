using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text textHP;
    public Text textPower;
    public Text textSpeed;
    public Text textStamina;
    public Text textCleverness;

    int countHP = 0;
    int countPower = 0;
    int countSpeed = 0;
    int countStamina = 0;
    int countCleverness = 0;


    public void OnPushButtonHP()
    {
        countHP ++;
        textHP.text= "HP: " + countHP;

    }
    public void OnPushButtonPower()
    {
        countPower++;
        textPower.text = "�U����: " + countPower;

    }
    public void OnPushButtonSpeed()
    {
        countSpeed++;
        textSpeed.text = "�f����: " + countSpeed;

    }
    public void OnPushButtonStamina()
    {
        countStamina++;
        textStamina.text = "�X�^�~�i: " + countStamina;

    }
    public void OnPushButtonCleverness()
    {
        countCleverness++;
        textCleverness.text = "����: " + countCleverness;

    }



}
