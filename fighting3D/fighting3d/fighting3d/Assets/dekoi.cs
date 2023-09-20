using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dekoi : MonoBehaviour
{
    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;
    //Rigidbody���擾
    public new Rigidbody rigidbody;

    //�Q�[���f�B���N�^�[���擾
    gamedirector gamedirector;
    //�v���C���[���擾
    Otoko_chara_Controller otoko;
    //���݂̎���
    public float Real_Time;

    //�U����^�����E���������Ԃ��Ǘ�����p�̕ϐ�
    public int dekoi_kougeki_attack;
    public int dekoi_kougeki_hidan;
    public int dekoi_kougeki_hit;
    //�U����������pbool
    public bool jab__distance;
    public bool kick__distance;
    //�U����������p(�Q�[���f�B���N�^�[)
    public bool jab_dekoi_distance;
    public bool kick_dekoi_distance;
    //�U���N�[���^�C���p�ϐ�
    public float dekoi_kougeki_cooltime_jaku;
    public float dekoi_kougeki_cooltime_kyou;
    //�U���N�[���^�C���pbool
    public bool jab_dekoi_cooltime;
    public bool kick_dekoi_cooltime;

    //�Q�[���f�B���N�^�[�p�U����bool
    public bool dekoi_cooltime_permisson;
    public bool dekoi_attack_permission;
    //trur = ����
    //false= �s����

    //Transform�R���|�[�l���g���擾
    Transform mytransform;

    //�L���������ύX�p�ϐ�
    public float chara_muki_dekoi;

    //�ʏ�X�s�[�h
    static float normal_speed = 5f;
    //�_�b�V���X�s�[�h
    static float dash_speed = 7.5f;
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
        otoko = GameObject.Find("���_�j�L�����P").GetComponent<Otoko_chara_Controller>();
        gamedirector = GameObject.Find("GameDirector").GetComponent<gamedirector>();

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
        dekoi_kougeki_hidan = gamedirector.hidan;
        //�U���͈́i�����j
        //�E����
        if (chara_muki_dekoi == 1f)
        {
            gamedirector.Distance_gamedirector = 1 * gamedirector.Distance_gamedirector;
        }
        //������
        else if (chara_muki_dekoi == -1f)
        {
            gamedirector.Distance_gamedirector = -1 * gamedirector.Distance_gamedirector;
        }
        //��U���p����
        if (gamedirector.Distance_gamedirector <= 0.6525345f || gamedirector.Distance_gamedirector <= -0.6525345f && Input.GetButtonDown("X or J"))
        {
            jab__distance = true;
        }
        else if (gamedirector.Distance_gamedirector <= 0.6525345f || gamedirector.Distance_gamedirector <= -0.6525345f)
        {
            jab__distance = false;
        }
        //���U���p����
        if (gamedirector.Distance_gamedirector <= 1.717879f || gamedirector.Distance_gamedirector <= -1.717879f && Input.GetButtonDown("A or K"))
        {
            kick__distance = true;
        }
        else if (gamedirector.Distance_gamedirector <= 1.717879f || gamedirector.Distance_gamedirector <= -1.717879f)
        {
            kick__distance = false;
        }

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
        Vector3 idouVec = new Vector3(0, jouge * 1.5f, sayuu * chara_muki_dekoi);

        //�W�����v���Ԃ̌v�Z
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }
        //��U���N�[���^�C���v�Z
        if (Input.GetKeyDown(KeyCode.Return) && dekoi_kougeki_cooltime_jaku < 0.5f)
        {
            dekoi_kougeki_cooltime_jaku += Time.deltaTime;
        }
        //���U���N�[���^�C���v�Z
        if (Input.GetKeyDown(KeyCode.Z) && dekoi_kougeki_cooltime_kyou < 1f)
        {
            dekoi_kougeki_cooltime_kyou += Time.deltaTime;
        }
        //�U���N�[���^�C��
        //��U��
        if (dekoi_kougeki_cooltime_jaku >= 0.5f)
        {
            jab_dekoi_cooltime = true;
        }
        //���U��
        if (dekoi_kougeki_cooltime_kyou >= 1)
        {
            kick_dekoi_cooltime = true;
        }
        if (dekoi_kougeki_cooltime_jaku >= 0.5f || dekoi_kougeki_cooltime_kyou >= 1)
        {
            dekoi_cooltime_permisson = true;
        }
        //��������(�Q�[���f�B���N�^�[�p)
        if (jab_dekoi_distance == true || kick_dekoi_distance == true)
        {
            dekoi_attack_permission = true;
        }

        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("��U��");
            dekoi_kougeki_attack = 1;
        }
        //���U���iA or K�j
        if (Input.GetKeyDown(KeyCode.Z))
        {
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
        if (Input.GetButtonDown("Right(left) Bumper or space"))
        {
            Debug.Log("�K�[�h");
        }

        //�ړ��ȊO�̓��͂��������Ƃ��� ���蔲���Ȃ��悤�ɂ��� or �ړ��ł��Ȃ��悤�ɂ���
        if (Input.GetButtonDown("Right(left) Bumper or space") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("X or J") || Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetDekoiChild(6);
            gameObject.layer = LayerMask.NameToLayer("Attack");
            idouVec = Vector3.zero;
        }
        if (!Input.anyKey)
        {
            Layer_Shoki();
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
        if (Input.GetButtonDown("Horizontal"))
        {
            //�E�ړ�
            if (sayuu > 0)
            {
                //���]����
                chara_muki_dekoi = 1;
                World_angle.y = -90;
                //�A�j���[�V�����ύX
                animator.SetTrigger("dekoi_zensin");
            }
            //���ړ�
            else if (sayuu < 0)
            {
                //���]����
                chara_muki_dekoi = -1;
                World_angle.y = 90;
                //�A�j���[�V�����ύX
                animator.SetTrigger("dekoi_zensin");
            }
        }
        //�e�U���p�A�j���[�V����
        //��U��
        if (jump_stop == true && dekoi_kougeki_attack == 1 && dekoi_attack_permission == true && jab_dekoi_cooltime == true)
        {
            dekoi_kougeki_hit = 1;
            animator.SetTrigger("Trigger_dekoi_attack");
            Dekoi_jab();
        }
        else if (dekoi_kougeki_attack == 1)
        {
            animator.SetTrigger("Trigger_dekoi_attack");
            Dekoi_jab();
        }
        //���U��
        if (jump_stop == true && dekoi_kougeki_attack == 2 && dekoi_attack_permission == true && kick_dekoi_cooltime == true)
        {
            dekoi_kougeki_hit = 2;
            animator.SetTrigger("Trigger_dekoi_attack");
            Dekoi_hook();
        }
        else if (dekoi_kougeki_attack == 2)
        {
            animator.SetTrigger("Trigger_dekoi_attack");
            Dekoi_hook();
        }

        //��~���
        if (!Input.anyKeyDown)
        {
            //�A�j���[�V�����ύX
            Invoke(nameof(Attack_or_HIdan_Shoki), 1f);
        }
        //mytransform.eulerAngles = World_angle;
    }
    //��~��Ԃ̕ϐ�������
    void Attack_or_HIdan_Shoki()
    {
        dekoi_kougeki_attack = 0;
        dekoi_kougeki_hidan = 0;
    }
    void Cooltime_Shoki()
    {
        dekoi_kougeki_cooltime_jaku = 0;
        dekoi_kougeki_cooltime_kyou = 0;
    }
    public void Layer_Shoki()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
        gameObject.SetDekoiChild(3);
    }
    //�����蔻��܂Ƃ�

    //�G�ꑱ���Ă�Ԕ���
    //public void OnTriggerStay(Collider stay_other)
    //{
    //    //�n�ʂɂ��Ă���
    //    if (stay_other.CompareTag("jimen"))
    //    {
    //        //�ϐ���Horizontal�EVertical���� ��jouge�̂ݐ���
    //        jump = Input.GetAxisRaw("Vertical");
    //        if (jump >= 0)
    //        {
    //            jouge = jump;
    //        }
    //        jump_stop = true;
    //    }
    //    if (stay_other.CompareTag("Player")) 
    //    {
    //        Debug.Log("Player���m");
    //        if (dekoi_kougeki_attack != 0) 
    //        {
    //            //���C���[�ύX
    //            gameObject.SetDekoiChild(7);
    //            gameObject.layer = LayerMask.NameToLayer("Attack");
    //            Attack();
    //        }
    //        else if (dekoi_kougeki_hidan != 0)
    //        {
    //            //���C���[�ύX
    //            gameObject.SetDekoiChild(6);
    //            gameObject.layer = LayerMask.NameToLayer("Hantei");
    //            Hidan();
    //        }
    //    }
    //}
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
            if (dekoi_kougeki_attack == 1 && dekoi_attack_permission == true)
            {
                dekoi_kougeki_hit = 1;
                Debug.Log("player_kougeki_attack1");
            }
            //���U��
            if (dekoi_kougeki_attack == 2 && dekoi_attack_permission == true)
            {
                dekoi_kougeki_hit = 2;
                Debug.Log("player_kougeki_attack2");
            }
            Invoke(nameof(Cooltime_Shoki), 0.1f);
        }
    }
    //��_���[�W��
    public void Hidan()
    {
        //�n��Ŕ�e
        if (jump_stop == true)
        {
            //��Ђ��(��U��)
            if (dekoi_kougeki_hidan == 1)
            {
                animator.SetTrigger("dekoi_jaku_hirumi");
                animator.SetInteger("dekoi_hirumi_int", 1);
                Debug.Log("dekoi_��Ђ��");
            }
            //�_�E���i���U�� or �K�E�Z or �����j
            if (dekoi_kougeki_hidan == 2)
            {
                animator.SetTrigger("dekoi_down");
                Debug.Log("dekoi_�_�E��");
            }
            Attack_or_HIdan_Shoki();
        }
    }
    public void Dekoi_jab()
    {
        animator.SetTrigger("dekoi_jab");
        jab_dekoi_distance = false;
    }
    public void Dekoi_hook()
    {
        animator.SetTrigger("dekoi_kick");
        kick_dekoi_distance = false;
    }
}