using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Otoko_chara_hantei : MonoBehaviour
{
    //テスト用のデコイ（ゲームオブジェクト）を取得
    dekoi dekoi;

    public UnityEvent Onhit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Onhit.Invoke();
        }
    }
}
