using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleSceneSwitcher : MonoBehaviour
{

    public void FromTitleToHome()       //タイトルシーンからホームズホームシーンにシーン遷移します
    {
        SceneManager.LoadScene("BattleScene");
    }





}
