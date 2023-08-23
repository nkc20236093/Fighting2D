using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //����������Rigidbody
    public Rigidbody rigidbody = null;

    //���݂̎���(�ŏ���1)
    public float Real_Time;

    //�U�����󂯂��E�^������Ԃ��Ǘ�����p�̕ϐ�
    public float kougeki_attack;

    //Transform�R���|�[�l���g���擾
    Transform mytransform;

    //�v���C���[�̈ړ������E���x�̕ϐ�
    Vector3 PlayerVector;
    //�ړ��pVector3
    public Vector3 idou_houkou;

    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;

    //�ʏ�X�s�[�h
    float normal_speed = 5f;
    //�_�b�V���X�s�[�h
    float dash_speed = 7.5f;
    //���݂̃X�s�[�h���[�h
    float now_speed;
    //�X�s�[�h�ݒ�
    float speed_origin;
    //�_�b�V�����[�h�ؑ�
    public bool speed_mode;
    //false = �ʏ�
    //true  = �_�b�V��

    //�ړ��̕ϐ�
    public float sayuu;
    public float jouge;

    //�W�����v�̃N�[���^�C��
    public float JumpCoolTime = 0.5f;
    //�W�����v�̎��Ԃ𔻒�
    public float jumpTime;
    //�ʏ�W�����v�p���[�i����\��j
    float jump_power = 5f;
    //�n�C�W�����v�p���[�i����\��j
    float high_jump = 10f;
    //���݂̃W�����v��
    float now_jumppower;
    //2�i�W�����v�֎~�p
    public bool jump_stop;
    //false = �֎~
    //true  = ����

    //�W�����v��Ԑ؂�ւ�
    public bool jump_mode;
    //false = �ʏ���
    //true  = �n�C�W�����v���

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
        //�ŏ��ɃX�s�[�h���[�h�ɒʏ탂�[�h����
        speed_mode = false;
        //�ŏ��Ɍ��݂̃W�����v���[�h�ɒʏ탂�[�h����
        jump_mode = false;

        //�����̉�]�x���擾
        mytransform = this.transform;
        animator = GetComponent<Animator>();

        //rigid�ɃR���|�[�l���g����
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�����
        Vector3 MyVector3 = transform.position;
        //X���W
        Mathf.Clamp(MyVector3.x, 4, -4);
        //Y���W
        Mathf.Clamp(MyVector3.y, 4.8f, 9.5f);
        //�͈͂��z������e���|�[�g
        transform.position = MyVector3;

        //�ϐ�����
        jouge = Input.GetAxisRaw("Vertical");
        sayuu = Input.GetAxisRaw("Horizontal");

        //�ړ����x��Vector3(��)
        Vector3 sokudo = new Vector3(now_speed, now_jumppower, 0);

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

        if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = now_speed;
        }
        if (Input.GetButtonDown("Vertical")) 
        {
            speed_origin = now_jumppower;
        }
        //�o�ߎ��Ԃ�Real_Time�ɓ����
        Real_Time += Time.deltaTime;

        //���݂̎��Ԃ���
        if (Real_Time >= JumpCoolTime)
        {
            Debug.Log("OK");
        }
        //�W�����v���Ԃ̌v�Z
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }
        //�W�����v�̏���
        //�n�ʂɂ��Ă���
        if (jump_stop == true)
        {
            //�W�����v���͂�����Ă���
            if (jouge > 0)
            {
                if (jump_mode == true)
                {
                    now_jumppower = jump_power;
                }
                else
                {
                    now_jumppower = high_jump;
                }
                Debug.Log("true");
                speed_origin = now_jumppower;
                PlayerVector.y = jouge;
            }
        }
        else
        {
            now_jumppower = 0;
        }

        //���ړ��̏���
        if (sayuu != 0)
        {
            if (speed_mode == true)
            {
                now_speed = dash_speed;
            }
            else
            {
                now_speed = normal_speed;
            }
            Debug.Log("false");
            speed_origin = now_speed;
            PlayerVector.x = sayuu;
        }

        //�ϐ���Horizontal�EVertical����
        Vector3 idou_houkou = new Vector3(0, PlayerVector.y, PlayerVector.x);
        //�ړ�����
        transform.Translate(speed_origin * Time.deltaTime * idou_houkou);

        //�ȉ��A�j���[�V����

        //���[���h���W����ɉ�]���擾
        Vector3 World_angle = mytransform.eulerAngles;
        //���E�ǂ��炩�Ɉړ���
        if (sayuu != 0)
        {
            //�E�ړ�
            if (sayuu > 0)
            {
                Debug.Log("�E");
                //���]����
                World_angle.y = -90;
                //�A�j���[�V�����ύX
                animator.SetInteger("stop", 1);
            }
            //���ړ�
            else if (sayuu < 0)
            {
                Debug.Log("��");
                //���]����
                World_angle.y = 90;
                //�A�j���[�V�����ύX
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
    //�����蔻��܂Ƃ�
    private void OnTriggerStay(Collider other)
    {
        //�n�ʂɂ��Ă���
        if (other.CompareTag("jimen"))
        {
            Debug.Log("jimen");
            jump_stop = true;
        }
        else
        {
            jump_stop = false;
        }
    }
}
