using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Text textHP;              //�琬�L�����̂g�o
    public Text textPower;�@�@�@//�U����
    public Text textSpeed;�@�@�@//�f����
    public Text textStamina;�@�@�@//�X�^�~�i
    public Text textCleverness;   //����

    public static int HP = 0;                      //�X�e�[�^�X
    public static int Power = 0;
    public static int Speed = 0;
    public static int Stamina = 0;
    public static int Cleverness = 0;

    int countHP = 0;                      //�g���[�j���O��
    int countPower = 0;
    int countSpeed = 0;
    int countStamina = 0;
    int countCleverness = 0;


    int UpNumberHP= 10;
    int UpNumberPower= 10;
    int UpNumberSpeed= 10;
    int UpNumberStamina= 10;
    int UpNumberCleverness= 10;
    void Start()
    {
        textHP.text = "" + HP;
        textPower.text = "" + Power;
        textSpeed.text = "" + Speed;
        textStamina.text = "" + Stamina;
        textCleverness.text = "" + Cleverness;
    }
    public void OnPushButtonHP()�@�@�@�@�@�@�@//HP�琬�{�^���������Ăg�o�̒l�𑝂₵�܂�
    {
        countHP += 1;�@�@�@�@�@�@�@�@�@//���̈琬�̏オ�蕝�@�P�@�i���j
       
        if(countHP >= 4 && countHP <= 7)
        {
           // Debug.Log("afoafo");
            int UpNumberHP = 20;

        }
        if (countHP >= 8 && countHP <= 11)
        {
            int UpNumberHP = 30;

        }
        if (countHP >= 12 && countHP <= 15)
        {
            int UpNumberHP = 40;

        }
        if (countHP >= 16)
        {
            int UpNumberHP = 50;

        }
        HP += UpNumberHP;
        Debug.Log(HP);
        //Debug.Log(countHP);
        textHP.text = "" + HP;
    }
    public void OnPushButtonPower()�@�@�@�@�@�@�@
    {
        countPower++;�@�@�@�@�@�@�@
        textPower.text = "" + UpNumberPower;

    }
    public void OnPushButtonSpeed()�@�@�@�@�@�@�@�@�@�@
    {
        countSpeed++;
        textSpeed.text = "" + UpNumberSpeed;

    }
    public void OnPushButtonStamina()�@�@�@�@�@�@�@�@
    {
        countStamina++;
        textStamina.text = "" + UpNumberStamina;

    }
    public void OnPushButtonCleverness()
    {
        countCleverness++;
        textCleverness.text = "" + UpNumberCleverness;

    }



}
