using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{
    //慣性消去のRigidbody
    public Rigidbody rigidbody = null;

    //現在の時間(最初は1)
    public float Real_Time;

    //攻撃を受けた・与えた状態を管理する用の変数
    public float kougeki_attack;

    //Transformコンポーネントを取得
    Transform mytransform;

    //プレイヤーの移動方向・速度の変数
    Vector3 PlayerVector;
    //移動用Vector3
    public Vector3 idou_houkou;

    //アニメーターコンポーネントを取得
    Animator animator;

    //通常スピード
    float normal_speed = 5f;
    //ダッシュスピード
    float dash_speed = 7.5f;
    //現在のスピードモード
    float now_speed;
    //スピード設定
    float speed_origin;
    //ダッシュモード切替
    public bool speed_mode;
    //false = 通常
    //true  = ダッシュ

    //移動の変数
    public float sayuu;
    public float jouge;

    //ジャンプのクールタイム
    public float JumpCoolTime = 0.5f;
    //ジャンプの時間を判定
    public float jumpTime;
    //通常ジャンプパワー（統一予定）
    float jump_power = 5f;
    //ハイジャンプパワー（統一予定）
    float high_jump = 10f;
    //現在のジャンプ力
    float now_jumppower;
    //2段ジャンプ禁止用
    public bool jump_stop;
    //false = 禁止
    //true  = 許可

    //ジャンプ状態切り替え
    public bool jump_mode;
    //false = 通常状態
    //true  = ハイジャンプ状態

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
        //最初にスピードモードに通常モードを代入
        speed_mode = false;
        //最初に現在のジャンプモードに通常モードを代入
        jump_mode = false;

        //自分の回転度を取得
        mytransform = this.transform;
        animator = GetComponent<Animator>();

        //rigidにコンポーネントを代入
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動制限
        Vector3 MyVector3 = transform.position;
        //X座標
        Mathf.Clamp(MyVector3.x, 4, -4);
        //Y座標
        Mathf.Clamp(MyVector3.y, 4.8f, 9.5f);
        //範囲を越えたらテレポート
        transform.position = MyVector3;

        //変数を代入
        jouge = Input.GetAxisRaw("Vertical");
        sayuu = Input.GetAxisRaw("Horizontal");

        //移動速度のVector3(仮)
        Vector3 sokudo = new Vector3(now_speed, now_jumppower, 0);

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

        if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = now_speed;
        }
        if (Input.GetButtonDown("Vertical")) 
        {
            speed_origin = now_jumppower;
        }
        //経過時間をReal_Timeに入れる
        Real_Time += Time.deltaTime;

        //現在の時間を代入
        if (Real_Time >= JumpCoolTime)
        {
            Debug.Log("OK");
        }
        //ジャンプ時間の計算
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }
        //ジャンプの処理
        //地面についてたら
        if (jump_stop == true)
        {
            //ジャンプ入力がされてたら
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

        //横移動の処理
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

        //変数にHorizontal・Verticalを代入
        Vector3 idou_houkou = new Vector3(0, PlayerVector.y, PlayerVector.x);
        //移動処理
        transform.Translate(speed_origin * Time.deltaTime * idou_houkou);

        //以下アニメーション

        //ワールド座標を基準に回転を取得
        Vector3 World_angle = mytransform.eulerAngles;
        //左右どちらかに移動中
        if (sayuu != 0)
        {
            //右移動
            if (sayuu > 0)
            {
                Debug.Log("右");
                //反転処理
                World_angle.y = -90;
                //アニメーション変更
                animator.SetInteger("stop", 1);
            }
            //左移動
            else if (sayuu < 0)
            {
                Debug.Log("左");
                //反転処理
                World_angle.y = 90;
                //アニメーション変更
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
    //当たり判定まとめ
    private void OnTriggerStay(Collider other)
    {
        //地面についてたら
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
