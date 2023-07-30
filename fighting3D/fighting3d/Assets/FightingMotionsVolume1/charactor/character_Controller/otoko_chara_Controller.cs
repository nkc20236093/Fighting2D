using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //RigidBodyを変数に保存
    Rigidbody rigidbody;

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
    }

    // Update is called once per frame
    void Update()
    {

        //変数にHorizontal・Verticalを代入
        float sayuu = Input.GetAxisRaw("Horizontal");
        float jouge = Input.GetAxisRaw("Vertical");
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

        //ジャンプ(スティック or 上矢印キー)
        if (jouge != 0)
        {
            this.rigidbody.AddForce(transform.up * jouge);
        }
    }
}
