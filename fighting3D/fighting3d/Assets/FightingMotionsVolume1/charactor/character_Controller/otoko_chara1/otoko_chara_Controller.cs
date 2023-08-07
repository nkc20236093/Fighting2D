using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //xとyの移動制限
    float xleft = 3.5f, xright = -3.5f;
    float ydown = 5f, yup = 9f;

    //通常スピード
    float normal_speed = 50;
    //ダッシュスピード
    float dash_speed;
    //現在のスピードモード
    float now_speed = 10;
 
    //Rayを宣言
    Ray ray;
    //レイを飛ばす距離
    public float distance = 0.5f;
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


    //移動（総合）スピード
    Vector3 speed_origin;

    //CharacterControllerを宣言
    public CharacterController characterController;

    //左右用の移動方向変数
    Vector3 sayuu_houkou = Vector3.zero;

    //ジャンプの速度を設定
    float Jump_velocity = 5.0f;

    //着地状態を管理
    public bool jump_isGrounded = false; //最初は着地してない状態 
                                         //着地してない=false
                                         //着地してる  =true

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

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //常に重力をかける
        //characterController.Move(new Vector3(0, Physics.gravity.y, 0));

        //レイを発射する位置の調整
        rayPos = transform.position + new Vector3(0, 0.25f, 0);
        //レイを下に飛ばす
        ray = new Ray(rayPos, transform.up * -1);
        //デバッグ用のレイを発光
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        ////ジャンプしてない間、重力をかける
        Jump_velocity += Physics.gravity.y * Time.deltaTime;
        Debug.Log("重力");

        //現在の座標を取得
        Vector3 Pos = transform.position;

        //着地状態か確認
        if (Physics.Raycast(ray, out hit, distance))
        {
            //接地判定を確実にするため-0.5fを代入
            Jump_velocity = -0.5f;
            Debug.Log("着地状態");
            //レイが地面にヒットしてるか確認
            if (hit.collider.tag == "jimen")
            {
                jump_stop = true;
                jump_isGrounded = true;
                Debug.Log("jimen");
                speed_origin = Vector3.zero;
            }
            else
            {
                jump_isGrounded = false;
                Debug.Log("hazure");
            }
        }

        //移動制限
        Pos.x = Mathf.Clamp(Pos.x, xright,xleft);
        Pos.y = Mathf.Clamp(Pos.y, yup, ydown);
        transform.position = Pos;

        //変数にHorizontal・Verticalを代入
        var idou = new Vector3(sayuu, jouge, 0);
        sayuu = Input.GetAxisRaw("Horizontal");
        jouge = Input.GetAxisRaw("Vertical");
        //以下基本動作

        //弱攻撃（X or J）
        if (Input.GetAxisRaw("X or J") != 0)
        {

        }
        //強攻撃（A or K）
        if (Input.GetAxisRaw("A or K") != 0)
        {

        }
        //投げ攻撃（B or L）
        if (Input.GetAxisRaw("B or L") != 0)
        {

        }
        //必殺技（Y or I）
        if (Input.GetAxisRaw("Y or I") != 0)
        {

        }
        //横移動(スティック or 左右矢印キー)
        if (sayuu != 0)
        {
            Debug.Log("sayuu");
            speed_origin.x = idou.normalized.x * 2;
            speed_origin.y = idou.normalized.y * 2;
        }

        //ジャンプ(スティック or 上矢印キー(Wキー)

        //地面についてたら&ジャンプ(スティック or 上矢印キー(Wキー))が押されてるか確認&2段ジャンプ禁止
        if (jouge > 0 && jump_stop && jump_isGrounded == true) 
        {
            Debug.Log("ジャンプ");
            speed_origin.y = jump_power;
            //地面から離れるので着地状態を書き換え
            jump_isGrounded = false;
            //地面から離れるのでjump_stopをfalseに切り替え
            jump_stop = false;
        }

        speed_origin.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(new Vector3((speed_origin.x*-1), speed_origin.y, 0) * Time.deltaTime);
    }
}
