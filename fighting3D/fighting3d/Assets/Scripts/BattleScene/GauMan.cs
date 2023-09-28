using System.Collections;
using System.Collections.Generic;
using UniGLTF;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GauMan : MonoBehaviour
{


    [SerializeField] private GameObject WinAudioMan;

    
    AudioSource battleAudio;


    AudioSource WinAudio;






    public float JakuDamage;
    public  float KyouDamage;
    public float JakuSta;
    public  float KyouSta;







    [SerializeField] GameObject MakePanel;


    [SerializeField] GameObject KatiPanel;








    public float StaSpan;   //繰り返す間隔
    private float StaSpanTime = 0;   //経過時間








    public Slider HPGaugeSlider;
    public Slider EnemyHPGaugeSlider;
    public Slider StaGaugeSlider;
    public Slider EnemyStaGaugeSlider;
   


    public static float maxHPGauge = 100f;
    public static float currentHPGauge;

    public static float maxEnemyHPGauge = 100f;
    public static float currentEnemyHPGauge;

    public static float maxStaGauge = 100f;
    public static float currentStaGauge;

    public static float maxEnemyStaGauge = 100f;
    public static float currentEnemyStaGauge;

    


    // Start is called before the first frame update
    void Start()
    {



        currentHPGauge = maxHPGauge;

        currentEnemyHPGauge = maxEnemyHPGauge;

        currentStaGauge = maxStaGauge;

        currentEnemyStaGauge = maxEnemyStaGauge;

  


    



    }

    public void UpdateGaugeUI()
    {
        HPGaugeSlider.value = currentHPGauge / maxHPGauge;

        EnemyHPGaugeSlider.value =
            currentEnemyHPGauge / maxEnemyHPGauge;

        StaGaugeSlider.value =
            currentStaGauge / maxStaGauge;

        EnemyStaGaugeSlider.value =
            currentEnemyStaGauge / maxEnemyStaGauge;

   



    }



    // Player HP decrease increase

    public void DecreaseHPGauge(float amount)
    {
        currentHPGauge -= amount;
        if (currentHPGauge < 0)
            currentHPGauge = 0;

        //UpdateGaugeUI();
    }

    public void IncreaseHPGauge(float amount)
    {
        currentHPGauge += amount;
        if (currentHPGauge > maxHPGauge)
            currentHPGauge = maxHPGauge;

        //UpdateGaugeUI();
    }

    // Enemy HP increase  decrease

    public void DecreaseEnemyHPGauge(float amount)
    {
        Debug.Log(currentEnemyHPGauge + "F");
        currentEnemyHPGauge -= amount;
        if (currentEnemyHPGauge < 0)
            currentEnemyHPGauge = 0;

        //UpdateGaugeUI();
    }

    public void IncreaseEnemyHPGauge(float amount)
    {
        currentEnemyHPGauge += amount;
        if (currentEnemyHPGauge > maxEnemyHPGauge)
            currentEnemyHPGauge = maxEnemyHPGauge;

       // UpdateGaugeUI();
    }

    // Player Sta increase decrease 

    public void DecreaseStaGauge(float amount)
    {
        currentStaGauge -= amount;
        if (currentStaGauge < 0)
            currentStaGauge = 0;

       // UpdateGaugeUI();
    }

    public void IncreaseStaGauge(float amount)
    {
        currentStaGauge += amount;
        if (currentStaGauge > maxStaGauge)
            currentStaGauge = maxStaGauge;

       // UpdateGaugeUI();
    }



    // Enemy Sta Increase and Decrease

    public void DecreaseEnemyStaGauge(float amount)
    {
        currentEnemyStaGauge -= amount;
        if (currentEnemyStaGauge < 0)
            currentEnemyStaGauge = 0;

       // UpdateGaugeUI();
    }

    public void IncreaseEnemyStaGauge(float amount)
    {
        currentEnemyStaGauge += amount;
        if (currentEnemyStaGauge > maxEnemyStaGauge)
            currentEnemyStaGauge = maxEnemyStaGauge;

       // UpdateGaugeUI();
    }



   



    private void Update()
    {
       StaSpanTime += Time.deltaTime;     //時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (StaSpanTime >= StaSpan)
        {
            //ここで処理を実行

            StaSpanTime = 0;   //経過時間をリセットする


            IncreaseStaGauge(10);                         //1秒に回復する　持久値
            
            IncreaseEnemyStaGauge(10);
            

            // Debug.Log("ahoshineBaka");
           UpdateGaugeUI();

        }

          if (currentHPGauge == 0)
        {
            MakePanel.SetActive(true);
            //battleAudio = this.GetComponent<AudioSource>();
            //battleAudio.Stop();


            //WinAudio = WinAudioMan.GetComponent<AudioSource>();
            //WinAudio.Play();




        }


          if(currentEnemyHPGauge == 0)
        {
            KatiPanel.SetActive(true);
            //battleAudio = this.GetComponent<AudioSource>();
            //battleAudio.Stop();


            //WinAudio = WinAudioMan.GetComponent<AudioSource>();
            //WinAudio.Play();
        }



    }


    public void ToTitleSceneFromBattleScene()
    { 

        SceneManager.LoadScene("TitleScene");


    }











}
