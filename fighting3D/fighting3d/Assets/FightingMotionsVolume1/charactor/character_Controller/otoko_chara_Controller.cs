using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //RigidBody��ϐ��ɕۑ�
    Rigidbody rigidbody;

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
        Application.targetFrameRate = 60;
        this.rigidbody = GetComponent < Rigidbody > ();
    }

    // Update is called once per frame
    void Update()
    {

        //�ϐ���Horizontal�EVertical����
        float sayuu = Input.GetAxisRaw("Horizontal");
        float jouge = Input.GetAxisRaw("Vertical");
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
        //���ړ�(�X�e�B�b�N or ���E���L�[)
        if (sayuu != 0)
        {

        }

        //�W�����v(�X�e�B�b�N or ����L�[)
        if (jouge != 0)
        {
            this.rigidbody.AddForce(transform.up * jouge);
        }
    }
}
