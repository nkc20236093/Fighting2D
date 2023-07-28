using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        //横移動(スティック or 矢印キー)
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

        }
        //縦移動(スティック or 矢印キー)
        if (Input.GetAxisRaw("Vertical") != 0)
        {

        }
    }
}
