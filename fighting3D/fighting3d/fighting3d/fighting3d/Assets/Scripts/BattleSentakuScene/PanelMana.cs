using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PanelMana : MonoBehaviour
{
    //ÉpÉlÉãÇê›íËÇµÇ‹Ç∑
    [SerializeField] GameObject StageOnePanel;

    [SerializeField] GameObject StageTwoPanel;

    [SerializeField] GameObject StageThreePanel;

    [SerializeField] GameObject StageFourPanel;

    [SerializeField] GameObject StageFivePanel;







    public void OneTwo()  
    {
        StageOnePanel.SetActive(false);
        StageTwoPanel.SetActive(true);
    
    }
    public void TwoThree()
    {
        StageTwoPanel.SetActive(false);
        StageThreePanel.SetActive(true);

    }
    public void ThreeFour()
    {
        StageThreePanel.SetActive(false);
        StageFourPanel.SetActive(true);

    }
    public void FourFive()
    {
        StageFourPanel.SetActive(false);
        StageFivePanel.SetActive(true);

    }




    public void TwoOne()
    {
        StageTwoPanel.SetActive(false);
        StageOnePanel.SetActive(true);
     

    }
    public void ThreeTwo()
    {
        StageTwoPanel.SetActive(true);
        StageThreePanel.SetActive(false);

    }
    public void FourThree()
    {
        StageThreePanel.SetActive(true);
        StageFourPanel.SetActive(false);

    }
    public void FiveFour()
    {
        StageFourPanel.SetActive(true);
        StageFivePanel.SetActive(false);

    }






}
