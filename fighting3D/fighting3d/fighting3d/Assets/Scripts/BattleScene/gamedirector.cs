using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{    
    public GauMan GauMan;
    public object HPgauge;

    int test;
    int test2;
    public Otoko_chara_Controller otoko_Chara_Controller;
    public dekoi Dekoi;

    //UνeΟ
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
        //jL1©ηU
        if (otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            Debug.Log("jL1U");
            Otoko1_attack();
        }
        //dekoi©ηU
        else if (Dekoi.dekoi_kougeki_hit != 0)
        {
            Debug.Log("fRCU");
            Dekoi_attack();
        }
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.attack_permission == true)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
            Debug.Log("kougekiPlayerToEnmey");
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_attack_permission == true) 
        {
            hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
            test = Dekoi.dekoi_kougeki_attack;
            test2 = hidan_otoko1;
            GauMan.DecreaseEnemyHPGauge(1);
        }
    }
}
