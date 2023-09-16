using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTurn : MonoBehaviour
{
    int TurnSu = 100;
    public Text AllTurnText;
    // Start is called before the first frame update
    void Start()
    {
        //  allturn = GetComponent<Text>();
       //   int TurnSu = 100;


        AllTurnText.text = ("育成終了まで" + TurnSu.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void TurnDecrease()
    {
        TurnSu--;
        AllTurnText.text = ("育成終了まで" + TurnSu.ToString() + "ターン");

    }





}
