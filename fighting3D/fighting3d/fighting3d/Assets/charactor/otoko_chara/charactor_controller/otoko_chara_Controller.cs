using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //�U�����󂯂��E�^������Ԃ��Ǘ�����p�̕ϐ�
    public float kougeki_attack;

    //Transform�R���|�[�l���g���擾
    Transform mytransform;
    //�����ύX�p�ϐ�
    float chara_muki;
    //�����ύX�̊Ǘ��p
    public bool muki;  //false = �E
                       //true  = ��

    //�v���C���[�̈ړ������E���x�̕ϐ�
    Vector3 PlayerVector;

    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;

    //�d�͗p�ϐ�
    public Vector3 gravity = new Vector3(Physics.gravity.x, 0, Physics.gravity.z);

    //�ʏ�X�s�[�h
    float normal_speed = 50;
    //�_�b�V���X�s�[�h
    float dash_speed;
    //���݂̃X�s�[�h���[�h
    float now_speed;
 
    ////Ray��錾
    //Ray ray;
    ////���C���΂�����
    //float distance = 0.001f;
    ////���C�������ɓ����������̏��
    //RaycastHit hit;
    ////���C�𔭎˂���ʒu
    //Vector3 rayPos;

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
        //�����̉�]�x���擾
        mytransform = this.transform;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        ////���C�𔭎˂���ʒu�̒���
        //rayPos = transform.position + new Vector3(0, 0, 0);
        ////���C�����ɔ�΂�
        //ray = new Ray(rayPos, transform.up * -1);
        ////�f�o�b�O�p�̃��C�𔭌�
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        ////���n��Ԃ��m�F
        //if (Physics.Raycast(ray, out hit, distance))
        //{
        //    //�ڒn������m���ɂ��邽��-0.5f����
        //    Jump_velocity = -0.5f;
        //    Debug.Log("���n���");
        //    //���C���n�ʂɃq�b�g���Ă邩�m�F
        //    if (hit.collider.CompareTag("jimen"))
        //    {
        //        rayhit = true;
        //    }
        //    else
        //    {
        //        jump_isGrounded = false;
        //    }
        //}
        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetAxisRaw("X or J") != 0)
        {
            animator.SetInteger("stop", 2);
            Debug.Log("��U��");
            kougeki_attack = 1;
        }
        //�e�s���I�������~��ԂɕύX
        else
        {
            //�A�j���[�V�����ύX
            Invoke(nameof(animation_stop), 5f);
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
        //�K�[�h(Right(left) Bumper or sperce)   ���W���X�g�K�[�h������
        if (Input.GetButtonDown("Right(left) Bumper or sperce")) 
        {
            Debug.Log("�K�[�h");
        }
        //�ϐ���Horizontal�EVertical����
        sayuu = Input.GetAxisRaw("Horizontal");
        jouge = Input.GetAxisRaw("Vertical");
        //��ɏd�͂�������
        //�n�ʂɑ������Ă���
        if (characterController.isGrounded)
        {
            gravity = new Vector3(Physics.gravity.x, -9.81f, Physics.gravity.z);
            Debug.Log("�d��");
        }
        //�n�ʂɑ������ĂȂ�������
        else
        {
            Debug.Log("NOT�d��");
            gravity = new Vector3(Physics.gravity.x, 0, Physics.gravity.z);
        }
        characterController.Move(gravity);

        //�����ύX�p
        if (sayuu > 0)
        {
            muki = false;
        }
        else if (sayuu < 0)
        {
            muki = true;
        }
        //���ړ�(�X�e�B�b�N or ���E���L�[)&�W�����v(�X�e�B�b�N or ����L�[(W�L�[))    
        characterController.Move(new Vector3(sayuu * 0.15f * chara_muki, jouge, 0));

        //�ȉ��A�j���[�V����

        //���[���h���W����ɉ�]���擾
        Vector3 World_angle = mytransform.eulerAngles;
        //���E�ǂ��炩�Ɉړ���
        if (sayuu != 0)
        {
            //�E�ړ�
            if (muki == false)
            {
                //���]����
                World_angle.y = -90;
                chara_muki = -1;
                //�A�j���[�V�����ύX
                animator.SetInteger("stop", 1);
            }
            //���ړ�
            else
            {
                //���]����
                World_angle.y = 90;
                //�A�j���[�V�����ύX
                chara_muki = -1;
                animator.SetInteger("stop", 1);
            }
        }
        //��~���
        else
        {
            //�A�j���[�V�����ύX
            Invoke(nameof(animation_stop), 1f);
        }
        mytransform.eulerAngles = World_angle;
    }
    //��~��Ԃ̃A�j���[�V����
    void animation_stop()
    {
        animator.SetInteger("stop", 0);
        kougeki_attack = 0;
    }
    //characterController�𗘗p���������蔻��
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("jimen"))  
        {
            Debug.Log("jimen");
            jump_isGrounded = true;
            jump_stop = true;
        }
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("�m�F");
        }
        ChakItem(hit.collider.gameObject);
    }
    void ChakItem(GameObject obj)
    {
        if (obj.CompareTag("Player") && kougeki_attack > 0)
        {
            Debug.Log("hit_player");
            Invoke(nameof(animation_stop), 5f);
        }
    }
}
