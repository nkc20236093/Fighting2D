using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dekoi : MonoBehaviour
{
    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;
    //Rigidbody���擾
    public new Rigidbody rigidbody;

    //�v���C���[���擾
    Otoko_chara_Controller otoko;
    public int dekoi_hensuu;
    //���݂̎���
    public float Real_Time;

    //�U����^������Ԃ��Ǘ�����p�̕ϐ�
    public int dekoi_kougeki_attack;

    //Transform�R���|�[�l���g���擾
    Transform mytransform;

    //�L���������ύX�p�ϐ�
    float chara_muki;

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
    //jouge�̎󂯓n����
    public float jump;

    //�W�����v�̃N�[���^�C��
    public float JumpCoolTime = 1f;
    //�W�����v�̎��Ԃ𔻒�
    public float jumpTime;
    //�ʏ�W�����v�p���[�i����\��j
    float jump_power = 3f;
    //�n�C�W�����v�p���[�i����\��j
    float high_jump = 5f;
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
    //�f����(�r�q)
    int speed = 10;
    //�X�^�~�i(�ϋv)
    int stamina = 10;
    //����(�n�m)
    int cleverness = 10;

    // Start is called before the first frame update
    void Start()
    {
        otoko = GameObject.Find("���_�j�L�����P").GetComponent<Otoko_chara_Controller>();
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
        dekoi_hensuu = otoko.otoko1_kougeki_attack;

        //�ړ�����
        Vector3 Pos = transform.position;
        //X���W
        Pos.x = Mathf.Clamp(Pos.x, -4, 4);
        //Y���W
        Pos.y = Mathf.Clamp(Pos.y, 4.8f, 6.62f);
        //�͈͂��z������e���|�[�g
        transform.position = Pos;

        //���̓}�l�[�W���[���g�p�����ړ����@ ��Vertical�͈ړ�
        sayuu = Input.GetAxisRaw("Horizontal");
        //Vector3��Horizontal�EVertical����
        Vector3 idouVec = new Vector3(0, jouge * 1.5f, sayuu * chara_muki);

        //�W�����v���Ԃ̌v�Z
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }

        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetInteger("stop_dekoi", 2);
            Debug.Log("��U��");
            dekoi_kougeki_attack = 1;
        }
        //���U���iA or K�j
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetInteger("stop_dekoi", 3);
            Debug.Log("���U��");
            dekoi_kougeki_attack = 2;
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
        
        //�ړ��ȊO�̓��͂��������Ƃ��� ���蔲���Ȃ��悤�ɂ��� or �ړ��ł��Ȃ��悤�ɂ���
        if (Input.GetButtonDown("Right(left) Bumper or sperce") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetButtonDown("A or K") || Input.GetButtonDown("X or J") || Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.layer = LayerMask.NameToLayer("Hantei");
            idouVec = Vector3.zero;
        }
        if (!Input.anyKey)
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
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
            speed_origin = now_speed;
        }
        //speed_origin�ɑ��
        if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = now_speed;
        }
        if (Input.GetButtonDown("Vertical"))
        {
            speed_origin = now_jumppower;
        }
        //�W�����v�̏���
        //�n�ʂɂ��Ă���&�W�����v���͂�����Ă���
        if (jump_stop == true && jouge != 0 && Real_Time > JumpCoolTime)
        {
            Real_Time = 0;
            Invoke(nameof(Chien), 0.43f);
            if (jump_mode == true)
            {
                now_jumppower = jump_power;
            }
            else
            {
                now_jumppower = high_jump;
            }
            speed_origin = now_jumppower;
        }
        //�ړ�����
        //transform.Translate(speed_origin * Time.deltaTime * idouVec);

        //�ȉ��A�j���[�V����

        //���[���h���W����ɉ�]���擾
        Vector3 World_angle = mytransform.eulerAngles;
        //���E�ǂ��炩�Ɉړ���
        if (sayuu != 0)
        {
            //�E�ړ�
            if (sayuu > 0)
            {
                //���]����
                chara_muki = 1;
                World_angle.y = -90;
                //�A�j���[�V�����ύX
                animator.SetInteger("stop_dekoi", 1);
            }
            //���ړ�
            else if (sayuu < 0)
            {
                //���]����
                chara_muki = -1;
                World_angle.y = 90;
                //�A�j���[�V�����ύX
                animator.SetInteger("stop_dekoi", 1);
            }
        }
        //��~���
        if (!Input.anyKeyDown)
        {
            //�A�j���[�V�����ύX
            Invoke(nameof(Animation_stop), 1.5f);
        }
        //mytransform.eulerAngles = World_angle;
    }
    //��~��Ԃ̃A�j���[�V����
    void Animation_stop()
    {
        animator.SetInteger("stop_dekoi", 0);
        dekoi_kougeki_attack = 0;
    }
    //�����蔻��܂Ƃ�
    private void OnTriggerStay(Collider other)
    {
        //�n�ʂɂ��Ă���
        if (other.CompareTag("jimen"))
        {
            //�ϐ���Horizontal�EVertical���� ��jouge�̂ݐ���
            jump = Input.GetAxisRaw("Vertical");
            if (jump >= 0)
            {
                jouge = jump;
            }
            //Debug.Log("jimen");
            jump_stop = true;
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player���m");
            Attack();
        }
    }
    void Chien()
    {
        jump_stop = false;
        Debug.Log("�x��");
        jouge = -1f;
    }
    //�U���t�^�E��e�܂Ƃ�
    public void Attack()
    {
        //��_���[�W��

        if (dekoi_hensuu < 0)
        {
            //��Ђ��(��U��)
            if (dekoi_hensuu == 1)
            {
                Debug.Log("dekoi_��Ђ��");
                animator.SetInteger("stop_dekoi", 4);
            }
        }

        //�^�_���[�W��

        //��U��
        if (dekoi_kougeki_attack == 1)
        {
            //���C���[�ύX
            gameObject.layer = LayerMask.NameToLayer("Attack");
            Debug.Log("dekoi_kougeki_attack1");
        }
        //���U��
        if (dekoi_kougeki_attack == 2)
        {
            //���C���[�ύX
            gameObject.layer = LayerMask.NameToLayer("Attack");
            Debug.Log("dekoi_kougeki_attack2");
        }
    }
}