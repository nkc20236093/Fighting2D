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
    float Distance_gamedirector;
    public float Distance;

    public GauMan GauMan;
    public object HPgauge;

    //�j�L����1���擾
    public Otoko_chara_Controller otoko_Chara_Controller;
    //dekoi���擾
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
        //�펞�X�V
        hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
        hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
        //���蓖��
        Player = otoko_Chara_Controller.transform.position;
        Enemy = Dekoi.transform.position;
        //�������߂�
        Distance_gamedirector = Player.x - Enemy.x;
        //��Βl��
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
