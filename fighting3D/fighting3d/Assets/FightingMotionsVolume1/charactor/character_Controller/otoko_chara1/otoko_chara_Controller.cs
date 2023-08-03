using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //移動の変数
    float sayuu;
    float jouge;

    //ジャンプパワー（統一予定）
    ForceMode jump = (ForceMode)1000;


    //左右用の移動方向変数
    Vector3 sayuu_houkou = Vector3.zero;

    //RigidBodyを変数に保存
    Rigidbody rigidbody;

    //ジャンプの速度を設定
    const float _velocity = 5.0f;

    //着地状態を管理
    public bool _isGrounded;  //着地してない=false
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
        this.rigidbody = GetComponent < Rigidbody > ();
        //最初は着地してない状態
        //_isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {

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

        //着地状態か確認
        if (_isGrounded == true)
        {
            Debug.Log("着地状態");
            //ジャンプ(スティック or 上矢印キー(Wキー))が押されてるか確認
            if (jouge > 0)
            {
                Debug.Log("ジャンプ");
                //ジャンプの方向を上向きのベクトルに設定
                Vector3 jump_vector = Vector3.up;

                //ジャンプの速度を計算
                Vector3 jump_velocity = jump_vector * _velocity;

                //上向きの速度を設定
                rigidbody.velocity = jump_velocity;

                rigidbody.AddForce(rigidbody.velocity,jump);

                //地面から離れるので着地状態を書き換え
                _isGrounded = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.tag == "jimen")
            {
                Debug.Log("着地成功");
                _isGrounded = true;
            }
        }
    }

    

}
