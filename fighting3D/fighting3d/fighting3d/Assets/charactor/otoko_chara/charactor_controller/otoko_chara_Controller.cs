using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //���݂̎���(�ŏ���1)
    public float Real_Time = 1f;

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

    //�ʏ�X�s�[�h
    float normal_speed = 50;
    //�_�b�V���X�s�[�h
    float dash_speed;
    //���݂̃X�s�[�h���[�h
    float now_speed;

    //�ړ��̕ϐ�
    public float sayuu;
    public float jouge;
    //���������p�ϐ�
    public float gravity;

    //�ŏ��̃W�����v�p�ϐ�
    public float first_jump;
    //�W�����v�̃N�[���^�C��
    public int JumpCoolTime = 1;
    //�W�����v�̑��x��ݒ�
    float Jump_velocity = 5.0f;
    //�W�����v�̎��Ԃ𔻒�
    public float jumpTime;
    //�W�����v�p���[�i����\��j
    float jump_power = 5f;
    //2�i�W�����v�֎~�p
    public bool jump_stop;         //false = �֎~
                                   //true  = ����

    //�ړ��i�����j�X�s�[�h
    Vector3 speed_origin;

    //CharacterController��錾
    public CharacterController characterController;

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

        //�������x��������
        gravity = -0.2f;

        //�ŏ��̃W�����v��������
        first_jump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�ŏ��̃W�����v
        //if (Input.GetButtonDown("Vertical"))
        //{
        //    Debug.Log("first");
        //    first_jump += 1;
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
            Invoke(nameof(Animation_stop), 5f);
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

        //�����ύX�p
        if (sayuu > 0)
        {
            muki = false;
        }
        else if (sayuu < 0)
        {
            muki = true;
        }

        //��ɏd�͂�������
        characterController.Move(new Vector3(0, gravity, 0));

        //�o�ߎ��Ԃ�Real_Time�ɓ����
        Real_Time += Time.deltaTime;

        //�ϐ���Horizontal�EVertical���� ���P Vertical���ړ�
        sayuu = Input.GetAxisRaw("Horizontal");

        //���ړ�(�X�e�B�b�N or ���E���L�[)&�W�����v(�X�e�B�b�N or ����L�[(W�L�[))    
        characterController.Move(new Vector3(sayuu * 0.05f * chara_muki, jouge, 0));

        if (Real_Time >= JumpCoolTime)
        {
            Debug.Log("OK");
        }
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
            Invoke(nameof(Animation_stop), 1f);
        }
        mytransform.eulerAngles = World_angle;
    }
    //��~��Ԃ̃A�j���[�V����
    void Animation_stop()
    {
        animator.SetInteger("stop", 0);
        kougeki_attack = 0;
    }
    //characterController�𗘗p���������蔻��
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //�n�ʂɂ��Ă���
        if (hit.gameObject.CompareTag("jimen"))
        {
            if (Real_Time >= JumpCoolTime)
            {
                Debug.Log("�W�����v");
                Real_Time = 0;
                //�ړ����P
                jouge = Input.GetAxisRaw("Vertical");
            }
            else
            {
                Debug.Log("Non");
                Invoke(nameof(Chien), 0.05f);
            }
        }
        //2��ڈȍ~�̃W�����v��������
        //    if (first_jump > 1f)
        //    {
        //        Debug.Log("����");
        //        //0.05�b��ɌĂяo���i�d���j
        //        Invoke(nameof(Jumping), 0.00225f);
        //    }

        //    //�ŏ��̃W�����v��������
        //    else if (first_jump <= 1)
        //    {
        //        Debug.Log("����1");
        //        Invoke(nameof(First_Jumping), 0.0001f);           
        //    }
        //    jump_stop = true;
        //    Debug.Log("jimen");
        //}
        //else
        //{
        //    jump_stop = false;
        //    Debug.Log("��");
        //    jouge = gravity;
    //}
        //�ŏ��̃W�����v
        //void First_Jumping()
        //{
        //    Debug.Log("first1");
        //    jouge = Input.GetAxisRaw("Vertical");
        //}

        ////2��ڈȍ~�̃W�����v
        //void Jumping()
        //{
        //    if (Real_Time >= JumpCoolTime)
        //    {
        //        Debug.Log("�W�����v");
        //        Real_Time = 0;
        //        //�ړ����P
        //        jouge = Input.GetAxisRaw("Vertical");
        //    }
        //    //else
        //    //{
        //    //    Debug.Log("NOTjannpu");
        //    //    //�ړ����P
        //    //    jouge = 0;
        //    //}
        //}

        void Chien()
        {
            jouge = gravity;
        }
    }
}
