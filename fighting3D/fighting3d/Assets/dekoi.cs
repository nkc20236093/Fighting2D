using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dekoi : MonoBehaviour
{
    //Ray���I�u�W�F�N�g�ɓ��������ꍇ�̋���(�ϓ��^)
    float Ray_length_dekoi;
    //���C���擾
    Ray otoko1_ray_dekoi;
    //���C�̌��_
    Vector3 otoko1_ray_Origin_dekoi;
    //���C�̕���
    Vector3 otoko1_ray_Vector3_dekoi;
    //���C�L���X�g�q�b�g���擾
    RaycastHit hit_dekoi;
    //���C���v���C���[�ɓ����������ǂ���
    public bool Ray_player_hit_dekoi;
    //���C���g���K�[�t���R���C�_�[�ɔ�����o����
    QueryTriggerInteraction queryTrigger_dekoi;
    //Ray�p���C���[�ϐ�
    public int dekoi_ray_layer;

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
    static float normal_speed = 1f;
    //�_�b�V���X�s�[�h
    static float dash_speed = 1.5f;
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

    // Start is called before the first frame update
    void Start()
    {
        otoko = GameObject.Find("���_�j�L�����P").GetComponent<Otoko_chara_Controller>();
        gamedirector = GameObject.Find("GameDirector").GetComponent<gamedirector>();

        //�ŏ��ɃX�s�[�h���[�h�ɒʏ탂�[�h����
        speed_mode = false;
        //�ŏ��Ɍ��݂̃W�����v���[�h�ɒʏ탂�[�h����
        jump_mode = false;
        //�ŏ������������w��
        Ray_length_dekoi = gamedirector.Distance;

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

        //��U���p����
        if (gamedirector.Distance <= 0.6790044f && Input.GetButtonDown("X or J") && Ray_player_hit_dekoi == true)
        {
            jab__distance = true;
        }
        //���U���p����
        if (gamedirector.Distance <= 1.717879f && Input.GetButtonDown("A or K") && Ray_player_hit_dekoi == true)
        {
            kick__distance = true;
        }
        //�͈͊O�ɏo���p
        //��U��
        if (gamedirector.Distance < 0.6790044f)
        {
            jab__distance = false;
        }
        //���U��
        if (gamedirector.Distance <= 1.717879f)
        {
            kick__distance = false;
        }

        //���W����
        otoko1_ray_Origin_dekoi = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z);
        //��������
        otoko1_ray_Vector3_dekoi = new Vector3(-chara_muki_dekoi, 0, 0);
        //���C�𐶐�
        otoko1_ray_dekoi = new Ray(otoko1_ray_Origin_dekoi, otoko1_ray_Vector3_dekoi);
        //�f�o�b�O�p���C
        Debug.DrawRay(otoko1_ray_Origin_dekoi, otoko1_ray_dekoi.direction, Color.red, 60f, false);
        //�����蔻��p���C
        if (Physics.Raycast(otoko1_ray_dekoi, out hit_dekoi,Ray_length_dekoi)) 
        {
            string hitname_dekoi = hit_dekoi.collider.gameObject.tag;
            if (hitname_dekoi.Equals("Player")) 
            {
                Ray_length_dekoi = gamedirector.Distance + 0.1f;
                Ray_player_hit_dekoi = true;
            }
        }
        else
        {
            Ray_player_hit_dekoi = false;
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
        sayuu = Input.GetAxisRaw("H or F");
        //Vector3��Horizontal�EVertical����
        Vector3 idouVec = new Vector3(0, jouge , sayuu * chara_muki_dekoi);

        //�W�����v���Ԃ̌v�Z
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }
        //��U���N�[���^�C���v�Z
        if (dekoi_kougeki_cooltime_jaku < 1.5f)
        {
            dekoi_kougeki_cooltime_jaku += Time.deltaTime;
        }
        //���U���N�[���^�C���v�Z
        if (dekoi_kougeki_cooltime_kyou < 2f)
        {
            dekoi_kougeki_cooltime_kyou += Time.deltaTime;
        }
        //�U���N�[���^�C��
        //��U��
        if (dekoi_kougeki_cooltime_jaku >= 1.5f)
        {
            jab_dekoi_cooltime = true;
        }
        //���U��
        if (dekoi_kougeki_cooltime_kyou >= 2f)
        {
            kick_dekoi_cooltime = true;
        }
        if (dekoi_kougeki_cooltime_jaku >= 1.5f || dekoi_kougeki_cooltime_kyou >= 2f)
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
            dekoi_kougeki_cooltime_jaku = 0;
            Invoke(nameof(Dekoi_Attack_Shoki), 1 / 60f);
        }
        //���U���iA or K�j
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("���U��");
            dekoi_kougeki_attack = 2;
            dekoi_kougeki_cooltime_kyou = 0;
            Invoke(nameof(Dekoi_Attack_Shoki), 1 / 60f);
        }
        //�K�E�Z�iY or I�j
        //if (Input.GetAxisRaw("Y or I") != 0)
        //{
        //    Debug.Log("�K�E�Z");
        //}
        ////�K�[�h(Right(left) Bumper or sperce)   ���W���X�g�K�[�h������
        //if (Input.GetButtonDown("Right(left) Bumper or space"))
        //{
        //    Debug.Log("�K�[�h");
        //}

        //�ړ��ȊO�̓��͂��������Ƃ��� ���蔲���Ȃ��悤�ɂ��� or �ړ��ł��Ȃ��悤�ɂ���
        if (Input.GetButtonDown("Right(left) Bumper or space") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("X or J") || Input.GetKeyDown(KeyCode.Return))
        {
            dekoi_ray_layer = 6;
            gameObject.SetDekoiChild(6);
            gameObject.layer = LayerMask.NameToLayer("Attack");
            idouVec = Vector3.zero;
        }

        //���ړ��̏���
        if (sayuu != 0 && jump_stop == true)
        {
            if (speed_mode == true)
            {
                now_speed = dash_speed;
            }
            else
            {
                now_speed = normal_speed;
            }
            speed_origin = now_speed * 5;
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
            animator.SetTrigger("Trigger_dekoi_Move");
            Real_Time = 0;
            if (jump_mode == true)
            {
                now_jumppower = jump_power;
            }
            else
            {
                now_jumppower = high_jump;
            }
            speed_origin = now_jumppower;
            Dekoi_Jump();
        }
        //�ړ�����
        transform.Translate(speed_origin * Time.deltaTime * idouVec);

        //�ȉ��A�j���[�V����

        //���[���h���W����ɉ�]���擾
        Vector3 World_angle = mytransform.localEulerAngles;
        //���E�ǂ��炩�Ɉړ���
        if (sayuu != 0)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            //�E�ړ�
            if (sayuu > 0)
            {
                //���]����
                chara_muki_dekoi = 1;
                World_angle.y = -90;
                //�A�j���[�V�����ύX
                Dekoi_Move();
            }
            //���ړ�
            else if (sayuu < 0)
            {
                //���]����
                chara_muki_dekoi = -1;
                World_angle.y = 90;
                //�A�j���[�V�����ύX
                Dekoi_Move();
            }
        }
        //�e�U���p�A�j���[�V����
        //��U��(�q�b�g��)
        if (jump_stop == true && dekoi_kougeki_attack == 1 && dekoi_attack_permission == true && jab_dekoi_cooltime == true)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            dekoi_kougeki_hit = 1;
            animator.SetTrigger("Trigger_dekoi_attack");
            gamedirector.Dekoi_attack();
            dekoi_kougeki_hit = 0;
        }
        //���U��(�q�b�g��)
        if (jump_stop == true && dekoi_kougeki_attack == 2 && dekoi_attack_permission == true && kick_dekoi_cooltime == true)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            dekoi_kougeki_hit = 2;
            animator.SetTrigger("Trigger_dekoi_attack");
            gamedirector.Dekoi_attack();
            dekoi_kougeki_hit = 0;
        }
        //��e���[�V����
        if (dekoi_kougeki_hidan != 0)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            if (dekoi_kougeki_hidan == 1)
            {
                Debug.Log("dekoi�Ђ��");
                Dekoi_hirumi();
            }
            if (dekoi_kougeki_hidan == 2)
            {
                Debug.Log("dekoi�_�E��");
                Dekoi_down();
            }
        }
        //��~���
        if (!Input.anyKeyDown)
        {
            //�ϐ�������
            Invoke(nameof(Dekoi_Attack_Shoki), 1 / 60f);
            //���C���[����
            Invoke(nameof(Layer_Shoki), 1 / 60f);
        }
        mytransform.eulerAngles = World_angle;
    }
    //����̕ϐ���������
    public void Dekoi_Attack_Shoki()
    {
        dekoi_kougeki_attack = 0;
        dekoi_kougeki_hit = 0;
    }
    //���C���[������
    public void Layer_Shoki()
    {
        dekoi_ray_layer = 3;
        gameObject.layer = LayerMask.NameToLayer("Player");
        gameObject.SetDekoiChild(3);
    }
    //�����蔻��܂Ƃ�

    //�G�ꑱ���Ă�Ԕ���
    public void OnTriggerStay(Collider stay_other)
    {
        //�n�ʂɂ��Ă���
        if (stay_other.CompareTag("jimen"))
        {
            //�ϐ���Horizontal�EVertical���� ��jouge�̂ݐ���
            jump = Input.GetAxisRaw("Y or G");
            if (jump >= 0)
            {
                jouge = jump;
            }
            jump_stop = true;
        }
    }
    public void OnTriggerEnter(Collider enter_other)
    {
        if (enter_other.CompareTag("tenjou"))
        {
            jouge = -1f;
        }
    }
    //�U���E��e�܂Ƃ�
    public void Dekoi_jab()
    {
        animator.SetTrigger("dekoi_jab");
    }
    public void Dekoi_kick()
    {
        animator.SetTrigger("dekoi_kick");
    }
    public void Dekoi_hirumi()
    {
        animator.SetTrigger("dekoi_jaku_hirumi");
    }
    public void Dekoi_down()
    {
        animator.SetTrigger("dekoi_down");
    }
    public void Dekoi_Jump()
    {
        animator.SetTrigger("dekoi_jump");
    }
    public void Dekoi_Move()
    {
        animator.SetTrigger("dekoi_zensin");
    }
}