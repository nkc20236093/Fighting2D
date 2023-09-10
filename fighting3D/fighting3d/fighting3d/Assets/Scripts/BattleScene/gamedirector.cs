using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
    public Otoko_chara_Controller otoko_Chara_Controller;
    public dekoi Dekoi;

    //攻撃被弾変数
    public int hidan;//デコイ用
    public int hidan_otoko1;//男キャラ1
    //攻撃付与変数
    public int attac;//デコイ用
    public int attack_otoko1;//男キャラ1
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //男キャラ1からdekoiへ攻撃
        if (otoko_Chara_Controller.otoko1_kougeki_attack != 0)
        {
            Debug.Log("男キャラ1攻撃");
            Otoko1_attack();
        }
        //dekoiから男キャラ1へ攻撃
        if (Dekoi.dekoi_kougeki_attack != 0)
        {
            Debug.Log("デコイ攻撃");
            Dekoi_attack();
        }
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.otoko1_kougeki_hit == 1)
        {
            hidan = 1;
            Debug.Log(hidan + "a");
        }
        if (otoko_Chara_Controller.otoko1_kougeki_hit == 2)
        {
            hidan = 2;
            Debug.Log(hidan + "b");
        }
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_kougeki_hit == 1)
        {
            Debug.Log(hidan_otoko1 + "c");
            hidan_otoko1 = 1;
        }
        if (Dekoi.dekoi_kougeki_hit == 2)
        {
            Debug.Log(hidan_otoko1 + "d");
            hidan_otoko1 = 2;
        }
    }
}
