using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Otoko_chara_Controller : MonoBehaviour
{


    public GauMan GauMan;
    //�q�I�u�W�F�N�g�p
    public Transform otoko1_obj_Child;

    //�j1�̃��C���[�p�ϐ�
    public int otoko_layer;
    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;
    //Rigidbody���擾
    public new Rigidbody rigidbody;

    //�Q�[���f�B���N�^�[���擾
    public gamedirector gamedirector;
    //�e�X�g�p�̃f�R�C�i�Q�[���I�u�W�F�N�g�j���擾
    public dekoi dekoi;

    //���݂̎���
    public float Real_Time;

    //�U�����󂯂��E�^������Ԃ��Ǘ�����p�̕ϐ�
    public int otoko1_kougeki_hidan;   //�U�����󂯂��p(�Q�[���f�B���N�^�[����󂯎��)
    public int otoko1_kougeki_attack;  //�U���m�F�p
    public int otoko1_kougeki_hit;     //�U���q�b�g�p
    //�U���N�[���^�C��
    public bool jaku_stop;
    public bool kyou_stop;
    //�U���N�[���^�C���p�ϐ�
    public float attack_cooltime_jaku;
    public float attack_cooltime_kyou;
    //Transform�R���|�[�l���g���擾
    Transform mytransform;
    //�U�����pbool
    public bool attack_permission;
    //true = ����
    //false= �s����
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

    //�e�U���p�A�j���[�V�����ϐ�
    public int jab_int;
    public int jab_max;
    public int hook_max;
    public int hook_int;

    //�ړ��̕ϐ�
    public float sayuu;
    public float jouge;
    //jouge�̎󂯓n����
    public float jump;

    //�W�����v�̃N�[���^�C��
    public float JumpCoolTime = 1.5f;
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

    ////HP
    //int hp = 10;
    ////�U����
    //int attack = 10;
    ////�f����(�r�q)
    //int speed = 10;
    ////�X�^�~�i(�ϋv)
    //int stamina = 10;
    ////����(�n�m)
    //int cleverness = 10;

    // Start is called before the first frame update
    void Start()
    {
        //�S�Ă̎q�I�u�W�F�N�g�̎擾
        otoko1_obj_Child = this.gameObject.GetComponentInChildren<Transform>();

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
        otoko1_obj_Child.GetComponentInChildren<Transform>();
        otoko1_kougeki_hidan = gamedirector.hidan_otoko1;
        Debug.Log(otoko1_kougeki_hidan+"f");
        //�N�[���^�C���Ɏ��Ԃ�����
        if (Input.GetButtonDown("X or J") && attack_cooltime_jaku < 0.5f)  
        {
            attack_cooltime_jaku += Time.deltaTime;
        }
        if (Input.GetButtonDown("A or K") && attack_cooltime_kyou < 1)
        {
            attack_cooltime_kyou += Time.deltaTime;
        }
        //�U������
        if (attack_cooltime_jaku >= 0.5f || attack_cooltime_kyou > 1) 
        {
            attack_permission = true;
        }

        //�ړ�����
        Vector3 Pos = transform.position;
        //X���W
        Pos.x = Mathf.Clamp(Pos.x, -4, 4);
        //Y���W
        Pos.y = Mathf.Clamp(Pos.y, 4.8f, 6.62f);
        //�͈͂��z������e���|�[�g
        transform.position = Pos;
        //�V��ɂԂ������痎��
        if (transform.position.y >= 6.62f)
        {
            jouge = -1f;
        }
        //���̓}�l�[�W���[���g�p�����ړ����@ ��Vertical�͈ړ�
        sayuu = Input.GetAxisRaw("Horizontal");
        //Vector3��Horizontal�EVertical����
        Vector3 idouVec = new Vector3(0, jouge, sayuu * chara_muki);

        //�W�����v���Ԃ̌v�Z
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }

        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetButtonDown("X or J") && jump_stop == true) 
        {
            Debug.Log("��U��");
            otoko1_kougeki_attack = 1;
            gameObject.layer = LayerMask.NameToLayer("Attack");
        }
        //���U���iA or K�j
        if (Input.GetButtonDown("A or K") && jump_stop == true) 
        {
            animator.SetTrigger("return_hook");
            Debug.Log("���U��");
            otoko1_kougeki_attack = 2;
            gameObject.layer = LayerMask.NameToLayer("Attack");
        }
        //�����U���iB or L�j
        if (Input.GetAxisRaw("B or L") != 0 && jump_stop == true)
        {
            Debug.Log("�����U��");
        }
        //�K�E�Z�iY or I�j
        if (Input.GetAxisRaw("Y or I") != 0 && jump_stop == true)
        {
            Debug.Log("�K�E�Z");
        }
        //�K�[�h(Right(left) Bumper or sperce)   ���W���X�g�K�[�h������
        if (Input.GetButtonDown("Right(left) Bumper or sperce") && jump_stop == true)
        {
            Debug.Log("�K�[�h");
        }
        //�ړ��ȊO�̓��͂��������Ƃ��� ���蔲���Ȃ��悤�ɂ��� or �ړ��ł��Ȃ��悤�ɂ���
        if (Input.GetButtonDown("Right(left) Bumper or sperce") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetButtonDown("A or K") || Input.GetButtonDown("X or J")) 
        {
            gameObject.SetChildLayer(7);
            gameObject.layer = LayerMask.NameToLayer("Attack");
            idouVec = Vector3.zero;
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
            animator.SetTrigger("Trigger_Move");
            jump_stop = false;
            Real_Time = 0;
            Invoke(nameof(Chien), 0.001f);
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
        transform.Translate(speed_origin * Time.deltaTime * idouVec);

        //�ȉ��A�j���[�V����

        //�A�j���[�V��������p����
        //��U��
        if (Input.GetAxisRaw("X or J") != 0 && jump_stop == true)
        {
            ++jab_int;
        }
        //���U��
        if (Input.GetAxisRaw("A or K") != 0 && jump_stop == true)
        {
            ++hook_int;
        }
        //�U���A�j���[�V����
        if (Input.GetAxisRaw("X or J") != 0 && jump_stop == true || Input.GetAxisRaw("A or K") != 0 && jump_stop == true)
        {
            animator.SetTrigger("Trigger_attack");
            //��U��
            //�P���U��
            if (jab_int == 1)
            {
                Jab_1();
            }

            //���U��
            //�P���U��
            if (hook_int == 1)
            {
                Hook_1();
            }
        }

        //���[���h���W����ɉ�]���擾
        Vector3 World_angle = mytransform.eulerAngles;
        //���E�ǂ��炩�Ɉړ���
        if (Input.GetButton("Horizontal"))
        {
            animator.SetTrigger("Trigger_Move");
            //�E�ړ�
            if (sayuu > 0)
            {
                //�A�j���[�V��������
                animator.SetTrigger("Trigger_walk");
                //���]����
                chara_muki = 1;
                World_angle.y = -90;
                //�A�j���[�V�����ύX
                animator.SetInteger("int_walk", 1);
            }
            //���ړ�
            else if (sayuu < 0)
            {
                //�A�j���[�V��������
                animator.SetTrigger("Trigger_walk");
                //���]����
                chara_muki = -1;
                World_angle.y = 90;
                //�A�j���[�V�����ύX
                animator.SetInteger("int_walk", 1);
            }
        }
        //��~���
        if (!Input.anyKey)
        {
            //�ϐ�������
            Invoke(nameof(Hensuu_shoki), 0.1f);
            //���C���[������
            Invoke(nameof(Layer_shoki), 0.5f);
        }
        mytransform.eulerAngles = World_angle;
    }
    //��~��Ԃ̕ϐ�������
    void Hensuu_shoki()
    {
        animator.SetInteger("int_walk", 0);
        animator.SetInteger("int_jab", 0);
        animator.SetInteger("int_hook", 0);
        otoko1_kougeki_attack = 0;
        otoko1_kougeki_hidan = 0;
    }
    void Layer_shoki()
    {
        gameObject.SetChildLayer(3);
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    void CoolTime_Shoki()
    {
        attack_cooltime_jaku = 0;
        attack_cooltime_kyou = 0;
    }
    //�����蔻��܂Ƃ�
    
    //�G�ꑱ���Ă�Ԕ���
    public void OnTriggerStay(Collider stay_other)
    {
        //�n�ʂɂ��Ă���
        if (stay_other.CompareTag("jimen"))
        {
            //�ϐ���Horizontal�EVertical���� ��jouge�̂ݐ���
            jump = Input.GetAxisRaw("Vertical");
            if (jump >= 0)
            {
                jouge = jump;
            }
            jump_stop = true;
        }
        if (stay_other.CompareTag("Player"))
        {
            Debug.Log("dekoi���m");
            if (otoko1_kougeki_attack != 0)
            {
                Debug.Log("Attack");
                //���C���[�ύX
                gameObject.SetChildLayer(7);
                gameObject.layer = LayerMask.NameToLayer("Attack");
                Attack();
            }
            else if (otoko1_kougeki_hidan != 0)
            {
                Debug.Log("Hiddan");
                animator.SetTrigger("Trigger_Move");
                Debug.Log("��e");
               // GauMan.DecreaseEnemyHPGauge(1);

                

                //���C���[�ύX
                gameObject.SetChildLayer(6);
                gameObject.layer = LayerMask.NameToLayer("Hantei");
                Hidan();
            }
        }
        Invoke(nameof(CoolTime_Shoki), 0.1f);
    }
    void Chien()
    {
        jump_stop = false;
        Debug.Log("�x��");
        jouge = -1f;
    }

    //�U���E��e�܂Ƃ�

    //�^�_���[�W��
    public void Attack()
    {
        //�n��U��
        if (jump_stop == true)
        {
            //��U��
            if (otoko1_kougeki_attack == 1 && attack_permission == true)
            {
                otoko1_kougeki_hit = 1;
                Debug.Log("player_kougeki_attack1");
            }
            //���U��
            if (otoko1_kougeki_attack == 2 && attack_permission == true)
            {
                otoko1_kougeki_hit = 2;
                Debug.Log("player_kougeki_attack2");
            }
            attack_permission = false;
        }

    }
    //��_���[�W��
    public void Hidan()
    {
        //�n��Ŕ�e
        if(jump_stop == true)
        {
            animator.SetTrigger("Trigger_hirumi");
            //��Ђ��(��U��)
            if (otoko1_kougeki_hidan == 1)
            {
                animator.SetInteger("int_hirumi", 1);
                Debug.Log("player_��Ђ��");
            }
            //�_�E���i���U�� or �K�E�Z or �����j
            if (otoko1_kougeki_hidan == 2) 
            {
                animator.SetInteger("int_hirumi", 2);
                animator.SetTrigger("return_down");
                Debug.Log("Player_�_�E��");
            }
        }
    }
    public void Jab_1()
    {
        animator.SetInteger("int_jab", 1);
    }
    public void Hook_1()
    {
        animator.SetInteger("int_hook", 1);
    }
}
