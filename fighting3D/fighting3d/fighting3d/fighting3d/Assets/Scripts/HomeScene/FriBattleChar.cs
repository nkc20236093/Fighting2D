using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriBattleChar : MonoBehaviour
{
    public Text Chara;

    public Text Chara2;





    public void TakeruSelect()
    {

        Debug.Log("akia");
        Chara.text = "�^�P��";
    }
    public void RyoSelect()
    {
        Chara.text = "�����E";
    }
    public void RinSelect()
    {
        Chara.text = "����";
    }
    public void NoaSelect()
    {
        Chara.text = "�m�A";
    }
    public void KaedeSelect()
    {
        Chara.text = "�J�G�f";
    }




    //chara 2



    public void Takeru2Select()
    {
        Chara2.text = "�^�P��";
    }
    public void Ryo2Select()
    {
        Chara2.text = "�����E";
    }
    public void Rin2Select()
    {
        Chara2.text = "����";
    }
    public void Noa2Select()
    {
        Chara2.text = "�m�A";
    }
    public void Kaede2Select()
    {
        Chara2.text = "�J�G�f";
    }





}
