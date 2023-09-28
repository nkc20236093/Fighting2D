using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko1_tenmetu_face : MonoBehaviour
{
    Otoko_chara_Controller otoko_Chara_Controller;
    public SkinnedMeshRenderer SkinnedMeshRenderer_face;
    public void face_tenmetu()
    {
        if (otoko_Chara_Controller.otoko1_kougeki_hidan != 0)
        {
            if (otoko_Chara_Controller.otoko1_kougeki_hidan == 1)
            {
                for (int i = 0; i < otoko_Chara_Controller.tenmetu_count_hirumi; i++)
                {
                    SkinnedMeshRenderer_face.enabled = false;
                    SkinnedMeshRenderer_face.enabled = true;
                }
            }
            else if (otoko_Chara_Controller.otoko1_kougeki_hidan == 2)
            {
                SkinnedMeshRenderer_face.enabled = false;
                SkinnedMeshRenderer_face.enabled = true;
            }
            SkinnedMeshRenderer_face.enabled = true;
        }
    }
}
