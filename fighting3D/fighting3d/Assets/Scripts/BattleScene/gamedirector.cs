using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
    //Enemyฬtransformp
    Vector3 Enemy;
    //Playerฬtransformp
    Vector3 Player;
    //EnemyฦPlayerฬท
    float Distance_gamedirector;
    public float Distance;

    public GauMan GauMan;
    public object HPgauge;

    //jL1๐ๆพ
    public Otoko_chara_Controller otoko_Chara_Controller;
    //dekoi๐ๆพ
    public dekoi Dekoi;

    //Uํeฯ
    public int hidan;//fRCp
    public int hidan_otoko1;//jL1

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //ํXV
        hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
        hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
        //่ฤ
        Player = otoko_Chara_Controller.transform.position;
        Enemy = Dekoi.transform.position;
        //ท๐฿้
        Distance_gamedirector = Player.x - Enemy.x;
        //โฮlป
        Distance = Mathf.Abs(Distance_gamedirector);
        
        //jL1ฉ็U
        //if (otoko_Chara_Controller.otoko1_kougeki_hit != 0 && Dekoi.dekoi_kougeki_hit == 0 && otoko_Chara_Controller.otoko1_attack_timing == true) ;
        //{
        //    Debug.Log("jL1U");
        //    Otoko1_attack();
        //}
        ////dekoiฉ็U
        //if (Dekoi.dekoi_kougeki_hit != 0 && otoko_Chara_Controller.otoko1_kougeki_hit == 0)
        //{
        //    Debug.Log("fRCU");
        //    Dekoi_attack();
        //}
        if (Dekoi.jab_distance||Dekoi.kick_distance)
        {
            Debug.Log("๐1");
        }
        if (Dekoi.dekoi_cooltime_permisson)
        {
            Debug.Log("๐2");
        }
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.attack_distance_permission == true && otoko_Chara_Controller.attack_cooltime_permisson == true && otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
            Debug.Log("kougekiPlayerToEnmey");
            GauMan.DecreaseEnemyHPGauge(otoko_Chara_Controller.otoko1_damage);
        }
    }
    public void Dekoi_attack()
    {
        hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
        Debug.Log("kougekiEnemyToPlayer");
        GauMan.DecreaseHPGauge(Dekoi.dekoi_damage);
    }
}
