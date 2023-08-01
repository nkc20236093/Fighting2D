using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //�ړ��̕ϐ�
    float sayuu;
    float jouge;

    //���E�p�̈ړ������ϐ�
    Vector3 sayuu_houkou = Vector3.zero;

    //RigidBody��ϐ��ɕۑ�
    Rigidbody rigidbody;

    //�W�����v�̑��x��ݒ�
    private const float _velocity = 5.0f;

    //���n��Ԃ��Ǘ�
    private bool _isGrounded;

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
        //�ŏ��͒��n���ĂȂ����
        _isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {

        //�ϐ���Horizontal�EVertical����
        sayuu = Input.GetAxisRaw("Horizontal");
        jouge = Input.GetAxisRaw("Vertical");
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

        //�W�����v(�X�e�B�b�N or ����L�[(W�L�[))

        //���n��Ԃ��m�F
        if (_isGrounded == true)
        {
            //�W�����v(�X�e�B�b�N or ����L�[(W�L�[))��������Ă邩�m�F
            if (jouge != 0)
            {
                //�W�����v�̕�����������̃x�N�g���ɐݒ�
                Vector3 jump_vector = Vector3.up;

                //�W�����v�̑��x���v�Z
                Vector3 jump_velocity = jump_vector * _velocity;

                //������̑��x��ݒ�
                rigidbody.velocity = jump_velocity;

                //�n�ʂ��痣���̂Œ��n��Ԃ���������
                _isGrounded = false;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        //���n�����o�����̂Œ��n��Ԃ���������
        if (other.gameObject.tag == "jimen")
        {
            _isGrounded = true;
        }
    }
}
