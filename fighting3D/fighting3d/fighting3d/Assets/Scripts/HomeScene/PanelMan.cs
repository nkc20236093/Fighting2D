using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelMan : MonoBehaviour
{
    //�p�l����ݒ肵�܂�
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



    public void CharaSeleCancel()   //�琬����L�����N�^�[�I����ʂ���z�[����ʂɖ߂�܂�
    {
        CharaSelectPanel.SetActive(false);
    }



    public void ToCharacterSelectPanelFromHomesTraining()�@�@�@// �琬����L������I�т܂�
    {
        CharaSelectPanel.SetActive(true);

    }


    public void CharaInfo()�@�@�@�@//�琬����L�����̏�������i�X�L���Ƃ��j
    {       
          CharaSelectPanel.SetActive(false);
    �@�@�@CharaInfoPanel.SetActive(true);
    }

    public void ToCharaSelectFromCharaInfo()    //chara info panel����L�����Z���N�g�ɖ߂�܂�
    {
        CharaInfoPanel.SetActive(false);
        CharaSelectPanel.SetActive(true);
    }

    public void FriendBattlePanelSetOn()�@�@�@�@//�����ǂ΂Ƃ�@���߂�݂�

    {
       
        FriendBattlePanel.SetActive(true);
    }
    public void FriendBattlePanelSetOff()�@�@�@�@//�����ǂ΂Ƃ�@���߂�݂�

    {
        FriendBattlePanel.SetActive(false);
       
    }
}
