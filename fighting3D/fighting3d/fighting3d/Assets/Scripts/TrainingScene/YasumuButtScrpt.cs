using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YasumuButtScrpt : MonoBehaviour
{
    



    public float increaseAmount = 50f;
    public TraGaugeManager traGaugeManager;

    [SerializeField] Main main;


    public void OnButtonClick()
    {
        traGaugeManager.IncreaseGauge(increaseAmount);
        main.Turn--;
        main.TurnSu.text = main.Turn.ToString();


        main.UpdateHPsippaiRitu();
        main.UpdatePowersippaiRitu();
        main.UpdateSpeedsippaiRitu();
        main.UpdateStaminasippaiRitu();
        main.UpdateClevernesssippaiRitu();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
