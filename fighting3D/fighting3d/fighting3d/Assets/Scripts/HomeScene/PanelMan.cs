using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelMan : MonoBehaviour
{
    //パネルを設定します
    [SerializeField] GameObject CharaSelectPanel;

    [SerializeField] GameObject CharaInfoPanel;

    [SerializeField] GameObject FriendBattlePanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CharaSeleCancel()   //育成するキャラクター選択画面からホーム画面に戻ります
    {
        CharaSelectPanel.SetActive(false);
    }



    public void ToCharacterSelectPanelFromHomesTraining()　　　// 育成するキャラを選びます
    {
        CharaSelectPanel.SetActive(true);

    }


    public void CharaInfo()　　　　//育成するキャラの情報を見る（スキルとか）
    {       
          CharaSelectPanel.SetActive(false);
    　　　CharaInfoPanel.SetActive(true);
    }

    public void ToCharaSelectFromCharaInfo()    //chara info panelからキャラセレクトに戻ります
    {
        CharaInfoPanel.SetActive(false);
        CharaSelectPanel.SetActive(true);
    }

    public void FriendBattlePanelSetOn()　　　　//ｆれんどばとる　がめんみる

    {
       
        FriendBattlePanel.SetActive(true);
    }
    public void FriendBattlePanelSetOff()　　　　//ｆれんどばとる　がめんみる

    {
        FriendBattlePanel.SetActive(false);
       
    }
}
