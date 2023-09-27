using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_Controller : MonoBehaviour
{


    //攻撃を押したら距離関係なくHPゲージを
    //減らす処理（当たり判定できたら移動）
    //の攻撃力


    public static float AttackJakuTakeru;





    //Rayの長さ
    [SerializeField] public float Ray_length = 8;
    //Rayがヒットしたオブジェクトを保存
    string hitname;
    //Rayのヒットした座標
    Vector3 Ray_hit;
    //レイを取得
    Ray otoko1_ray;
    //レイの原点
    Vector3 otoko1_ray_Origin;
    //レイの方向
    Vector3 otoko1_ray_Vector3;
    //レイキャストヒットを取得
    RaycastHit hit;
    //レイがプレイヤーに当たったかどうか
    public bool Ray_player_hit;
    //レイがトリガー付きコライダーに判定を出すか
    QueryTriggerInteraction queryTrigger;

    //GunManを取得
    public GauMan GauMan;
    //子オブジェクト用
    public Transform otoko1_obj_Child;
    //コライダーを保存
    new Collider collider; 

    //男1のレイヤー用変数
    public int otoko_layer;

    //アニメーターコンポーネントを取得
    Animator animator;
    //Transformコンポーネントを取得
    Transform mytransform;

    //被弾アニメーション用int
    public int hirumi_anim_int;

    //Rigidbodyを取得
    public new Rigidbody rigidbody;

    //ゲームディレクターを取得
    public gamedirector gamedirector;
    //テスト用のデコイ（ゲームオブジェクト）を取得
    public dekoi dekoi;

    //現在の時間
    public float Real_Time;

    //攻撃を受けた・与えた状態を管理する用の変数等
    public int otoko1_kougeki_hidan;                //攻撃を受けた用(ゲームディレクターから受け取り)
    public int otoko1_kougeki_attack;               //攻撃確認用
    public int otoko1_kougeki_hit;                  //攻撃ヒット用int
    public bool otoko1_attack_timing;               //攻撃のトリガー
    public bool otoko1_guard = false;               //ガード用bool
    public bool otoko1_just_guard = false;          //ジャストガード判定用bool
    public bool otoko1_normal_guard = false;        //ノーマルガード判定用bool
    //攻撃距離判定用bool
    public bool otoko1_jab_distance = false;
    public bool otoko1_kick_distance = false;
    //攻撃クールタイム
    public bool jaku_stop;
    public bool kyou_stop;
    //攻撃クールタイム用変数
    public float attack_cooltime_jaku;
    public float attack_cooltime_kyou;
    //弱攻撃許可用bool
    public bool jab_attack_cooltime_permission = false;
    //強攻撃許可用bool
    public bool kick_attack_cooltime_permission = false;
    //ゲームディレクター用攻撃許可用bool
    public bool attack_cooltime_permisson = false;
    public bool attack_distance_permission = false;
    //true = 許可
    //false= 不許可
    //攻撃回数用変数
    public int first_attack_int;
    //攻撃回数用bool
    public bool first_attack;
    //true = 最初(1回目)
    //false= 2回目

    //キャラ向き変更用変数
    public float chara_muki;

    //通常スピード
    public static float normal_speed = 1f;
    //ダッシュスピード
    public static float dash_speed = 1.5f;
    //現在のスピードモード
    float now_speed;
    //スピード設定
    float speed_origin;
    //ダッシュモード切替
    public bool speed_mode = false;
    //false = 通常
    //true  = ダッシュ

    //移動の変数
    public float sayuu;
    public float jouge;
    //jougeの受け渡し先
    public float jump;
    //移動用Vector3
    public Vector3 idouVec;

    //ジャンプのクールタイム
    public float JumpCoolTime = 5f;
    //ジャンプの時間を判定
    public float jumpTime;
    //通常ジャンプパワー（統一予定）
    float jump_power = 3f;
    //ハイジャンプパワー（統一予定）
    float high_jump = 5f;
    //現在のジャンプ力
    float now_jumppower;
    //2段ジャンプ禁止用
    public bool jump_stop = false;
    //false = 禁止
    //true  = 許可
    //ジャンプ回数用
    public float first_jump;
    //ジャンプ状態切り替え
    public bool jump_mode = false;
    //false = 通常状態
    //true  = ハイジャンプ状態

    // Start is called before the first frame update
    void Start()
    {
        //全ての子オブジェクトの取得
        otoko1_obj_Child = this.gameObject.GetComponentInChildren<Transform>();

        //最初にスピードモードに通常モードを代入
        speed_mode = false;
        //最初に現在のジャンプモードに通常モードを代入
        jump_mode = false;
        //最初はオン
        otoko1_attack_timing = true;

        //自分の回転度を取得
        mytransform = this.transform;
        //アニメーターを代入
        animator = GetComponent<Animator>();

        //rigidにコンポーネントを代入
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (otoko1_attack_timing)
        {
            otoko1_attack_timing=false;
        }
        //被弾を変数に代入
        otoko1_kougeki_hidan = gamedirector.hidan_otoko1;
        //弱攻撃用距離
        if (gamedirector.Distance <= 0.73f)
        {
            Debug.Log("弱距離内");
            otoko1_jab_distance = true;
        }
        //強攻撃用距離
        if (gamedirector.Distance <= 1.71f)
        {
            Debug.Log("強距離内");
            otoko1_kick_distance = true;
        }
        //範囲外に出た用
        //弱範囲
        if (gamedirector.Distance > 0.73f)
        {
            otoko1_jab_distance = false;
        }
        //強範囲
        if (gamedirector.Distance > 1.71f)
        {
            otoko1_kick_distance = false;
        }

        //座標を代入
        otoko1_ray_Origin = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.1f, transform.position.z) ;
        //方向を代入
        otoko1_ray_Vector3 = new Vector3(-chara_muki, 0, 0);
        //レイを生成
        otoko1_ray = new Ray(otoko1_ray_Origin, otoko1_ray_Vector3);
        //デバッグ用レイ
        Debug.DrawRay(otoko1_ray_Origin, otoko1_ray.direction * Ray_length, Color.red, 1, false) ;
        //当たり判定用レイ
        if (Physics.Raycast(otoko1_ray, out hit, Ray_length))
        {
            //ヒットしたオブジェクトのタグを取得
            hitname = hit.collider.gameObject.tag;
            //ヒットしたオブジェクトののタグがPlayerだったら
            if (hitname.Equals("Player"))
            {
                Debug.Log("Ray_Hit_plaeyr");
                Ray_player_hit = true;
            }
        }
        else
        {
            Debug.Log("No_ray_hit");
            Ray_player_hit = false;
        }

        //子オブジェクトを全て取得
        otoko1_obj_Child.GetComponentInChildren<Transform>();

        //クールタイムに時間を入れる
        if (attack_cooltime_jaku < 1f && first_attack == false)
        {
            attack_cooltime_jaku += Time.deltaTime;
        }
        if (attack_cooltime_kyou < 1.5f && first_attack == false)
        {
            attack_cooltime_kyou += Time.deltaTime;
        }
        //攻撃許可
        if (first_attack == true)
        {
            jab_attack_cooltime_permission = true;
            kick_attack_cooltime_permission = true;
        }
        if (attack_cooltime_jaku >= 1f)
        {
            jab_attack_cooltime_permission = true;
        }
        if (attack_cooltime_kyou >= 1.5f)
        {
            kick_attack_cooltime_permission = true;
        }
        //ゲームディレクター用
        if (jab_attack_cooltime_permission == true || kick_attack_cooltime_permission == true)
        {
            Debug.Log("クールタイム");
            attack_cooltime_permisson = true;
        }
        if (otoko1_jab_distance == true || otoko1_kick_distance == true)
        {
            Debug.Log("距離");
            attack_distance_permission = true;
        }

        //移動制限
        Vector3 Pos = transform.position;
        //X座標
        Pos.x = Mathf.Clamp(Pos.x, -4, 4);
        //Y座標
        Pos.y = Mathf.Clamp(Pos.y, 4.8f, 6.62f);
        //範囲を越えたらテレポート
        transform.position = Pos;
        //天井にぶつかったら落下
        if (transform.position.y >= 6.62f)
        {
            jouge = -2f;
        }
        //入力マネージャーを使用した移動方法 ※Verticalは移動
        sayuu = Input.GetAxisRaw("Horizontal");
        //Vector3にHorizontal・Verticalを代入
        idouVec = new Vector3(0, jouge, sayuu * chara_muki);

        //ジャンプ時間の計算
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }

        //以下基本動作

        //弱攻撃（X or J）
        if (Input.GetButtonDown("X or J") && jump_stop == true && jab_attack_cooltime_permission)
        {
            Debug.Log("弱攻撃");
            otoko1_kougeki_attack = 1;
            animator.SetTrigger("Trigger_attack");
            Jab();
            otoko1_kougeki_attack = 0;
            //攻撃を押したら距離関係なくHPゲージを
            //減らす処理（当たり判定できたら移動）
            // GauMan.DecreaseEnemyHPGauge(AttackJakuTakeru);
            //すたみなへらす
            //GauMan.DecreaseStaGauge(30);
        }
        //強攻撃（A or K）
        if (Input.GetButtonDown("A or K") && jump_stop == true && kick_attack_cooltime_permission)  
        {
            Debug.Log("強攻撃");
            otoko1_kougeki_attack = 2;
            animator.SetTrigger("Trigger_attack");
            Kick();
            otoko1_kougeki_attack = 0;
        }
        //必殺技（Y or I）
        if (Input.GetButtonDown("Y or I") && jump_stop == true && kick_attack_cooltime_permission == true)
        {
            Debug.Log("必殺技");
        }
        //ガード(Right(left) Bumper or sperce)   ※ジャストガードも検討
        if (Input.GetButtonDown("Right(left) Bumper or space") && jump_stop == true)
        {
            otoko1_guard = true;
            Debug.Log("ガード");
        }
        //移動以外の入力があったときは すり抜けないようにする or 移動できないようにする
        if (Input.GetButtonDown("Right(left) Bumper or space") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetButtonDown("A or K") || Input.GetButtonDown("X or J")) 
        {
            //レイヤー変更
            gameObject.SetChildLayer(7);
            gameObject.layer = LayerMask.NameToLayer("Attack");
        }
        //ジャンプの入力があったときは遅延して横移動できないようにする
        if (jouge > 0)
        {
            idouVec = new Vector3(0, jouge, 0);
        }

        //横移動の処理
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

        //speed_originに代入
        if (Input.GetButtonDown("Horizontal"))
        {
            speed_origin = now_speed;
        }
        if (Input.GetButtonDown("Vertical"))
        {
            speed_origin = now_jumppower;
        }

        //移動処理
        transform.Translate(speed_origin * Time.deltaTime * idouVec);


        //以下アニメーション

        //最初のジャンプ区別
        if (Input.GetAxisRaw("Vertical") > 0 && first_jump == 0 && jump_stop == true)
        {
            first_jump++;
        }
        //ジャンプの処理
        //1回目&地面についてたら&ジャンプ入力がされてたら
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
        //2回目&地面についてたら&ジャンプ入力がされてたら&クールタイムが終わったら
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
        //攻撃アニメーション

        //攻撃の処理
        //最初の攻撃処理
        if (jump_stop == true && otoko1_kougeki_attack == 1 && first_attack_int == 0)
        {
            first_attack_int++;
        }
        //1回目&地面についてたら&弱(強)攻撃入力がされてたら
        if (jump_stop == true && otoko1_kougeki_attack == 1 && first_attack_int == 1)
        {
            first_attack = true;
        }
        //2回目&地面についてたら&弱(強)攻撃入力がされてたら
        if (jump_stop == true && otoko1_kougeki_attack == 1 && first_attack_int >= 2 && jab_attack_cooltime_permission == true || kick_attack_cooltime_permission == true)
        {
            first_attack = false;
        }

        //弱攻撃(ヒット時)
        if (otoko1_kougeki_attack == 1 && jump_stop && otoko1_jab_distance && Ray_player_hit && jab_attack_cooltime_permission)
        {
            otoko1_kougeki_hit = 1;
            Debug.Log("弱ヒット");
            gamedirector.Otoko1_attack();
            otoko1_kougeki_hit = 0;
        }
        //強攻撃(ヒット時)
        if (jump_stop == true && otoko1_kougeki_attack == 2 && kick_attack_cooltime_permission == true && otoko1_kick_distance == true && Ray_player_hit == true)
        {
            otoko1_kougeki_hit = 2;
            Debug.Log("強ヒット");
            otoko1_kougeki_hit = 0;
        }
        //ガード
        if (otoko1_guard == true)
        {
            //ジャストガード
            if (otoko1_guard == true && otoko1_kougeki_hidan != 0)
            {
                otoko1_just_guard = true;
                Debug.Log("ジャストガード");
                animator.SetTrigger("Trigger_Move");
                Guard();
                //後隙を減らす処理
            }
            //普通のガード
            else if (otoko1_guard == true)
            {
                otoko1_normal_guard = true;
                Debug.Log("ノーマルガード");
                animator.SetTrigger("Trigger_Move");
                Guard();
            }
            otoko1_guard = false;
        }
        //被弾アニメーション
        if (otoko1_kougeki_hidan != 0)
        {
            //レイヤー変更
            gameObject.SetChildLayer(6);
            gameObject.layer = LayerMask.NameToLayer("Hantei");
            if (otoko1_kougeki_hidan == 1)
            {
                Debug.Log("otoko1ひるみ");
                Hirumi();
            }
            else if (otoko1_kougeki_hidan == 2)
            {
                Debug.Log("otokoダウン");
                Down();
            }
        }

        //ローカル座標を基準に回転を取得
        Vector3 Local_angle = mytransform.localEulerAngles;

        //左右どちらかに移動中
        if (sayuu != 0)
        {
            //レイヤー変更
            gameObject.SetChildLayer(6);
            gameObject.layer = LayerMask.NameToLayer("Hantei");
            //アニメーション分岐
            animator.SetTrigger("Trigger_Move");
            //右移動
            if (sayuu > 0)
            {
                //アニメーション変更
                animator.SetTrigger("Trigger_walk");
                //反転処理
                chara_muki = 1;
                Local_angle.y = -90;
            }
            //左移動
            else if (sayuu < 0)
            {
                //アニメーション変更
                animator.SetTrigger("Trigger_walk");
                //反転処理
                chara_muki = -1;
                Local_angle.y = 90;
            }
        }
        //停止状態
        if (!Input.anyKey)
        {
            //変数初期化
            Invoke(nameof(Attack_Shoki), 1f);
            //Invoke(nameof(Hit_Shoki), 0.4f);
            //レイヤー初期化
            Invoke(nameof(Layer_shoki), 0.5f);
        }
        //ローカルアングルを代入
        mytransform.eulerAngles = Local_angle;
    }
    //停止状態の変数初期化
    public void Attack_Shoki()
    {
        otoko1_kougeki_hit = 0;
        otoko1_kougeki_attack = 0;
    }
    //レイヤー初期化
    void Layer_shoki()
    {
        gameObject.SetChildLayer(3);
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    //当たり判定まとめ

    //触れ続けてる間判定
    public void OnTriggerStay(Collider stay_other)
    {
        //地面についてたら
        if (stay_other.CompareTag("jimen"))
        {
            //変数にHorizontal・Verticalを代入 ※jougeのみ制限
            jump = Input.GetAxisRaw("Vertical");
            if (jump >= 0)
            {
                jouge = jump;
            }
            jump_stop = true;
        }
    }

    //弱攻撃
    public void Jab()
    {
        animator.SetTrigger("return_jab");
        attack_cooltime_jaku = 0;
    }
    //強攻撃
    public void Kick()
    {
        animator.SetTrigger("return_kick");
        attack_cooltime_kyou = 0;
    }
    //ひるみ
    public void Hirumi()
    {
        //アニメーション実行
        animator.SetTrigger("return_jaku_hirumi");
    }
    //ダウン
    public void Down()
    {
        //アニメーション実行
        animator.SetTrigger("return_down");
    }
    //ジャンプ
    public void JUMP()
    {
        animator.SetTrigger("Trigger_Jump");
    }
    //ガード
    public void Guard()
    {
        animator.SetTrigger("Trigger_guard");
    }
}
