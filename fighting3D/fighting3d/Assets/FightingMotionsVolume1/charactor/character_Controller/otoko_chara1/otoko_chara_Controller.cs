using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //�v���C���[�̈ړ������E���x�̕ϐ�
    Vector3 PlayerVector;

    //x��y�̈ړ�����
    float xleft = 3.5f, xright = -3.5f;
    float ydown = 5f, yup = 9f;

    //�ʏ�X�s�[�h
    float normal_speed = 50;
    //�_�b�V���X�s�[�h
    float dash_speed;
    //���݂̃X�s�[�h���[�h
    float now_speed;
 
    //Ray��錾
    Ray ray;
    //���C���΂�����
    public float distance = 0.001f;
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

    //rigidbody���擾
    Rigidbody rigid;

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

        rigid = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //���C�𔭎˂���ʒu�̒���
        rayPos = transform.position + new Vector3(0, 0, 0);
        //���C�����ɔ�΂�
        ray = new Ray(rayPos, transform.up * -1);
        //�f�o�b�O�p�̃��C�𔭌�
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        //���݂̍��W���擾
        Vector3 Pos = transform.position;
        //�ړ�����
        Pos.x = Mathf.Clamp(Pos.x, xleft, xright);
        Pos.y = Mathf.Clamp(Pos.y, ydown, yup);
        transform.position = Pos;

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

        //�ϐ���Horizontal�EVertical����
        PlayerVector = new Vector3(sayuu, jouge, 0);
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
        //�n�ʂɂ��Ă���
        if (jump_isGrounded == true)
        {
            //���ړ�(�X�e�B�b�N or ���E���L�[)
            if (sayuu != 0)
            {
                Debug.Log("sayuu");
                speed_origin.x = PlayerVector.normalized.x * 2;
            }
            //&�W�����v(�X�e�B�b�N or ����L�[(W�L�[))��������Ă邩�m�F&2�i�W�����v�֎~
            if (jouge > 0 && jump_stop)
            {
                Debug.Log("�W�����v");
                speed_origin.y = PlayerVector.normalized.y * 5;
                //speed_origin.y = jump_power;
                //�n�ʂ��痣���̂Œ��n��Ԃ���������
                jump_isGrounded = false;
                //�n�ʂ��痣���̂�jump_stop��false�ɐ؂�ւ�
                jump_stop = false;
            } 
        }
        PlayerVector = transform.TransformDirection(PlayerVector);
        speed_origin.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(new Vector3((speed_origin.x * -1), speed_origin.y, 0) * Time.deltaTime);
    }
}
