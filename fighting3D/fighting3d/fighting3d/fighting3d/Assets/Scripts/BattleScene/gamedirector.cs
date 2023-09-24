using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
    //Enemyのtransform用
    Vector3 Enemy;
    //Playerのtransform用
    Vector3 Player;
    //EnemyとPlayerの差
    float Distance_gamedirector;
    public float Distance;

    public GauMan GauMan;
    public object HPgauge;

    public Otoko_chara_Controller otoko_Chara_Controller;
    public dekoi Dekoi;

    //攻撃被弾変数
    public int hidan;//デコイ用
    public int hidan_otoko1;//男キャラ1

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Player = otoko_Chara_Controller.transform.position;
        Enemy = Dekoi.transform.position;
        Distance_gamedirector = Player.x - Enemy.x;
        //絶対値化
        Distance = Mathf.Abs(Distance_gamedirector);

        //男キャラ1から攻撃
        if (otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            Debug.Log("男キャラ1攻撃");
            Otoko1_attack();
        }
        //dekoiから攻撃
        else if (Dekoi.dekoi_kougeki_hit != 0)
        {
            Debug.Log("デコイ攻撃");
            Dekoi_attack();
        }
        if (otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            Debug.Log("条件1");
        }
        if (otoko_Chara_Controller.attack_cooltime_permisson)
        {
            Debug.Log("条件2");
        }
        if (otoko_Chara_Controller.attack_distance_permission)
        {
            Debug.Log("条件3");
        }
        Debug.Log(otoko_Chara_Controller.otoko1_kougeki_hit + "ディレクター");
    }
    public void Otoko1_attack()
    {
        
        if (otoko_Chara_Controller.attack_distance_permission == true && otoko_Chara_Controller.attack_cooltime_permisson == true && otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
            Debug.Log("kougekiPlayerToEnmey");
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_attack_permission == true && Dekoi.dekoi_cooltime_permisson == true && otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
            Debug.Log("kougekiEnemyToPlayer");
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
}
