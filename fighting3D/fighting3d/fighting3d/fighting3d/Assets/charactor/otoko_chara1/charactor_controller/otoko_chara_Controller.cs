using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Otoko_chara_Controller : MonoBehaviour
{
    //Ray�̒���
    public static float Ray_length = 8;
    //Ray���q�b�g�����I�u�W�F�N�g��ۑ�
    string hitname;
    //���C���擾
    Ray otoko1_ray;
    //���C�̌��_
    Vector3 otoko1_ray_Origin;
    //���C�̕���
    Vector3 otoko1_ray_Vector3;
    //���C�L���X�g�q�b�g���擾
    RaycastHit hit;
    //���C���v���C���[�ɓ����������ǂ���
    public bool Ray_player_hit;
    //���C���g���K�[�t���R���C�_�[�ɔ�����o����
    QueryTriggerInteraction queryTrigger;

    //GunMan���擾
    public GauMan GauMan;
    //�q�I�u�W�F�N�g�p
    public Transform otoko1_obj_Child;
    //�R���C�_�[��ۑ�
    new Collider collider; 

    //�j1�̃��C���[�p�ϐ�
    public int otoko_layer;

    //�A�j���[�^�[�R���|�[�l���g���擾
    Animator animator;
    //Transform�R���|�[�l���g���擾
    Transform mytransform;

    //Rigidbody���擾
    public new Rigidbody rigidbody;

    //�Q�[���f�B���N�^�[���擾
    public gamedirector gamedirector;
    //�e�X�g�p�̃f�R�C�i�Q�[���I�u�W�F�N�g�j���擾
    public dekoi dekoi;

    //���݂̎���
    public float Real_Time;

    //�U�����󂯂��E�^������Ԃ��Ǘ�����p�̕ϐ���
    public int otoko1_kougeki_hidan;   //�U�����󂯂��p(�Q�[���f�B���N�^�[����󂯎��)
    public int otoko1_kougeki_attack;  //�U���m�F�p
    public int otoko1_kougeki_hit;     //�U���q�b�g�p
    public bool otoko1_guard;          //�K�[�h�pbool
    public bool otoko1_just_guard;     //�W���X�g�K�[�h����pbool
    public bool otoko1_normal_guard;   //�m�[�}���K�[�h����pbool
    //�U����������pbool
    public bool otoko1_jab_distance;
    public bool otoko1_kick_distance;
    //�U���N�[���^�C��
    public bool jaku_stop;
    public bool kyou_stop;
    //�U���N�[���^�C���p�ϐ�
    public float attack_cooltime_jaku;
    public float attack_cooltime_kyou;
    //��U�����pbool
    public bool jab_attack_cooltime_permission;
    //���U�����pbool
    public bool kick_attack_cooltime_permission;
    //�Q�[���f�B���N�^�[�p�U�����pbool
    public bool attack_cooltime_permisson;
    public bool attack_distance_permission;
    //true = ����
    //false= �s����
    //�U���񐔗p�ϐ�
    public int first_attack_int;
    //�U���񐔗pbool
    public bool first_attack;
    //true = �ŏ�(1���)
    //false= 2���

    //�L���������ύX�p�ϐ�
    public float chara_muki;

    //�ʏ�X�s�[�h
    public static float normal_speed = 1f;
    //�_�b�V���X�s�[�h
    public static float dash_speed = 1.5f;
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
    //�ړ��pVector3
    public Vector3 idouVec;

    //�W�����v�̃N�[���^�C��
    public float JumpCoolTime = 5f;
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
    //�W�����v�񐔗p
    public float first_jump;
    //�W�����v��Ԑ؂�ւ�
    public bool jump_mode;
    //false = �ʏ���
    //true  = �n�C�W�����v���

    // Start is called before the first frame update
    void Start()
    {
        //�S�Ă̎q�I�u�W�F�N�g�̎擾
        otoko1_obj_Child = this.gameObject.GetComponentInChildren<Transform>();

        //�ŏ��ɃX�s�[�h���[�h�ɒʏ탂�[�h����
        speed_mode = false;
        //�ŏ��Ɍ��݂̃W�����v���[�h�ɒʏ탂�[�h����
        jump_mode = false;
        //�ŏ���false
        otoko1_guard = false;
        otoko1_just_guard = false;
        otoko1_normal_guard = false;

        //�����̉�]�x���擾
        mytransform = this.transform;
        //�A�j���[�^�[����
        animator = GetComponent<Animator>();

        //rigid�ɃR���|�[�l���g����
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //��e��ϐ��ɑ��
        otoko1_kougeki_hidan = gamedirector.hidan_otoko1;
        //��U���p����
        if (gamedirector.Distance <= 0.73f)
        {
            Debug.Log("�㋗����");
            otoko1_jab_distance = true;
        }
        //���U���p����
        if (gamedirector.Distance <= 1.71f)
        {
            Debug.Log("��������");
            otoko1_kick_distance = true;
        }
        //�͈͊O�ɏo���p
        //��͈�
        if (gamedirector.Distance > 0.73f)
        {
            otoko1_jab_distance = false;
        }
        //���͈�
        if (gamedirector.Distance > 1.71f)
        {
            otoko1_kick_distance = false;
        }

        //���W����
        otoko1_ray_Origin = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z) ;
        //��������
        otoko1_ray_Vector3 = new Vector3(-chara_muki, 0, 0);
        //���C�𐶐�
        otoko1_ray = new Ray(otoko1_ray_Origin, otoko1_ray_Vector3);
        //�f�o�b�O�p���C
        Debug.DrawRay(otoko1_ray_Origin, otoko1_ray.direction * Ray_length, Color.red, 1, false) ;
        //�����蔻��p���C
        if (Physics.Raycast(otoko1_ray, out hit, Ray_length))
        {
            //�q�b�g�����I�u�W�F�N�g�̃^�O���擾
            hitname = hit.collider.gameObject.tag;
            //�q�b�g�����I�u�W�F�N�g�̂̃^�O��Player��������
            if (hitname.Equals("Player"))
            {
                Ray_player_hit = true;
            }
        }
        else
        {
            Ray_player_hit = false;
        }

        //�q�I�u�W�F�N�g��S�Ď擾
        otoko1_obj_Child.GetComponentInChildren<Transform>();

        //�N�[���^�C���Ɏ��Ԃ�����
        if (attack_cooltime_jaku <= 1f && first_attack == false)
        {
            attack_cooltime_jaku += Time.deltaTime;
        }
        if (attack_cooltime_kyou <= 1.5f && first_attack == false)
        {
            attack_cooltime_kyou += Time.deltaTime;
        }
        //�U������
        if (first_attack == true)
        {
            jab_attack_cooltime_permission = true;
            kick_attack_cooltime_permission = true;
        }
        if (attack_cooltime_jaku > 1f)
        {
            jab_attack_cooltime_permission = true;
        }
        else
        {
            jab_attack_cooltime_permission = false;
        }
        if (attack_cooltime_kyou > 1.5f) 
        {
            kick_attack_cooltime_permission = true;
        }
        else
        {
            kick_attack_cooltime_permission = false;
        }
        //�Q�[���f�B���N�^�[�p
        if (jab_attack_cooltime_permission == true || kick_attack_cooltime_permission == true)
        {
            attack_cooltime_permisson = true;
        }
        else if (jab_attack_cooltime_permission == false && kick_attack_cooltime_permission == true || jab_attack_cooltime_permission == true && kick_attack_cooltime_permission == false)
        {
            attack_cooltime_permisson = false;
        }
        if (otoko1_jab_distance == true || otoko1_kick_distance == true)
        {
            attack_distance_permission = true;
        }
        else if (otoko1_jab_distance == false && otoko1_kick_distance == true || otoko1_jab_distance == true && otoko1_kick_distance == false)
        {
            attack_distance_permission = false;
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
        if (otoko1_guard == false)
        {
            idouVec = new Vector3(0, jouge, sayuu * chara_muki);
        }
        //�W�����v���Ԃ̌v�Z
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }

        //�ȉ���{����

        //��U���iX or J�j
        if (Input.GetButtonDown("X or J") && jump_stop == true && jab_attack_cooltime_permission)
        {
            Debug.Log("��U��");
            otoko1_kougeki_attack = 1;
            animator.SetTrigger("Trigger_attack");
            attack_cooltime_jaku = 0;
            Invoke(nameof(Hensuu_shoki), 0.5f);
            Jab();
        }
        //���U���iA or K�j
        if (Input.GetButtonDown("A or K") && jump_stop == true && kick_attack_cooltime_permission)
        {
            Debug.Log("���U��");
            otoko1_kougeki_attack = 2;
            animator.SetTrigger("Trigger_attack");
            attack_cooltime_kyou = 0;
            Invoke(nameof(Hensuu_shoki), 0.5f);
            Kick();
        }
        //�K�E�Z�iY or I�j
        if (Input.GetButtonDown("Y or I") && jump_stop == true)
        {
            Debug.Log("�K�E�Z");
        }
        //�K�[�h(Right(left) Bumper or sperce)   ���W���X�g�K�[�h������
        if (Input.GetButtonDown("Right(left) Bumper or space") && jump_stop == true)
        {
            otoko1_guard = true;
            Debug.Log("�K�[�h");
        }
        //�ړ��ȊO�̓��͂��������Ƃ��� ���蔲���Ȃ��悤�ɂ��� or �ړ��ł��Ȃ��悤�ɂ��� & �ꕔ�ϐ��������ď�����
        if (Input.GetButtonDown("Right(left) Bumper or space") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("A or K") || Input.GetButtonDown("X or J")) 
        {
            //���C���[�ύX
            gameObject.SetChildLayer(7);
            gameObject.layer = LayerMask.NameToLayer("Attack");
        }

        //�W�����v�̓��͂��������Ƃ��͉��ړ��ł��Ȃ��悤�ɂ���
        if (jouge > 0)
        {
            idouVec = new Vector3(0, jouge, 0);
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
            speed_origin = now_speed * 5f;
        }

        //speed_origin�ɑ��
        if (Input.GetButtonDown("Vertical"))
        {
            speed_origin = now_jumppower;
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = now_speed;
        }
        //�ړ�����
        transform.Translate(speed_origin * Time.deltaTime * idouVec);


        //�ȉ��A�j���[�V����

        //�ŏ��̃W�����v���
        if (Input.GetAxisRaw("Vertical") > 0 && first_jump == 0 && jump_stop == true)
        {
            first_jump++;
        }
        //�W�����v�̏���
        //1���&�n�ʂɂ��Ă���&�W�����v���͂�����Ă���
        if (jump_stop == true && Input.GetAxisRaw("Vertical") > 0 && first_jump == 1)
        {
            Debug.Log("first_jump");
            jump_stop = false;
            Real_Time = 0;
            animator.SetTrigger("Trigger_Move");
            JUMP();
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
        //2���&�n�ʂɂ��Ă���&�W�����v���͂�����Ă���&�N�[���^�C�����I�������
        else if (jump_stop == true && Input.GetAxisRaw("Vertical") > 0 && Real_Time >= JumpCoolTime && first_jump >= 2)
        {
            Debug.Log("second_jump");
            jump_stop = false;
            Real_Time = 0;
            animator.SetTrigger("Trigger_Move");
            JUMP();
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
        //�U���A�j���[�V����

        //�U���̏���
        //�ŏ��̍U������
        if (jump_stop == true && otoko1_kougeki_attack == 1 && first_attack_int <= 3)
        {
            first_attack_int++;
        }
        //1���&�n�ʂɂ��Ă���&��(��)�U�����͂�����Ă���
        if (jump_stop == true && otoko1_kougeki_attack == 1 && first_attack_int == 1)
        {
            first_attack = true;
        }
        //2���&�n�ʂɂ��Ă���&��(��)�U�����͂�����Ă���
        if (jump_stop == true && first_attack_int >= 2 && otoko1_kougeki_attack == 2 || otoko1_kougeki_attack == 1)
        {
            first_attack = false;
        }

        //��U��(�q�b�g��)
        if (otoko1_kougeki_attack == 1 && jump_stop && otoko1_jab_distance && Ray_player_hit && jab_attack_cooltime_permission)
        {
            Debug.Log("��q�b�g");
            otoko1_kougeki_hit = 1;
        }
        //���U��(�q�b�g��)
        if (jump_stop == true && otoko1_kougeki_attack == 2 && kick_attack_cooltime_permission == true && otoko1_kick_distance == true && Ray_player_hit == true)
        {
            Debug.Log("���q�b�g");
            otoko1_kougeki_hit = 2;
        }
        //�K�[�h
        if (otoko1_guard == true)
        {
            //�W���X�g�K�[�h
            if (otoko1_guard == true && otoko1_kougeki_hidan != 0)
            {
                otoko1_just_guard = true;
                Debug.Log("�W���X�g�K�[�h");
                animator.SetTrigger("Trigger_Move");
                Just_Guard();
            }
            //���ʂ̃K�[�h
            else if (otoko1_guard == true)
            {
                otoko1_normal_guard = true;
                Debug.Log("�m�[�}���K�[�h");
                animator.SetTrigger("Trigger_Move");
                Guard();
            }
            Invoke(nameof(Guard_reset), 0.5f);
        }
        //��e�A�j���[�V����
        if (otoko1_kougeki_hidan != 0 && otoko1_guard == false)
        {
            //���C���[�ύX
            gameObject.SetChildLayer(6);
            gameObject.layer = LayerMask.NameToLayer("Hantei");
            if (otoko1_kougeki_hidan == 1)
            {
                Debug.Log("otoko1�Ђ��");
                Hirumi();
            }
            else if (otoko1_kougeki_hidan == 2)
            {
                Debug.Log("otoko�_�E��");
                Down();
            }
        }

        //���[�J�����W����ɉ�]���擾
        Vector3 Local_angle = mytransform.localEulerAngles;
        //���E�ǂ��炩�Ɉړ���
        if (sayuu != 0)
        {
            //���C���[�ύX
            gameObject.SetChildLayer(6);
            gameObject.layer = LayerMask.NameToLayer("Hantei");
            //�A�j���[�V��������
            animator.SetTrigger("Trigger_Move");
            //�E�ړ�
            if (sayuu > 0)
            {
                //�A�j���[�V�����ύX
                animator.SetTrigger("Trigger_walk");
                //���]����
                chara_muki = 1;
                Local_angle.y = -90;
            }
            //���ړ�
            else if (sayuu < 0)
            {
                //�A�j���[�V�����ύX
                animator.SetTrigger("Trigger_walk");
                //���]����
                chara_muki = -1;
                Local_angle.y = 90;
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
        mytransform.eulerAngles = Local_angle;

        //�q�b�g������
        if (otoko1_kougeki_hit != 0)
        {
            Debug.Log("�q�b�g������");
            Invoke(nameof(Hit_Shoki_otoko1), 0.0475f);
        }
    }
    //��~��Ԃ̕ϐ�������
    public void Hensuu_shoki()
    {
        otoko1_kougeki_attack = 0;
        otoko1_kougeki_hidan = 0;
    }
    public void Hit_Shoki_otoko1()
    {
        otoko1_kougeki_hit = 0;
    }
    //���C���[������
    void Layer_shoki()
    {
        gameObject.SetChildLayer(3);
        gameObject.layer = LayerMask.NameToLayer("Player");
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
    }

    //��U��
    public void Jab()
    {
        animator.SetTrigger("return_jab");
        attack_cooltime_jaku = 0;
    }
    public void Kick()
    {
        animator.SetTrigger("return_kick");
        attack_cooltime_kyou = 0;
    }

    public void Hirumi()
    {
        //�A�j���[�V�������s
        animator.SetTrigger("return_jaku_hirumi");
    }
    public void Down()
    {
        //�A�j���[�V�������s
        animator.SetTrigger("return_down");
    }
    public void JUMP()
    {
        animator.SetTrigger("Trigger_Jump");
    }
    public void Guard()
    {
        animator.SetTrigger("Trigger_guard");
        Invoke(nameof(Guard_Chien), 0.3f);
    }
    public void Guard_Chien()
    {
        otoko1_kougeki_attack = 0;
        idouVec = new Vector3(0, jouge, 0);
    }
    public void Just_Guard()
    {
        animator.SetTrigger("Trigger_guard");
    }
    public void Guard_reset()
    {
        otoko1_guard = false;
        otoko1_normal_guard = false;
        otoko1_just_guard = false;
    }
}
