using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko_chara_Controller : MonoBehaviour
{
    //eúXe[^X

    //HP
    int hp = 10;
    //UÍ
    int attack = 10;
    //f³
    int speed = 10;
    //X^~i
    int stamina = 10;
    //«³
    int cleverness = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Èºî{®ì

        //ãUiX or Jj
        if (Input.GetAxisRaw("X or J") != 0)
        {

        }
        //­UiA or Kj
        if (Input.GetAxisRaw("A or K") != 0)
        {

        }
        //°UiB or Lj
        if (Input.GetAxisRaw("B or L") != 0)
        {

        }
        //KEZiY or Ij
        if (Input.GetAxisRaw("Y or I") != 0)
        {

        }
        //¡Ú®(XeBbN or îóL[)
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

        }
        //cÚ®(XeBbN or îóL[)
        if (Input.GetAxisRaw("Vertical") != 0)
        {

        }
    }
}
