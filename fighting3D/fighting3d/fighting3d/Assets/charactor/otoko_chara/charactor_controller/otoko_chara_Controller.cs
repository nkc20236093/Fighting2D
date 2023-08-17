using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //現在の時間
    public float current = 0f;

    //攻撃を受けた・与えた状態を管理する用の変数
    public float kougeki_attack;

    //Transformコンポーネントを取得
    Transform mytransform;
    //向き変更用変数
    float chara_muki;
    //向き変更の管理用
    public bool muki;  //false = 右
                       //true  = 左

    //プレイヤーの移動方向・速度の変数
    Vector3 PlayerVector;

    //アニメーターコンポーネントを取得
    Animator animator;

    //重力用変数
    public Vector3 gravity;

    //通常スピード
    float normal_speed = 50;
    //ダッシュスピード
    float dash_speed;
    //現在のスピードモード
    float now_speed;

    //移動の変数
    float sayuu;
    float jouge;

    //ジャンプの速度を設定
    float Jump_velocity = 5.0f;
    //ジャンプクールタイム(硬直)
    public float jump_cooltime = 1.0f;
    //ジャンプパワー（統一予定）
    float jump_power = 5f;
    //2段ジャンプ禁止用
    public bool jump_stop;         //false = 禁止
                                   //true  = 許可

    //rigidbodyを取得
    Rigidbody rigid;

    //移動（総合）スピード
    Vector3 speed_origin;

    //CharacterControllerを宣言
    public CharacterController characterController;

    //レイが地面にヒットしたかの判定
    public bool rayhit = false;
    //各初期ステータス

    //HP
    int hp = 10;
    //攻撃力
    int attack = 10;
    //素早さ
    int speed = 10;
    //スタミナ
    int stamina = 10;
    //賢さ
    int cleverness = 10;

    // Start is called before the first frame update
    void Start()
    {
        //最初に現在のスピードに通常スピードを代入
        now_speed = normal_speed;
        //自分の回転度を取得
        mytransform = this.transform;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //以下基本動作

        //弱攻撃（X or J）
        if (Input.GetAxisRaw("X or J") != 0)
        {
            animator.SetInteger("stop", 2);
            Debug.Log("弱攻撃");
            kougeki_attack = 1;
        }
        //各行動終了次第停止状態に変更
        else
        {
            //アニメーション変更
            Invoke(nameof(Animation_stop), 5f);
        }
        //強攻撃（A or K）
        if (Input.GetAxisRaw("A or K") != 0)
        {
            Debug.Log("強攻撃");
        }
        //投げ攻撃（B or L）
        if (Input.GetAxisRaw("B or L") != 0)
        {
            Debug.Log("投げ攻撃");
        }
        //必殺技（Y or I）
        if (Input.GetAxisRaw("Y or I") != 0)
        {
            Debug.Log("必殺技");
        }
        //ガード(Right(left) Bumper or sperce)   ※ジャストガードも検討
        if (Input.GetButtonDown("Right(left) Bumper or sperce")) 
        {
            Debug.Log("ガード");
        }

        //向き変更用
        if (sayuu > 0)
        {
            muki = false;
        }
        else if (sayuu < 0)
        {
            muki = true;
        }

        //変数にHorizontal・Verticalを代入
        sayuu = Input.GetAxisRaw("Horizontal");
        jouge = Input.GetAxisRaw("Vertical");

        //常に重力をかける
        characterController.Move(new Vector3(0, -0.2f, 0));

        //横移動(スティック or 左右矢印キー)&ジャンプ(スティック or 上矢印キー(Wキー))    
        characterController.Move(new Vector3(sayuu * 0.15f * chara_muki, jouge * 0.5f, 0));

        //現在の時間を代入
        current += Time.deltaTime;
        //ジャンプ硬直
        if (current >= jump_cooltime)
        {
            jump_stop = false;
            current = 0f;
        }
        //連続ジャンプ禁止
        if (jump_stop == false)
        {
            jouge = 0f;
            Debug.Log("重力");
        }

        //以下アニメーション

        //ワールド座標を基準に回転を取得
        Vector3 World_angle = mytransform.eulerAngles;
        //左右どちらかに移動中
        if (sayuu != 0)
        {
            //右移動
            if (muki == false)
            {
                //反転処理
                World_angle.y = -90;
                chara_muki = -1;
                //アニメーション変更
                animator.SetInteger("stop", 1);
            }
            //左移動
            else
            {
                //反転処理
                World_angle.y = 90;
                //アニメーション変更
                chara_muki = -1;
                animator.SetInteger("stop", 1);
            }
        }
        //停止状態
        else
        {
            //アニメーション変更
            Invoke(nameof(Animation_stop), 1f);
        }
        mytransform.eulerAngles = World_angle;
    }
    //停止状態のアニメーション
    void Animation_stop()
    {
        animator.SetInteger("stop", 0);
        kougeki_attack = 0;
    }
    //characterControllerを利用した当たり判定
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //プレイヤーに触れたら
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("確認");
            CharaAttack(hit.collider.gameObject);
        }

        //地面についてたら
        if (hit.gameObject.CompareTag("jimen"))
        {
            Debug.Log("jimen");
            Invoke(nameof(Chien), 1f);
        }
    }
    //キャラクターヒットまとめ
    void CharaAttack(GameObject obj)
    {
        //弱攻撃が繰り出されたら
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
