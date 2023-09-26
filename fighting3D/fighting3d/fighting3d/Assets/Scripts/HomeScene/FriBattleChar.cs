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
        Chara.text = "タケル";
    }
    public void RyoSelect()
    {
        Chara.text = "リョウ";
    }
    public void RinSelect()
    {
        Chara.text = "リン";
    }
    public void NoaSelect()
    {
        Chara.text = "ノア";
    }
    public void KaedeSelect()
    {
        Chara.text = "カエデ";
    }




    //chara 2



    public void Takeru2Select()
    {
        Chara2.text = "タケル";
    }
    public void Ryo2Select()
    {
        Chara2.text = "リョウ";
    }
    public void Rin2Select()
    {
        Chara2.text = "リン";
    }
    public void Noa2Select()
    {
        Chara2.text = "ノア";
    }
    public void Kaede2Select()
    {
        Chara2.text = "カエデ";
    }





}
