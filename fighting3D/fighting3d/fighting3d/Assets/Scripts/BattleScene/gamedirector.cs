using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
    public Otoko_chara_Controller otoko_Chara_Controller;
    public dekoi Dekoi;

    //UŒ‚”í’e•Ï”
    public int hidan;//ƒfƒRƒC—p
    public int hidan_otoko1;//’jƒLƒƒƒ‰1

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //’jƒLƒƒƒ‰1‚©‚çUŒ‚
        if (otoko_Chara_Controller.otoko1_kougeki_attack != 0)
        {
            Debug.Log("’jƒLƒƒƒ‰1UŒ‚");
            Otoko1_attack();
        }
        //dekoi‚©‚çUŒ‚
        if (Dekoi.dekoi_kougeki_attack != 0)
        {
            Debug.Log("ƒfƒRƒCUŒ‚");
            Dekoi_attack();
        }
    }
    public void Otoko1_attack()
    {
        if (otoko_Chara_Controller.attack_cooltime_jaku >= 0.5f || otoko_Chara_Controller.attack_cooltime_kyou >= 1) 
        {
            hidan = otoko_Chara_Controller.otoko1_kougeki_attack;
            Debug.Log(hidan + "a");
        }
    }
    public void Dekoi_attack()
    {
        if (Dekoi.dekoi_kougeki_cooltime_jaku >= 0.5f || Dekoi.dekoi_kougeki_cooltime_kyou >= 1) 
        {
            Debug.Log(hidan_otoko1 + "c");
            hidan_otoko1 = Dekoi.dekoi_kougeki_attack;
        }
    }
}
