using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //���݂̎���
    public float current = 0f;

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
    public Vector3 gravity;

    //�ʏ�X�s�[�h
    float normal_speed = 50;
    //�_�b�V���X�s�[�h
    float dash_speed;
    //���݂̃X�s�[�h���[�h
    float now_speed;

    //�ړ��̕ϐ�
    float sayuu;
    float jouge;

    //�W�����v�̑��x��ݒ�
    float Jump_velocity = 5.0f;
    //�W�����v�N�[���^�C��(�d��)
    public float jump_cooltime = 1.0f;
    //�W�����v�p���[�i����\��j
    float jump_power = 5f;
    //2�i�W�����v�֎~�p
    public bool jump_stop;         //false = �֎~
                                   //true  = ����

    //rigidbody���擾
    Rigidbody rigid;

    //�ړ��i�����j�X�s�[�h
    Vector3 speed_origin;

    //CharacterController��錾
    public CharacterController characterController;

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

        //�ϐ���Horizontal�EVertical����
        sayuu = Input.GetAxisRaw("Horizontal");
        jouge = Input.GetAxisRaw("Vertical");

        //��ɏd�͂�������
        characterController.Move(new Vector3(0, -0.2f, 0));

        //���ړ�(�X�e�B�b�N or ���E���L�[)&�W�����v(�X�e�B�b�N or ����L�[(W�L�[))    
        characterController.Move(new Vector3(sayuu * 0.15f * chara_muki, jouge * 0.5f, 0));

        //���݂̎��Ԃ���
        current += Time.deltaTime;
        //�W�����v�d��
        if (current >= jump_cooltime)
        {
            jump_stop = false;
            current = 0f;
        }
        //�A���W�����v�֎~
        if (jump_stop == false)
        {
            jouge = 0f;
            Debug.Log("�d��");
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
        //�v���C���[�ɐG�ꂽ��
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("�m�F");
            CharaAttack(hit.collider.gameObject);
        }

        //�n�ʂɂ��Ă���
        if (hit.gameObject.CompareTag("jimen"))
        {
            Debug.Log("jimen");
            Invoke(nameof(Chien), 1f);
        }
    }
    //�L�����N�^�[�q�b�g�܂Ƃ�
    void CharaAttack(GameObject obj)
    {
        //��U�����J��o���ꂽ��
        if (kougeki_attack > 0)
        {
            Debug.Log("hit_player");
            Invoke(nameof(Animation_stop), 5f);
        }
    }
    void Chien()
    {
        jump_stop = true;
    }
}
