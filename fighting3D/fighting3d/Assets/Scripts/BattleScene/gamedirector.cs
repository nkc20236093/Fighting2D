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

    //男キャラ1を取得
    public Otoko_chara_Controller otoko_Chara_Controller;
    //dekoiを取得
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
        //常時更新
        hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
        hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
        //割り当て
        Player = otoko_Chara_Controller.transform.position;
        Enemy = Dekoi.transform.position;
        //差を求める
        Distance_gamedirector = Player.x - Enemy.x;
        //絶対値化
        Distance = Mathf.Abs(Distance_gamedirector);        
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.attack_distance_permission == true && otoko_Chara_Controller.attack_cooltime_permisson == true && otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
            GauMan.DecreaseEnemyHPGauge(otoko_Chara_Controller.otoko1_damage);
        }
    }
    public void Dekoi_attack()
    {
        hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
        GauMan.DecreaseHPGauge(Dekoi.dekoi_damage);
    }
}
