using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text textHP;              //�琬�L�����̂g�o
    public Text textPower;�@�@�@//�U����
    public Text textSpeed;�@�@�@//�f����
    public Text textStamina;�@�@�@//�X�^�~�i
    public Text textCleverness;�@�@�@//����

    int countHP = 0;                      //�e�X�e�[�^�X�̒l�������ɕۑ����܂�
    int countPower = 0;
    int countSpeed = 0;
    int countStamina = 0;
    int countCleverness = 0;


    public void OnPushButtonHP()�@�@�@�@�@�@�@//HP�琬�{�^���������Ăg�o�̒l�𑝂₵�܂�
    {
        countHP ++;�@�@�@�@�@�@�@�@�@�@�@�@�@�@//���̈琬�̏オ�蕝�@�P�@�i���j
        textHP.text= "HP: " + countHP;

    }
    public void OnPushButtonPower()�@�@�@�@�@�@�@
    {
        countPower++;�@�@�@�@�@�@�@
        textPower.text = "�U����: " + countPower;

    }
    public void OnPushButtonSpeed()�@�@�@�@�@�@�@�@�@�@
    {
        countSpeed++;
        textSpeed.text = "�f����: " + countSpeed;

    }
    public void OnPushButtonStamina()�@�@�@�@�@�@�@�@
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
