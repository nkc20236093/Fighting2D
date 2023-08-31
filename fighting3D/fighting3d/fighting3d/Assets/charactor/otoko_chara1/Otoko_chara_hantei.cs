using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_hantei : MonoBehaviour
{
    //テスト用のデコイ（ゲームオブジェクト）を取得
    dekoi dekoi;
    //親オブジェクトのスクリプトを取得
    Otoko_chara_Controller oyascript;
    // Start is called before the first frame update
    void Start()
    {
        dekoi = GameObject.Find("dekoi").GetComponent<dekoi>();
        oyascript = GameObject.Find("企画_男キャラ１").GetComponent<Otoko_chara_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oyascript.Attack_and_hidan();
        }
    }
}
