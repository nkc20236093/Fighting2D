using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dekoi : MonoBehaviour
{
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

    //xとyの移動制限
    float xleft = 3.4f, xright = -3.4f;
    float ydown = 5f, yup = 9f;

    //通常スピード
    float normal_speed = 50;
    //ダッシュスピード
    float dash_speed;
    //現在のスピードモード
    float now_speed;

    //Rayを宣言
    Ray ray;
    //レイを飛ばす距離
    public float distance = 0.001f;
    //レイが何かに当たった時の情報
    RaycastHit hit;
    //レイを発射する位置
    Vector3 rayPos;

    //移動の変数
    float sayuu;
    float jouge;

    //ジャンプパワー（統一予定）
    float jump_power = 5f;
    //2段ジャンプ禁止用
    public bool jump_stop = false; //false = 禁止
                                   //true  = 許可

    //rigidbodyを取得
    Rigidbody rigid;

    //移動（総合）スピード
    Vector3 speed_origin;

    //CharacterControllerを宣言
    public CharacterController characterController;

    //ジャンプの速度を設定
    float Jump_velocity = 5.0f;

    //着地状態を管理
    public bool jump_isGrounded = false; //最初は着地してない状態 
                                         //着地してない=false
                                         //着地してる  =true

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
        //レイを発射する位置の調整
        rayPos = transform.position + new Vector3(0, 0, 0);
        //レイを下に飛ばす
        ray = new Ray(rayPos, transform.up * -1);
        //デバッグ用のレイを発光
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        //現在の座標を取得（移動制限用）
        Vector3 Pos = transform.position;
        //移動制限
        Pos.x = Mathf.Clamp(Pos.x, xright, xleft);
        Pos.y = Mathf.Clamp(Pos.y, ydown, yup);
        transform.position = Pos;

        //着地状態か確認
        if (Physics.Raycast(ray, out hit, distance))
        {
            //接地判定を確実にするため-0.5fを代入
            Jump_velocity = -0.5f;
            Debug.Log("着地状態");
            //レイが地面にヒットしてるか確認
            if (hit.collider.CompareTag("jimen"))
            {
                rayhit = true;
            }
            else
            {
                jump_isGrounded = false;
            }
        }
        ////以下基本動作

        ////弱攻撃（X or J）
        //if (Input.GetAxisRaw("X or J") != 0)
        //{
        //    animator.SetInteger("stop", 2);
        //    Debug.Log("弱攻撃");
        //}
        ////各行動終了次第停止状態に変更
        //else
        //{
        //    //アニメーション変更
        //    animation_stop();
        //}
        ////強攻撃（A or K）
        //if (Input.GetAxisRaw("A or K") != 0)
        //{
        //    Debug.Log("強攻撃");
        //}
        ////投げ攻撃（B or L）
        //if (Input.GetAxisRaw("B or L") != 0)
        //{
        //    Debug.Log("投げ攻撃");
        //}
        ////必殺技（Y or I）
        //if (Input.GetAxisRaw("Y or I") != 0)
        //{
        //    Debug.Log("必殺技");
        //}
        ////ガード(Right(left) Bumper or sperce)   ※ジャストガードも検討
        //if (Input.GetButtonDown("Right(left) Bumper or sperce"))
        //{
        //    Debug.Log("ガード");
        //}
        ////変数にHorizontal・Verticalを代入
        //PlayerVector = new Vector3(0, jouge, sayuu * 0.15f * chara_muki);
        //sayuu = Input.GetAxisRaw("Horizontal");
        //jouge = Input.GetAxisRaw("Vertical");

        ////向き変更用
        //if (sayuu > 0)
        //{
        //    muki = false;
        //}
        //else if (sayuu < 0)
        //{
        //    muki = true;
        //}
        ////地面についてたらジャンプ力を0にする
        //if (jump_isGrounded == true || rayhit == true)
        //{
        //    jouge = 0f;
        //}
        ////横移動(スティック or 左右矢印キー)&ジャンプ(スティック or 上矢印キー(Wキー))    
        //transform.Translate(PlayerVector);

        ////以下アニメーション

        ////ワールド座標を基準に回転を取得
        //Vector3 World_angle = mytransform.eulerAngles;
        ////左右どちらかに移動中
        //if (sayuu != 0)
        //{
        //    //右移動
        //    if (muki == false)
        //    {
        //        //反転処理
        //        World_angle.y = -90;
        //        chara_muki = 1;
        //        //アニメーション変更
        //        animator.SetInteger("stop", 1);
        //    }
        //    //左移動
        //    else
        //    {
        //        //反転処理
        //        World_angle.y = 90;
        //        chara_muki = -1;
        //        //アニメーション変更
        //        animator.SetInteger("stop", 1);
        //    }
        //}
        ////停止状態
        //else
        //{
        //    //アニメーション変更
        //    Invoke(nameof(animation_stop), 1f);
        //}
        //mytransform.eulerAngles = World_angle;
    }
    //停止状態のアニメーション
    void animation_stop()
    {
        animator.SetInteger("stop", 0);
    }
    //characterControllerを利用した当たり判定
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("jimen"))
        {
            Debug.Log("jimen");
            jump_isGrounded = true;
            jump_stop = true;
        }
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit_dekoi");

        }
    }
}
