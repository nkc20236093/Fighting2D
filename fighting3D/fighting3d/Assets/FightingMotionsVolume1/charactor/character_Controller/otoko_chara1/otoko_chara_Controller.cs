using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //Ray��錾
    Ray ray;
    //���C���΂�����
    float distance = 10f;
    //���C�������ɓ����������̏��
    RaycastHit hit;
    //���C�𔭎˂���ʒu
    Vector3 rayPos;

    //�ړ��̕ϐ�
    float sayuu;
    float jouge;

    //�W�����v�p���[�i����\��j
    float jump_power = 15f;

    //CharacterController��錾
    public CharacterController characterController;

    //���E�p�̈ړ������ϐ�
    Vector3 sayuu_houkou = Vector3.zero;

    //�W�����v�̑��x��ݒ�
    float Jump_velocity = 5.0f;

    //���n��Ԃ��Ǘ�
    public bool jump_isGrounded;  //���n���ĂȂ�=false
                              �@�@//���n���Ă�  =true

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
        //�ŏ��͒��n���ĂȂ����
        jump_isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���C�𔭎˂���ʒu�̒���
        rayPos = transform.position + new Vector3(0, 0.5f, 0);
        //���C�����ɔ�΂�
        ray = new Ray(rayPos, transform.up * -1);
        //�f�o�b�O�p�̃��C�𔭌�
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        //�W�����v���ĂȂ��ԁA�d�͂�������
        Jump_velocity += Physics.gravity.y * Time.deltaTime;
        Debug.Log("�d��");

        //���n��Ԃ��m�F
        if (Physics.Raycast(ray, out hit, distance))
        {
            //�ڒn������m���ɂ��邽��-0.5f����
            Jump_velocity = -0.5f;
            Debug.Log("���n���");
            //���C���n�ʂɃq�b�g���Ă邩�m�F
            if (hit.collider.tag == "jimen")
            {
                jump_isGrounded = true;
                Debug.Log("jimen");
            }
            else
            {
                jump_isGrounded = false;
                Debug.Log("hazure");
            }
        }

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

        //�n�ʂɂ��Ă���
        if (jump_isGrounded == true)
        {
            //�W�����v(�X�e�B�b�N or ����L�[(W�L�[))��������Ă邩�m�F
            if (jouge > 0)
            {
                Debug.Log("�W�����v");
                //�n�ʂ��痣���̂Œ��n��Ԃ���������
                jump_isGrounded = false;
                //Y���̑��x����
                Jump_velocity = jump_power;

                //�W�����v�̕�����������̃x�N�g���ɐݒ�
                //Vector3 jump_vector = Vector3.up;

                //�W�����v�̑��x���v�Z
                //Vector3 jump_velocity = jump_vector * Jump_velocity;

                //������̑��x��ݒ�
                //rigidbody.velocity = jump_velocity;

                //rigidbody.AddForce(rigidbody.velocity, jump_power);

            }
            characterController.Move(new Vector3(0, Jump_velocity, 0) * Time.deltaTime);
        }
        
    }
}
