using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko1_tenmetu_hair : MonoBehaviour
{
    Otoko_chara_Controller otoko_Chara_Controller;
    SkinnedMeshRenderer SkinnedMeshRenderer_hair;
    public void tenmetu_hair()
    {
        if (otoko_Chara_Controller.otoko1_kougeki_hidan != 0)
        {
            if(otoko_Chara_Controller.otoko1_kougeki_hidan == 1)
            {
                for (int i = 0; i < otoko_Chara_Controller.tenmetu_count_down; i++)
                {
                    SkinnedMeshRenderer_hair.enabled = false;
                    SkinnedMeshRenderer_hair.enabled = true;
                }
            }
            else if (otoko_Chara_Controller.otoko1_kougeki_hidan == 2)
            {
                for (int i = 0; i < otoko_Chara_Controller.tenmetu_count_down; i++)
                {
                    SkinnedMeshRenderer_hair.enabled = false;
                    SkinnedMeshRenderer_hair.enabled = true;
                }
            }
        }
        SkinnedMeshRenderer_hair.enabled = true;
    }
}
