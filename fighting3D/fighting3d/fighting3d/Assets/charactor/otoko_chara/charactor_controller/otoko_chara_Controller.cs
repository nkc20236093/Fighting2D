using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //����������Rigidbody
    public Rigidbody m_rigid_body = null;

    //���݂̎���(�ŏ���1)
    public float Real_Time;

    //�U�����󂯂��E�^������Ԃ��Ǘ�����p�̕ϐ�
    public float kougeki_attack;

    //Transform�R���|�[�l���g���擾
    Transform mytransform;

    //�v���C���[�̈ړ������E���x�̕ϐ�
    Vector3 PlayerVector;

    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;

    //�ʏ�X�s�[�h
    float normal_speed = 200f;
    //�_�b�V���X�s�[�h
    float dash_speed = 10f;
    //���݂̃X�s�[�h���[�h
    float now_speed;
    //�ړ����x��Vector3
    Vector3 sokudo;
    //�X�s�[�h�ݒ�
    float speed_origin;

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
        //�ŏ��Ɍ��݂̃W�����v�͂ɒʏ�X�s�[�h����
        now_jumppower = jump_power;

        //�����̉�]�x���擾
        mytransform = this.transform;
        animator = GetComponent<Animator>();

        //rigid�ɃR���|�[�l���g����
        m_rigid_body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ϐ�����
        jouge = Input.GetAxisRaw("Vertical");
        sayuu = Input.GetAxisRaw("Horizontal");

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

        //�ϐ���Horizontal�EVertical����
        Vector3 idou = new Vector3(PlayerVector.x * -1, PlayerVector.y, 0);
        //���\�b�h���Ăяo��
        MyAddForce(idou);
        //�ړ����x��Vector3(��)
        Vector3 sokudo = new Vector3(now_speed, now_jumppower, 0);

        if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = normal_speed;
        }
        if (Input.GetButtonDown("Vertical") && jump_stop == true)
        {
            speed_origin = now_jumppower;
            Invoke(nameof(ChienGravity), 0.25f);
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
                Debug.Log("true");
                PlayerVector.y = jouge * jump_power;
                sokudo.y = now_jumppower;
            }
        }
        else
        {
            PlayerVector.y = 0;
        }
        //���ړ��̏���
        if (sayuu != 0)
        {
            Debug.Log("false");
            PlayerVector.x = sayuu * now_speed;
            sokudo.x = now_speed;
        }
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
        //�ϐ���Horizontal�EVertical����
        //Vector3 idou = new Vector3(PlayerVector.x * -1, PlayerVector.y, 0);

        //�ړ�����
        //m_rigid_body.AddForce(idou * speed_origin * Time.deltaTime);
    }
    //�ړ����\�b�h
    void MyAddForce(Vector3 idou)
    {
        m_rigid_body.AddForce(idou);
        m_rigid_body.velocity = idou * Time.deltaTime * 2f;
    }
    //
    void ChienGravity()
    {
        m_rigid_body.AddForce(new Vector3(0, -0.2f, 0));
    }
}
