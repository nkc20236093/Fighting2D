using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //�����ύX�p
    public Vector3 localscale;

    //�v���C���[�̈ړ������E���x�̕ϐ�
    Vector3 PlayerVector;

    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;

    //x��y�̈ړ�����
    float xleft = 3.4f, xright = -3.4f;
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

    //�W�����v�̑��x��ݒ�
    float Jump_velocity = 5.0f;

    //���n��Ԃ��Ǘ�
    public bool jump_isGrounded = false; //�ŏ��͒��n���ĂȂ���� 
                                         //���n���ĂȂ�=false
                                         //���n���Ă�  =true

    //���C���n�ʂɃq�b�g�������̔���
    public bool rayhit = false;
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

        animator = GetComponent<Animator>();
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

        //���݂̍��W���擾�i�ړ������p�j
        Vector3 Pos = transform.position;
        //�ړ�����
        Pos.x = Mathf.Clamp(Pos.x, xright, xleft);
        Pos.y = Mathf.Clamp(Pos.y, ydown, yup);
        transform.position = Pos;

        //���n��Ԃ��m�F
        if (Physics.Raycast(ray, out hit, distance))
        {
            //�ڒn������m���ɂ��邽��-0.5f����
            Jump_velocity = -0.5f;
            Debug.Log("���n���");
            //���C���n�ʂɃq�b�g���Ă邩�m�F
            if (hit.collider.CompareTag("jimen"))
            {
                rayhit = true;
            }
            else
            {
                jump_isGrounded = false;
            }
        }
        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetAxisRaw("X or J") != 0)
        {
            Debug.Log("��U��");
        }
        //���U���iA or K�j
        if (Input.GetAxisRaw("A or K") != 0)
        {
            Debug.Log("���U��");
        }
        //�����U���iB or L�j
        if (Input.GetAxisRaw("B or L") != 0)
        {
            Debug.Log("�����U��");
        }
        //�K�E�Z�iY or I�j
        if (Input.GetAxisRaw("Y or I") != 0)
        {
            Debug.Log("�K�E�Z");
        }
        //�ϐ���Horizontal�EVertical����
        PlayerVector = new Vector3(0, jouge, sayuu * 0.5f);
        sayuu = Input.GetAxisRaw("Horizontal");
        jouge = Input.GetAxisRaw("Vertical");

        //�n�ʂɂ��Ă���W�����v�͂�0�ɂ���
        if (jump_isGrounded == true || rayhit == true) 
        {
            jouge = 0f;
        }
        //���ړ�(�X�e�B�b�N or ���E���L�[)&�W�����v(�X�e�B�b�N or ����L�[(W�L�[))    
        transform.Translate(PlayerVector);

        //�ȉ��A�j���[�V����

        if (sayuu != 0)
        {
            Hantenn();
        }
        //��~���
        else
        {
            animator.SetBool("stop", true);
        }
        transform.localScale = localscale;
    }
    //���E���]����
    float Hantenn()
    {
        //�E�ړ�
        if (sayuu > 0)
        {
            //���]����
            Vector3 localscale = transform.localScale;
            localscale.z *= 1f;
            //�A�j���[�V�����ύX
            animator.SetBool("zensin", true);
            return localscale.z;
        }
        //���ړ�
        else if (sayuu < 0)
        {
            //���]����
            Vector3 localscale = transform.localScale;
            localscale.z *= -1f;
            //�A�j���[�V�����ύX
            animator.SetBool("zensin", true);
            return localscale.z;
        }
        else
        {
            return localscale.z;
        }
    }

    //�E�p
    //characterController�𗘗p���������蔻��
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("jimen"))  
        {
            Debug.Log("jimen");
            jump_isGrounded = true;
            jump_stop = true;
        }
    }
}
