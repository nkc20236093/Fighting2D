using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaInfoUber : MonoBehaviour
{
    // [SerializeField] Main main;
 /*   hp 4    
power 0.25
speed 0.05f    をそれぞれ足した数が本当のステータス
stamina 3f
 */
    public void Chara1StatusUberMethod()
    {
        Main.HP = 126f;                                           //選手のそれぞれのステータスー１０を書く
        Main.Power = 4.25f;
        Main.Speed = 0.25f;
        Main.Stamina = 67;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
        
    }
    public void Chara2StatusUberMethod()
    {
        Main.HP = 96f;
        Main.Power = 2.75f;
        Main.Speed = 0.45f;
        Main.Stamina = 97f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }
    public void Chara3StatusUberMethod()
    {
        Main.HP = 71f;
        Main.Power = 1.75f;
        Main.Speed = 0.95f;
        Main.Stamina = 147f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }
    public void Chara4StatusUberMethod()
    {
        Main.HP = 96f;
        Main.Power = 0.75f;
        Main.Speed = 0.25f;
        Main.Stamina = 87f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }
    public void Chara5StatusUberMethod()
    {
        Main.HP = 71f;
        Main.Power = 1.75f;
        Main.Speed = 0.55f;
        Main.Stamina = 97f;
        Main.Cleverness = 90f;
        SceneManager.LoadScene("TrainingScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
