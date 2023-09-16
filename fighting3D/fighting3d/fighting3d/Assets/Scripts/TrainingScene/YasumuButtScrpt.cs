using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YasumuButtScrpt : MonoBehaviour
{
    public AllTurn AllTurn;

    public float increaseAmount = 50f;
    public TraGaugeManager traGaugeManager;

    [SerializeField] Main main;


    public void OnButtonClick()
    {
        traGaugeManager.IncreaseGauge(increaseAmount);
        AllTurn.TurnDecrease();
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
