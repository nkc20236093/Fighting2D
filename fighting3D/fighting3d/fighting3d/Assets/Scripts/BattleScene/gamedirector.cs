using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
<<<<<<< HEAD

    
    public GauMan GauMan;

=======
>>>>>>> origin/main
    public object HPgauge;

    public Otoko_chara_Controller otoko_Chara_Controller;
    public dekoi Dekoi;

    //�U����e�ϐ�
    public int hidan;//�f�R�C�p
    public int hidan_otoko1;//�j�L����1

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�j�L����1����U��
        if (otoko_Chara_Controller.otoko1_kougeki_attack != 0)
        {
            Debug.Log("�j�L����1�U��");
            Otoko1_attack();
        }
        //dekoi����U��
        if (Dekoi.dekoi_kougeki_attack != 0)
        {
            Debug.Log("�f�R�C�U��");
            Dekoi_attack();
        }
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.attack_permission == true)
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_attack;
            Debug.Log(hidan + "a");
<<<<<<< HEAD
            Debug.Log("kougekiPlayerToEnmey");


          GauMan.DecreaseEnemyHPGauge(10);





}
=======
        }
>>>>>>> origin/main
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_attack_permission == true) 
        {
            Debug.Log(hidan_otoko1 + "c");
            hidan_otoko1 = Dekoi.dekoi_kougeki_attack;

            GauMan.DecreaseEnemyHPGauge(1);

        }
    }
}
