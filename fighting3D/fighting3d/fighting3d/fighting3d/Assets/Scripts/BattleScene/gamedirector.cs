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

    //�j�P���擾
    public Otoko_chara_Controller otoko_Chara_Controller;
    //dekoi���擾
    public dekoi Dekoi;

    //�U����e�ϐ�
    public int hidan;       //�f�R�C�p
    public int hidan_otoko1;//�j�L����1

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //�ϐ����펞�X�V
        hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
        //�L�����N�^�[����
        Player = otoko_Chara_Controller.transform.position;
        Enemy = Dekoi.transform.position;
        //�������߂�
        Distance_gamedirector = Player.x - Enemy.x;
        //��Βl��
        Distance = Mathf.Abs(Distance_gamedirector);

        //�j�L����1����U��
        if (otoko_Chara_Controller.otoko1_kougeki_hit != 0 && Dekoi.dekoi_kougeki_hit == 0 && otoko_Chara_Controller.otoko1_attack_bool) 
        {
            Debug.Log("�j�L����1�U��");
            Otoko1_attack();
        }
        if (otoko_Chara_Controller.attack_cooltime_permisson)
        {
            Debug.Log("����1");
        }
        if (otoko_Chara_Controller.attack_distance_permission)
        {
            Debug.Log("����2");
        }
        if (otoko_Chara_Controller.otoko1_kougeki_hit != 0)
        {
            Debug.Log("����3");
        }
        Debug.Log(hidan + "A");
        //dekoi����U��
        if (Dekoi.dekoi_kougeki_hit != 0 && otoko_Chara_Controller.otoko1_kougeki_hit == 0)
        {
            Debug.Log("�f�R�C�U��");
            Dekoi_attack();
        }
    }
    public void Otoko1_attack()
    {

        if (otoko_Chara_Controller.attack_distance_permission == true && otoko_Chara_Controller.attack_cooltime_permisson == true)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_hit;
            Debug.Log("kougekiPlayerToEnmey");
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_attack_permission == true && Dekoi.dekoi_cooltime_permisson == true)
        {
            hidan_otoko1 = Dekoi.dekoi_kougeki_hit;
            Debug.Log("kougekiEnemyToPlayer");
            GauMan.DecreaseEnemyHPGauge(10);
        }
    }
}
