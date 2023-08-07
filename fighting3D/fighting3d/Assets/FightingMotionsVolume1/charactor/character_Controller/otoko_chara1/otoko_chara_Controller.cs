using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //x��y�̈ړ�����
    float xleft = 3.5f, xright = -3.5f;
    float ydown = 5f, yup = 9f;

    //�ʏ�X�s�[�h
    float normal_speed = 50;
    //�_�b�V���X�s�[�h
    float dash_speed;
    //���݂̃X�s�[�h���[�h
    float now_speed = 10;
 
    //Ray��錾
    Ray ray;
    //���C���΂�����
    public float distance = 0.5f;
    //���C�������ɓ����������̏��
    RaycastHit hit;
    //���C�𔭎˂���ʒu
    Vector3 rayPos;

    //�ړ��̕ϐ�
    float sayuu;
    float jouge;

    //�W�����v�p���[�i����\��j
    float jump_power = 5f;
    //2�i�W�����v�֎~�p
    public bool jump_stop = false; //false = �֎~
                                   //true  = ����


    //�ړ��i�����j�X�s�[�h
    Vector3 speed_origin;

    //CharacterController��錾
    public CharacterController characterController;

    //���E�p�̈ړ������ϐ�
    Vector3 sayuu_houkou = Vector3.zero;

    //�W�����v�̑��x��ݒ�
    float Jump_velocity = 5.0f;

    //���n��Ԃ��Ǘ�
    public bool jump_isGrounded = false; //�ŏ��͒��n���ĂȂ���� 
                                         //���n���ĂȂ�=false
                                         //���n���Ă�  =true

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
        //�ŏ��Ɍ��݂̃X�s�[�h�ɒʏ�X�s�[�h����
        now_speed = normal_speed;

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //��ɏd�͂�������
        //characterController.Move(new Vector3(0, Physics.gravity.y, 0));

        //���C�𔭎˂���ʒu�̒���
        rayPos = transform.position + new Vector3(0, 0.25f, 0);
        //���C�����ɔ�΂�
        ray = new Ray(rayPos, transform.up * -1);
        //�f�o�b�O�p�̃��C�𔭌�
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        ////�W�����v���ĂȂ��ԁA�d�͂�������
        Jump_velocity += Physics.gravity.y * Time.deltaTime;
        Debug.Log("�d��");

        //���݂̍��W���擾
        Vector3 Pos = transform.position;

        //���n��Ԃ��m�F
        if (Physics.Raycast(ray, out hit, distance))
        {
            //�ڒn������m���ɂ��邽��-0.5f����
            Jump_velocity = -0.5f;
            Debug.Log("���n���");
            //���C���n�ʂɃq�b�g���Ă邩�m�F
            if (hit.collider.tag == "jimen")
            {
                jump_stop = true;
                jump_isGrounded = true;
                Debug.Log("jimen");
                speed_origin = Vector3.zero;
            }
            else
            {
                jump_isGrounded = false;
                Debug.Log("hazure");
            }
        }

        //�ړ�����
        Pos.x = Mathf.Clamp(Pos.x, xright,xleft);
        Pos.y = Mathf.Clamp(Pos.y, yup, ydown);
        transform.position = Pos;

        //�ϐ���Horizontal�EVertical����
        var idou = new Vector3(sayuu, jouge, 0);
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
            Debug.Log("sayuu");
            speed_origin.x = idou.normalized.x * 2;
            speed_origin.y = idou.normalized.y * 2;
        }

        //�W�����v(�X�e�B�b�N or ����L�[(W�L�[)

        //�n�ʂɂ��Ă���&�W�����v(�X�e�B�b�N or ����L�[(W�L�[))��������Ă邩�m�F&2�i�W�����v�֎~
        if (jouge > 0 && jump_stop && jump_isGrounded == true) 
        {
            Debug.Log("�W�����v");
            speed_origin.y = jump_power;
            //�n�ʂ��痣���̂Œ��n��Ԃ���������
            jump_isGrounded = false;
            //�n�ʂ��痣���̂�jump_stop��false�ɐ؂�ւ�
            jump_stop = false;
        }

        speed_origin.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(new Vector3((speed_origin.x*-1), speed_origin.y, 0) * Time.deltaTime);
    }
}
