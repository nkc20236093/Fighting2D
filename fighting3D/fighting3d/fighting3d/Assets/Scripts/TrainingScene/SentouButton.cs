using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SentouButton : MonoBehaviour
{
    [SerializeField] Main main;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
       
        main.Turn--;
        main.TurnSu.text = main.Turn.ToString();


       
    }





}
