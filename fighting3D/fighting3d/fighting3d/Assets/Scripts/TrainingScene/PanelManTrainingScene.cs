using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManTrainingScene : MonoBehaviour
{
    //パネルを設定します
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject CharaInfoPanel;
    [SerializeField] GameObject TaikaiInfoPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingPanelOn()   //設定画面を表す
    {
        SettingPanel.SetActive(true);
    }
    public void SettingPanelOff()   //設定画面を消す
    {
        SettingPanel.SetActive(false);
    }
    public void CharaInfoPanelOn()   //選手情報画面を表す
    {
        CharaInfoPanel.SetActive(true);
    }
    public void CharaInfoPanelOff()   //選手情報画面を消す
    {
        CharaInfoPanel.SetActive(false);
    }
    public void TaikaiInfoPanelOn()   //大会情報画面を表す
    {
        TaikaiInfoPanel.SetActive(true);
    }
    public void TaikaiInfoPanelOff()   //大会情報画面を消す
    {
        TaikaiInfoPanel.SetActive(false);
    }

}
