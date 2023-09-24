using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManTrainingScene : MonoBehaviour
{
    //�p�l����ݒ肵�܂�
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

    public void SettingPanelOn()   //�ݒ��ʂ�\��
    {
        SettingPanel.SetActive(true);
    }
    public void SettingPanelOff()   //�ݒ��ʂ�����
    {
        SettingPanel.SetActive(false);
    }
    public void CharaInfoPanelOn()   //�I�����ʂ�\��
    {
        CharaInfoPanel.SetActive(true);
    }
    public void CharaInfoPanelOff()   //�I�����ʂ�����
    {
        CharaInfoPanel.SetActive(false);
    }
    public void TaikaiInfoPanelOn()   //������ʂ�\��
    {
        TaikaiInfoPanel.SetActive(true);
    }
    public void TaikaiInfoPanelOff()   //������ʂ�����
    {
        TaikaiInfoPanel.SetActive(false);
    }

}
