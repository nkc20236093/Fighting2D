using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaInfoUber : MonoBehaviour
{
   // [SerializeField] Main main;

    public void TakeruStatusUberMethod()
    {
        Main.HP = 125;                                           //�I���status���o���ɂ�
        �@�@�@�@�@�@�@�@�@�@�@/*�T  �@�@�̗�
                                                �O�D�Q�T�@�U��
                                                �O�D�Q�T�@�r�q
                                               �Q�D�T�@�@���v
                                                �P�O         �n�m
                  �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�����ꂼ�ꂽ��
                                                               */
                                                                 
        Main.Power = 4.75f;
        Main.Speed = 2.75f;
        Main.Stamina = 67.5f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
        
    }
    public void RyuStatusUberMethod()
    {
        Main.HP = 95f;
        Main.Power = 2.75f;
        Main.Speed = 4.75f;
        Main.Stamina = 97.5f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }
    public void RinStatusUberMethod()
    {
        Main.HP = 70;
        Main.Power = 1.75f;
        Main.Speed = 9.75f;
        Main.Stamina = 147.5f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }
    public void NoaStatusUberMethod()
    {
        Main.HP = 95f;
        Main.Power = 0.75f;
        Main.Speed = 2.75f;
        Main.Stamina = 87.5f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }
    public void KaedeStatusUberMethod()
    {
        Main.HP = 70f;
        Main.Power = 1.75f;
        Main.Speed = 5.25f;
        Main.Stamina = 97.5f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
