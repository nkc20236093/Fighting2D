using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeSceneSwitcher : MonoBehaviour
{
    public void ToHomesHomeScene()               //�z�[���Y�z�[���V�[���փV�[���J�ڂ��܂�
    {

        SceneManager.LoadScene("Home'sHome");

    }
    public void ToHomesFriendBattleScene()�@�@�@�@//�t�����h�o�g����
    {

        SceneManager.LoadScene("Home'sFriendBattle");

    }
    public void ToHomesShopScene()�@�@�@�@�@�@�@�@//�V���b�v��
    {

        SceneManager.LoadScene("Home'sShop");

    }
    public void ToHomesGachaScene()�@�@�@�@�@�@�@�@//�K�`����
    {

        SceneManager.LoadScene("Home'sGacha");

    }
   //public void FromTrainingToSellectCharacter()
   // {

   // }
}
