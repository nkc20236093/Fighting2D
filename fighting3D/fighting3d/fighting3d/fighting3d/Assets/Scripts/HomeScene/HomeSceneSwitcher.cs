using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeSceneSwitcher : MonoBehaviour
{
    public void ToHomesHomeScene()               //ホームズホームシーンへシーン遷移します
    {

        SceneManager.LoadScene("Home'sHome");

    }
    public void ToHomesFriendBattleScene()　　　　//フレンドバトルへ
    {

        SceneManager.LoadScene("Home'sFriendBattle");

    }
    public void ToHomesShopScene()　　　　　　　　//ショップへ
    {

        SceneManager.LoadScene("Home'sShop");

    }
    public void ToHomesGachaScene()　　　　　　　　//ガチャへ
    {

        SceneManager.LoadScene("Home'sGacha");

    }
   //public void FromTrainingToSellectCharacter()
   // {

   // }
}
