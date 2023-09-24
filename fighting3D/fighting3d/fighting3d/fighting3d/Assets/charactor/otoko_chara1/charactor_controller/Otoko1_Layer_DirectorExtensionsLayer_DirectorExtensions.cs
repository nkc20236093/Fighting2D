using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Otoko1_Layer_DirectorExtensionsLayer_DirectorExtensions
{
    public static void SetChildLayer(this GameObject Child, int Controller_layer)
    {
        Child.layer = Controller_layer;
        foreach(Transform n in Child.transform)
        {
            SetChildLayer(n.gameObject, Controller_layer);
        }
    }
}
