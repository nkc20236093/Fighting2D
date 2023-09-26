using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToStageSelectFromTraining2()
    {
        GauMan.maxHPGauge = Main.HP ;

        GauMan.maxStaGauge = Main.Stamina;


        Otoko_chara_Controller.AttackJakuTakeru = Main.Power;


        Otoko_chara_Controller.normal_speed = Main.Speed;






        SceneManager.LoadScene("BattleSentaku");


    }



}
