using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class dekoi_Layer_DirectorExtensionsLayer_DirectorExtensions
{
    public static void SetDekoiChild(this GameObject DekoiChild, int Dekoi_Controller_Child)
    {
        DekoiChild.layer = Dekoi_Controller_Child;
        foreach (Transform t in DekoiChild.transform)
        {
            SetDekoiChild(t.gameObject, Dekoi_Controller_Child);
        }
    }
}
