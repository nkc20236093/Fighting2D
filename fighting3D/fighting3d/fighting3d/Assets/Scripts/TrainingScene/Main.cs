using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text textHP;              //育成キャラのＨＰ
    public Text textPower;　　　//攻撃力
    public Text textSpeed;　　　//素早さ
    public Text textStamina;　　　//スタミナ
    public Text textCleverness;　　　//賢さ

    int countHP = 0;                      //各ステータスの値をここに保存します
    int countPower = 0;
    int countSpeed = 0;
    int countStamina = 0;
    int countCleverness = 0;


    public void OnPushButtonHP()　　　　　　　//HP育成ボタンを押してＨＰの値を増やします
    {
        countHP ++;　　　　　　　　　　　　　　//一回の育成の上がり幅　１　（仮）
        textHP.text= "HP: " + countHP;

    }
    public void OnPushButtonPower()　　　　　　　
    {
        countPower++;　　　　　　　
        textPower.text = "攻撃力: " + countPower;

    }
    public void OnPushButtonSpeed()　　　　　　　　　　
    {
        countSpeed++;
        textSpeed.text = "素早さ: " + countSpeed;

    }
    public void OnPushButtonStamina()　　　　　　　　
    {
        countStamina++;
        textStamina.text = "スタミナ: " + countStamina;

    }
    public void OnPushButtonCleverness()
    {
        countCleverness++;
        textCleverness.text = "賢さ: " + countCleverness;

    }



}
