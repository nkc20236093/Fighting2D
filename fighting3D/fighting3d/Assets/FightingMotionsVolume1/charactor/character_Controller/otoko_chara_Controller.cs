using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //�e�����X�e�[�^�X

    //HP
    int hp = 10;
    //�U����
    int attack = 10;
    //�f����
    int speed = 10;
    //�X�^�~�i
    int stamina = 10;
    //����
    int cleverness = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetAxisRaw("X or J") != 0)
        {

        }
        //���U���iA or K�j
        if (Input.GetAxisRaw("A or K") != 0)
        {

        }
        //�����U���iB or L�j
        if (Input.GetAxisRaw("B or L") != 0)
        {

        }
        //�K�E�Z�iY or I�j
        if (Input.GetAxisRaw("Y or I") != 0)
        {

        }
        //���ړ�(�X�e�B�b�N or ���L�[)
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

        }
        //�c�ړ�(�X�e�B�b�N or ���L�[)
        if (Input.GetAxisRaw("Vertical") != 0)
        {

        }
    }
}
