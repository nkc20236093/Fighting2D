using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko1_tenmetu_body : MonoBehaviour
{
    Otoko_chara_Controller otoko_Chara_Controller;
    //skinned mesh Renderer๐ๆพ
    public SkinnedMeshRenderer skinnedMeshRenderer_body;
    public void Body_tenmetu()
    {
        Debug.Log("๐1_body");
        if (otoko_Chara_Controller.otoko1_kougeki_hidan != 0)
        {
            Debug.Log("๐2_body");
            if (otoko_Chara_Controller.otoko1_kougeki_hidan == 1)
            {
                Debug.Log("๐3_body");
                for (int i = 0; i < otoko_Chara_Controller.tenmetu_count_hirumi; i++)
                {
                    skinnedMeshRenderer_body.enabled = false;
                    skinnedMeshRenderer_body.enabled = true;
                }
            }
            else if (otoko_Chara_Controller.otoko1_kougeki_hidan == 2)
            {
                for (int i = 0; i < otoko_Chara_Controller.tenmetu_count_down; i++)
                {
                    skinnedMeshRenderer_body.enabled = false;
                    skinnedMeshRenderer_body.enabled = true;
                }
            }
            skinnedMeshRenderer_body.enabled = true;
        }
    }
}
