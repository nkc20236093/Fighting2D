using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //Rayを宣言
    Ray ray;
    //レイを飛ばす距離
    float distance = 10f;
    //レイが何かに当たった時の情報
    RaycastHit hit;
    //レイを発射する位置
    Vector3 rayPos;

    //移動の変数
    float sayuu;
    float jouge;

    //ジャンプパワー（統一予定）
    float jump_power = 15f;

    //CharacterControllerを宣言
    public CharacterController characterController;

    //左右用の移動方向変数
    Vector3 sayuu_houkou = Vector3.zero;

    //ジャンプの速度を設定
    float Jump_velocity = 5.0f;

    //着地状態を管理
    public bool jump_isGrounded;  //着地してない=false
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
        Application.targetFrameRate = 60;
        //最初は着地してない状態
        jump_isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //レイを発射する位置の調整
        rayPos = transform.position + new Vector3(0, 0.5f, 0);
        //レイを下に飛ばす
        ray = new Ray(rayPos, transform.up * -1);
        //デバッグ用のレイを発光
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        //ジャンプしてない間、重力をかける
        Jump_velocity += Physics.gravity.y * Time.deltaTime;
        Debug.Log("重力");

        //着地状態か確認
        if (Physics.Raycast(ray, out hit, distance))
        {
            //接地判定を確実にするため-0.5fを代入
            Jump_velocity = -0.5f;
            Debug.Log("着地状態");
            //レイが地面にヒットしてるか確認
            if (hit.collider.tag == "jimen")
            {
                jump_isGrounded = true;
                Debug.Log("jimen");
            }
            else
            {
                jump_isGrounded = false;
                Debug.Log("hazure");
            }
        }

        //変数にHorizontal・Verticalを代入
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

        }

        //ジャンプ(スティック or 上矢印キー(Wキー))

        //地面についてたら
        if (jump_isGrounded == true)
        {
            //ジャンプ(スティック or 上矢印キー(Wキー))が押されてるか確認
            if (jouge > 0)
            {
                Debug.Log("ジャンプ");
                //地面から離れるので着地状態を書き換え
                jump_isGrounded = false;
                //Y軸の速度を代入
                Jump_velocity = jump_power;

                //ジャンプの方向を上向きのベクトルに設定
                //Vector3 jump_vector = Vector3.up;

                //ジャンプの速度を計算
                //Vector3 jump_velocity = jump_vector * Jump_velocity;

                //上向きの速度を設定
                //rigidbody.velocity = jump_velocity;

                //rigidbody.AddForce(rigidbody.velocity, jump_power);

            }
            characterController.Move(new Vector3(0, Jump_velocity, 0) * Time.deltaTime);
        }
        
    }
}
