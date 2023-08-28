using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Otoko_chara_Controller : MonoBehaviour
{
    //ヒット時のイベント
    public UnityEvent Onhit;
    //アニメーターコンポーネントを取得
    Animator animator;
    //Rigidbodyを取得
    public new Rigidbody rigidbody;

    //テスト用のデコイ（ゲームオブジェクト）を取得
    dekoi dekoi;
    //現在の時間
    public float Real_Time;

    //攻撃を受けた・与えた状態を管理する用の変数
    public int kougeki_attack;          //攻撃を受けた用
    public int otoko_kougeki_attack;   //攻撃を与えた用

    //Transformコンポーネントを取得
    Transform mytransform;

    //キャラ向き変更用変数
    float chara_muki;

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
    //jougeの受け渡し先
    public float jump;

    //ジャンプのクールタイム
    public float JumpCoolTime = 1f;
    //ジャンプの時間を判定
    public float jumpTime;
    //通常ジャンプパワー（統一予定）
    float jump_power = 3f;
    //ハイジャンプパワー（統一予定）
    float high_jump = 5f;
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
    //素早さ(俊敏)
    int speed = 10;
    //スタミナ(耐久)
    int stamina = 10;
    //賢さ(熟知)
    int cleverness = 10;

    // Start is called before the first frame update
    void Start()
    {
        //デコイに代入
        dekoi = GameObject.Find("dekoi").GetComponent<dekoi>();
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
        kougeki_attack = dekoi.dekoi_kougeki_attack;

        //移動制限
        Vector3 Pos = transform.position;
        //X座標
        Pos.x = Mathf.Clamp(Pos.x, -4, 4);
        //Y座標
        Pos.y = Mathf.Clamp(Pos.y, 4.8f, 6.62f);
        //範囲を越えたらテレポート
        transform.position = Pos;

        //入力マネージャーを使用した移動方法 ※Verticalは移動
        sayuu = Input.GetAxisRaw("Horizontal");
        //Vector3にHorizontal・Verticalを代入
        Vector3 idouVec = new Vector3(0, jouge * 1.5f, sayuu * chara_muki);

        //ジャンプ時間の計算
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }
        
        //以下基本動作

        //弱攻撃（X or J）
        if (Input.GetAxisRaw("X or J") != 0)
        {
            animator.SetInteger("stop", 2);
            Debug.Log("弱攻撃");
            otoko_kougeki_attack = 1;
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
            animator.SetInteger("stop", 3);
            Debug.Log("強攻撃");
            otoko_kougeki_attack = 2;
        }
        //各行動終了次第停止状態に変更
        else
        {
            //アニメーション変更
            Invoke(nameof(Animation_stop), 5f);
        }
        //投げ攻撃（B or L）
        if (Input.GetAxisRaw("B or L") != 0)
        {
            Debug.Log("投げ攻撃");
        }
        //各行動終了次第停止状態に変更
        else
        {
            //アニメーション変更
            Invoke(nameof(Animation_stop), 5f);
        }
        //必殺技（Y or I）
        if (Input.GetAxisRaw("Y or I") != 0)
        {
            Debug.Log("必殺技");
        }
        //各行動終了次第停止状態に変更
        else
        {
            //アニメーション変更
            Invoke(nameof(Animation_stop), 5f);
        }
        //ガード(Right(left) Bumper or sperce)   ※ジャストガードも検討
        if (Input.GetButtonDown("Right(left) Bumper or sperce"))
        {
            Debug.Log("ガード");
        }
        //各行動終了次第停止状態に変更
        else
        {
            //アニメーション変更
            Invoke(nameof(Animation_stop), 5f);
        }
        //移動以外の入力があったときは すり抜けないようにする or 移動できないようにする
        if (Input.GetButtonDown("Right(left) Bumper or sperce") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetButtonDown("A or K") || Input.GetButtonDown("X or J")) 
        {
            gameObject.layer = LayerMask.NameToLayer("Attack");
            idouVec = Vector3.zero;
        }
        //移動入力があったらレイヤー変更
        if (jouge > 0 || sayuu != 0)
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
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
            speed_origin = now_speed;
        }
        //speed_originに代入
        if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = now_speed;
        }
        if (Input.GetButtonDown("Vertical"))
        {
            speed_origin = now_jumppower;
        }
        //ジャンプの処理
        //地面についてたら&ジャンプ入力がされてたら
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
        //移動処理
        transform.Translate(speed_origin * Time.deltaTime * idouVec);

        //以下アニメーション

        //ワールド座標を基準に回転を取得
        Vector3 World_angle = mytransform.eulerAngles;
        //左右どちらかに移動中
        if (sayuu != 0)
        {
            //右移動
            if (sayuu > 0)
            {
                //反転処理
                chara_muki = 1;
                World_angle.y = -90;
                //アニメーション変更
                animator.SetInteger("stop", 1);
            }
            //左移動
            else if (sayuu < 0)
            {
                //反転処理
                chara_muki = -1;
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
        otoko_kougeki_attack = 0;
    }
    //当たり判定まとめ
    private void OnTriggerStay(Collider other)
    {
        //地面についてたら
        if (other.CompareTag("jimen"))
        {
            //変数にHorizontal・Verticalを代入 ※jougeのみ制限
            jump = Input.GetAxisRaw("Vertical");
            if (jump >= 0)
            {
                jouge = jump;
            }
            jump_stop = true;
        }
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }
    void Chien()
    {
        jump_stop = false;
        Debug.Log("遅延");
        jouge = -1f;
    }
    //攻撃付与・被弾まとめ
    public void Attack()
    {
        //被ダメージ時
        if (kougeki_attack != 0)
        {
            //弱ひるみ(弱攻撃)
            if (kougeki_attack == 1)
            {
                //レイヤー変更
                gameObject.layer = LayerMask.NameToLayer("Attack");
                animator.SetInteger("stop", 4);
                Debug.Log("player_弱ひるみ");
            }
        }

        //与ダメージ時

        //弱攻撃
        if (otoko_kougeki_attack == 1)
        {
            //レイヤー変更
            gameObject.layer = LayerMask.NameToLayer("Attack");
            Debug.Log("player_kougeki_attack1");
        }
        //強攻撃
        if (otoko_kougeki_attack == 2)
        {
            //レイヤー変更
            gameObject.layer = LayerMask.NameToLayer("Attack");
            Debug.Log("player_kougeki_attack2");
        }
        
    }
}
