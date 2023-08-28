using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaInfoUber : MonoBehaviour
{
   // [SerializeField] Main main;

    public void Chara1StatusUberMethod()
    {
        Main.HP = 101;                                           //選手のそれぞれのステータスー１０を書く
        Main.Power = 101;
        Main.Speed = 101;
        Main.Stamina = 101;
        Main.Cleverness = 101;
        SceneManager.LoadScene("TrainingScene");
        
    }
    public void Chara2StatusUberMethod()
    {
        Main.HP = 222;
        Main.Power = 222;
        Main.Speed = 222;
        Main.Stamina = 222;
        Main.Cleverness = 222;
        SceneManager.LoadScene("TrainingScene");
    }
    public void Chara3StatusUberMethod()
    {
        Main.HP = 333;
        Main.Power = 333;
        Main.Speed = 333;
        Main.Stamina = 333;
        Main.Cleverness = 333;
        SceneManager.LoadScene("TrainingScene");
    }
    public void Chara4StatusUberMethod()
    {
        Main.HP = 444;
        Main.Power = 444;
        Main.Speed = 444;
        Main.Stamina = 444;
        Main.Cleverness = 444;
        SceneManager.LoadScene("TrainingScene");
    }
    public void Chara5StatusUberMethod()
    {
        Main.HP = 555;
        Main.Power = 555;
        Main.Speed = 555;
        Main.Stamina = 555;
        Main.Cleverness = 555;
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
