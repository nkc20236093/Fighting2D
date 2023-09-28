using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dekoi : MonoBehaviour
{
    //Rayがオブジェクトに当たった場合の距離(変動型)
    float Ray_length_dekoi;
    //レイを取得
    Ray otoko1_ray_dekoi;
    //レイの原点
    Vector3 otoko1_ray_Origin_dekoi;
    //レイの方向
    Vector3 otoko1_ray_Vector3_dekoi;
    //レイキャストヒットを取得
    RaycastHit hit_dekoi;
    //レイがプレイヤーに当たったかどうか
    public bool Ray_player_hit_dekoi;
    //レイがトリガー付きコライダーに判定を出すか
    QueryTriggerInteraction queryTrigger_dekoi;
    //Ray用レイヤー変数
    public int dekoi_ray_layer;

    //アニメーターコンポーネントを取得
    Animator animator;
    //Rigidbodyを取得
    public new Rigidbody rigidbody;

    //ゲームディレクターを取得
    gamedirector gamedirector;
    //プレイヤーを取得
    Otoko_chara_Controller otoko;
    //現在の時間
    public float Real_Time;

    //攻撃を与えた・くらった状態を管理する用の変数
    public int dekoi_kougeki_attack;
    public int dekoi_kougeki_hidan;
    public int dekoi_kougeki_hit;
    //攻撃距離判定用bool
    public bool jab__distance;
    public bool kick__distance;
    //攻撃距離判定用(ゲームディレクター)
    public bool jab_dekoi_distance;
    public bool kick_dekoi_distance;
    //攻撃クールタイム用変数
    public float dekoi_kougeki_cooltime_jaku;
    public float dekoi_kougeki_cooltime_kyou;
    //攻撃クールタイム用bool
    public bool jab_dekoi_cooltime;
    public bool kick_dekoi_cooltime;

    //ゲームディレクター用攻撃許bool
    public bool dekoi_cooltime_permisson;
    public bool dekoi_attack_permission;
    //trur = 許可
    //false= 不許可

    //Transformコンポーネントを取得
    Transform mytransform;

    //キャラ向き変更用変数
    public float chara_muki_dekoi;

    //通常スピード
    static float normal_speed = 1f;
    //ダッシュスピード
    static float dash_speed = 1.5f;
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

    // Start is called before the first frame update
    void Start()
    {
        otoko = GameObject.Find("企画_男キャラ１").GetComponent<Otoko_chara_Controller>();
        gamedirector = GameObject.Find("GameDirector").GetComponent<gamedirector>();

        //最初にスピードモードに通常モードを代入
        speed_mode = false;
        //最初に現在のジャンプモードに通常モードを代入
        jump_mode = false;
        //最初だけ長さを指定
        Ray_length_dekoi = gamedirector.Distance;

        //自分の回転度を取得
        mytransform = this.transform;
        animator = GetComponent<Animator>();

        //rigidにコンポーネントを代入
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dekoi_kougeki_hidan = gamedirector.hidan;

        //弱攻撃用距離
        if (gamedirector.Distance <= 0.6790044f && Input.GetButtonDown("X or J") && Ray_player_hit_dekoi == true)
        {
            jab__distance = true;
        }
        //強攻撃用距離
        if (gamedirector.Distance <= 1.717879f && Input.GetButtonDown("A or K") && Ray_player_hit_dekoi == true)
        {
            kick__distance = true;
        }
        //範囲外に出た用
        //弱攻撃
        if (gamedirector.Distance < 0.6790044f)
        {
            jab__distance = false;
        }
        //強攻撃
        if (gamedirector.Distance <= 1.717879f)
        {
            kick__distance = false;
        }

        //座標を代入
        otoko1_ray_Origin_dekoi = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z);
        //方向を代入
        otoko1_ray_Vector3_dekoi = new Vector3(-chara_muki_dekoi, 0, 0);
        //レイを生成
        otoko1_ray_dekoi = new Ray(otoko1_ray_Origin_dekoi, otoko1_ray_Vector3_dekoi);
        //デバッグ用レイ
        Debug.DrawRay(otoko1_ray_Origin_dekoi, otoko1_ray_dekoi.direction, Color.red, 60f, false);
        //当たり判定用レイ
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

        //移動制限
        Vector3 Pos = transform.position;
        //X座標
        Pos.x = Mathf.Clamp(Pos.x, -4, 4);
        //Y座標
        Pos.y = Mathf.Clamp(Pos.y, 4.8f, 6.62f);
        //範囲を越えたらテレポート
        transform.position = Pos;

        //入力マネージャーを使用した移動方法 ※Verticalは移動
        sayuu = Input.GetAxisRaw("H or F");
        //Vector3にHorizontal・Verticalを代入
        Vector3 idouVec = new Vector3(0, jouge , sayuu * chara_muki_dekoi);

        //ジャンプ時間の計算
        if (jump_stop == true && Real_Time < JumpCoolTime)
        {
            Real_Time += Time.deltaTime;
        }
        //弱攻撃クールタイム計算
        if (dekoi_kougeki_cooltime_jaku < 1.5f)
        {
            dekoi_kougeki_cooltime_jaku += Time.deltaTime;
        }
        //強攻撃クールタイム計算
        if (dekoi_kougeki_cooltime_kyou < 2f)
        {
            dekoi_kougeki_cooltime_kyou += Time.deltaTime;
        }
        //攻撃クールタイム
        //弱攻撃
        if (dekoi_kougeki_cooltime_jaku >= 1.5f)
        {
            jab_dekoi_cooltime = true;
        }
        //強攻撃
        if (dekoi_kougeki_cooltime_kyou >= 2f)
        {
            kick_dekoi_cooltime = true;
        }
        if (dekoi_kougeki_cooltime_jaku >= 1.5f || dekoi_kougeki_cooltime_kyou >= 2f)
        {
            dekoi_cooltime_permisson = true;
        }
        //距離判定(ゲームディレクター用)
        if (jab_dekoi_distance == true || kick_dekoi_distance == true)
        {
            dekoi_attack_permission = true;
        }

        //以下基本動作

        //弱攻撃（X or J）
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("弱攻撃");
            dekoi_kougeki_attack = 1;
            dekoi_kougeki_cooltime_jaku = 0;
            Invoke(nameof(Dekoi_Attack_Shoki), 1 / 60f);
        }
        //強攻撃（A or K）
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("強攻撃");
            dekoi_kougeki_attack = 2;
            dekoi_kougeki_cooltime_kyou = 0;
            Invoke(nameof(Dekoi_Attack_Shoki), 1 / 60f);
        }
        //必殺技（Y or I）
        //if (Input.GetAxisRaw("Y or I") != 0)
        //{
        //    Debug.Log("必殺技");
        //}
        ////ガード(Right(left) Bumper or sperce)   ※ジャストガードも検討
        //if (Input.GetButtonDown("Right(left) Bumper or space"))
        //{
        //    Debug.Log("ガード");
        //}

        //移動以外の入力があったときは すり抜けないようにする or 移動できないようにする
        if (Input.GetButtonDown("Right(left) Bumper or space") || Input.GetButtonDown("Y or I") || Input.GetButtonDown("B or L") || Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("X or J") || Input.GetKeyDown(KeyCode.Return))
        {
            dekoi_ray_layer = 6;
            gameObject.SetDekoiChild(6);
            gameObject.layer = LayerMask.NameToLayer("Attack");
            idouVec = Vector3.zero;
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
            speed_origin = now_speed * 5;
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
        //移動処理
        transform.Translate(speed_origin * Time.deltaTime * idouVec);

        //以下アニメーション

        //ワールド座標を基準に回転を取得
        Vector3 World_angle = mytransform.localEulerAngles;
        //左右どちらかに移動中
        if (sayuu != 0)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            //右移動
            if (sayuu > 0)
            {
                //反転処理
                chara_muki_dekoi = 1;
                World_angle.y = -90;
                //アニメーション変更
                Dekoi_Move();
            }
            //左移動
            else if (sayuu < 0)
            {
                //反転処理
                chara_muki_dekoi = -1;
                World_angle.y = 90;
                //アニメーション変更
                Dekoi_Move();
            }
        }
        //各攻撃用アニメーション
        //弱攻撃(ヒット時)
        if (jump_stop == true && dekoi_kougeki_attack == 1 && dekoi_attack_permission == true && jab_dekoi_cooltime == true)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            dekoi_kougeki_hit = 1;
            animator.SetTrigger("Trigger_dekoi_attack");
            gamedirector.Dekoi_attack();
            dekoi_kougeki_hit = 0;
        }
        //強攻撃(ヒット時)
        if (jump_stop == true && dekoi_kougeki_attack == 2 && dekoi_attack_permission == true && kick_dekoi_cooltime == true)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            dekoi_kougeki_hit = 2;
            animator.SetTrigger("Trigger_dekoi_attack");
            gamedirector.Dekoi_attack();
            dekoi_kougeki_hit = 0;
        }
        //被弾モーション
        if (dekoi_kougeki_hidan != 0)
        {
            animator.SetTrigger("Trigger_dekoi_Move");
            if (dekoi_kougeki_hidan == 1)
            {
                Debug.Log("dekoiひるみ");
                Dekoi_hirumi();
            }
            if (dekoi_kougeki_hidan == 2)
            {
                Debug.Log("dekoiダウン");
                Dekoi_down();
            }
        }
        //停止状態
        if (!Input.anyKeyDown)
        {
            //変数初期化
            Invoke(nameof(Dekoi_Attack_Shoki), 1 / 60f);
            //レイヤー初期
            Invoke(nameof(Layer_Shoki), 1 / 60f);
        }
        mytransform.eulerAngles = World_angle;
    }
    //特定の変数を初期化
    public void Dekoi_Attack_Shoki()
    {
        dekoi_kougeki_attack = 0;
        dekoi_kougeki_hit = 0;
    }
    //レイヤー初期化
    public void Layer_Shoki()
    {
        dekoi_ray_layer = 3;
        gameObject.layer = LayerMask.NameToLayer("Player");
        gameObject.SetDekoiChild(3);
    }
    //当たり判定まとめ

    //触れ続けてる間判定
    public void OnTriggerStay(Collider stay_other)
    {
        //地面についてたら
        if (stay_other.CompareTag("jimen"))
        {
            //変数にHorizontal・Verticalを代入 ※jougeのみ制限
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
    //攻撃・被弾まとめ
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