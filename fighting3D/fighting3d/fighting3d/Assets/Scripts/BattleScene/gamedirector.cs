using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
    //Enemy��transform�p
    Vector3 Enemy;
    //Player��transform�p
    Vector3 Player;
    //Enemy��Player�̍�
    public float Distance_gamedirector;

    public GauMan GauMan;
    public object HPgauge;

    public Otoko_chara_Controller otoko_Chara_Controller;
    public dekoi Dekoi;

    //�U����e�ϐ�
    public int hidan;//�f�R�C�p
    public int hidan_otoko1;//�j�L����1

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

        //�j�L����1����U��
        if (otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            Debug.Log("�j�L����1�U��");
            Otoko1_attack();
        }
        //dekoi����U��
        else if (Dekoi.dekoi_kougeki_hit != 0)
        {
            Debug.Log("�f�R�C�U��");
            Dekoi_attack();
        }
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.attack_permission == true && otoko_Chara_Controller.attack_cooltime_permisson == true)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
            Debug.Log(hidan + "a");
            Debug.Log("kougekiPlayerToEnmey");
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
        public void Dekoi_attack()
    {
        if (Dekoi.dekoi_attack_permission == true && Dekoi.dekoi_cooltime_permisson == true) 
        {
            Debug.Log(hidan_otoko1 + "c");
            hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
}
