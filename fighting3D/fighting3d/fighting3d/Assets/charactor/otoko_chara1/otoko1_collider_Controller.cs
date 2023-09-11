using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otoko1_collider_Controller : MonoBehaviour
{
    public otoko1_collider otoko1_Collider;
    // Start is called before the first frame update
    void Start()
    {
        //ç≈èâÇÕÉIÉt
        otoko1_Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jab_on()
    {
        //otoko1_Collider.transform.position = new Vector3();
        otoko1_Collider.enabled = true;
    }
    public void Jab_Off()
    {
        otoko1_Collider.enabled = false;
    }
}
