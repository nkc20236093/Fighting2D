using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
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
        //����������Ȃ�������ϐ���x�����ď�����
        if (!Input.anyKeyDown)
        {
            Invoke(nameof(Chien_gamedirector), 0.2f);
        }
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
        if (otoko_Chara_Controller.otoko1_kougeki_attack == 1) 
        {
            hidan = 1;
            Debug.Log(hidan + "a");
        }
        if (otoko_Chara_Controller.otoko1_kougeki_attack == 2)
        {
            hidan = 2;
            Debug.Log(hidan + "b");
        }
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_kougeki_attack == 1)
        {
            Debug.Log(hidan_otoko1 + "c");
            hidan_otoko1 = 1;
        }
        if (Dekoi.dekoi_kougeki_attack == 2)
        {
            Debug.Log(hidan_otoko1 + "d");
            hidan_otoko1 = 2;
        }
    }
    public void Chien_gamedirector()
    {
        hidan = 0;
        hidan_otoko1 = 0;
    }
}
