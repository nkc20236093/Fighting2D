using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Text TurnSu;
    public int Turn;
    

    
    public float decreaseAmount = 20f;
    public TraGaugeManager traGaugeManager;



    public Text HPsippaiRitu;
    public Text HPText;
    public Button HPincreaceButton;

    public static float HP;
    private int HPbuttonPressCount = -1;


    public Text HPTraLev;




    public Text PowersippaiRitu;
    public Text PowerText;
    public Button PowerincreaceButton;

    public static float Power;
    private int PowerbuttonPressCount = -1;

    public Text PowTraLev;

    //Speed

    public Text SpeedsippaiRitu;
    public Text SpeedText;
    public Button SpeedincreaceButton;

    public static float Speed;
    private int SpeedbuttonPressCount = -1;
    public Text SpeTraLev;
    //Stamina

    public Text StaminasippaiRitu;
    public Text StaminaText;
    public Button StaminaincreaceButton;

    public static float Stamina;
    private int StaminabuttonPressCount = -1;

    public Text StaTraLev;
    //Cleverness

    public Text ClevernesssippaiRitu;
    public Text ClevernessText;
    public Button ClevernessincreaceButton;

    public static float Cleverness;
    private int ClevernessbuttonPressCount = -1;

    public Text CleTraLev;

    private void Start()
    {

        HPincreaceButton.onClick.AddListener(IncreaseHPSippai);
        PowerincreaceButton.onClick.AddListener(IncreasePowerSippai);
        SpeedincreaceButton.onClick.AddListener(IncreaseSpeedSippai);
        StaminaincreaceButton.onClick.AddListener(IncreaseStaminaSippai);
        ClevernessincreaceButton.onClick.AddListener(IncreaseClevernessSippai);

        HPincreaceButton.onClick.Invoke();
        PowerincreaceButton.onClick.Invoke();
        SpeedincreaceButton.onClick.Invoke();
        StaminaincreaceButton.onClick.Invoke();
        ClevernessincreaceButton.onClick.Invoke();


        UpdateHPsippaiRitu();
        UpdatePowersippaiRitu();
        UpdateSpeedsippaiRitu();
        UpdateStaminasippaiRitu();
        UpdateClevernesssippaiRitu();

        
    }



    #region UpdateHPsippaiRitu region 
    public void UpdateHPsippaiRitu()
    {
        //hint       traGaugeSlider.value = currentTraGauge / maxTraGauge;

       // trash TraGaugeManager.currentTraGauge


             if (50 <= TraGaugeManager.currentTraGauge)
            {
            HPsippaiRitu.text = "0%";
             }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            HPsippaiRitu.text = "10%";
        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {
            HPsippaiRitu.text = "15%";


        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            HPsippaiRitu.text = "25%";

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            HPsippaiRitu.text = "45%";

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            HPsippaiRitu.text = "55%";

        }

    }



    private void IncreaseHPSippai()
    { 
        int HPSippai = Random.Range(0, 101);

        Turn--;
        TurnSu.text = Turn.ToString();


        if (50 <= TraGaugeManager.currentTraGauge)
        {
            IncreaseHP();
        }
        else if ( 50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            if (HPSippai <= 90)
            {
                IncreaseHP();

            }
            else
            {
                //�C����������
            }
     
        }
        else if (40>= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {

            if (HPSippai <= 85)
            {
                IncreaseHP();

            }
            else
            {
                //�C����������
            }

        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            if (HPSippai <= 75)
            {
                IncreaseHP();

            }
            else
            {
                //�C����������
            }

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            if (HPSippai <= 55)
            {
                IncreaseHP();

            }
            else
            {
                //�C����������
            }

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            if (HPSippai <= 45)
            {
                IncreaseHP();

            }
            else
            {
                //�C����������
            }

        }
    }
    #endregion


    #region HP Increase Region
    private void IncreaseHP()
    {

        Debug.Log(TraGaugeManager.currentTraGauge);
     



        //�X�e�[�^�X���[�P�O�œn����Ă���̂ŁC���킹�邽��
        //�̂�������̂P�{�^���N���̂Ƃ��̓g���[�j���O�|�C���g����Ȃ�
        if (HPbuttonPressCount != -1)
        {



            //�P�����C�����Q��
            traGaugeManager.DecreaseGauge(decreaseAmount);

          

        }


        




        // �{�^�����������񐔂��X�V
        HPbuttonPressCount++;

        // �{�^�����������񐔂ɉ�����HP�𑝉�
        float HPIncrease = 0;
        if (HPbuttonPressCount >= -1 && HPbuttonPressCount <= 3)
        {
            HPIncrease = 4f;
            HPTraLev.text = "Lv1";
        }
        else if (HPbuttonPressCount >= 4 && HPbuttonPressCount <= 7)
        {
            HPIncrease =  6f;
            HPTraLev.text = "Lv2";
        }
        else if (HPbuttonPressCount >= 8 && HPbuttonPressCount <= 11)
        {
            HPIncrease = 8f;

            HPTraLev.text = "Lv3";
        }
        else if (HPbuttonPressCount >= 12 && HPbuttonPressCount <= 15)
        {
            HPIncrease = 10f;
            HPTraLev.text = "Lv4";
        }
        else
        {
            HPIncrease = 12f;
            HPTraLev.text = "Lv5";
        }

        // HP�𑝉������ĕ\�����X�V
        HP += HPIncrease;
        UpdateHPText();

        //HP sippai Ritu next

        
        UpdateHPsippaiRitu();
        UpdatePowersippaiRitu();
        UpdateSpeedsippaiRitu();
        UpdateStaminasippaiRitu();
        UpdateClevernesssippaiRitu();


    }

    private void UpdateHPText()
    {
        // HP�e�L�X�g���X�V
        HPText.text =  HP.ToString();
    }

    #endregion






    #region UpdatePowersippaiRitu region
    public void UpdatePowersippaiRitu()
    {
        


        if (50 <= TraGaugeManager.currentTraGauge)
        {
            PowersippaiRitu.text = "0%";
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            PowersippaiRitu.text = "20%";
        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {
            PowersippaiRitu.text = "35%";


        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            PowersippaiRitu.text = "50%";

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            PowersippaiRitu.text = "90%";

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            PowersippaiRitu.text = "99%";

        }

    }



    private void IncreasePowerSippai()
    {
        int PowerSippai = Random.Range(0, 101);

        Turn--;
        TurnSu.text = Turn.ToString();

        if (50 <= TraGaugeManager.currentTraGauge)
        {
            IncreasePower();
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            if (PowerSippai <= 80)
            {
                IncreasePower();

            }
            else
            {
                //�C����������
            }

        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {

            if (PowerSippai <= 65)
            {
                IncreasePower();

            }
            else
            {
                //�C����������
            }

        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            if (PowerSippai <= 50)
            {
                IncreasePower();

            }
            else
            {
                //�C����������
            }

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            if (PowerSippai <= 10)
            {
                IncreasePower();

            }
            else
            {
                //�C����������
            }

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            if (PowerSippai <= 1)
            {
                IncreasePower();

            }
            else
            {
                //�C����������
            }

        }
    }
    #endregion

    #region Power Increase Region
    private void IncreasePower()
    {


        if (PowerbuttonPressCount != -1)
        {
            traGaugeManager.DecreaseGauge(decreaseAmount);

        }

        // �{�^�����������񐔂��X�V
        PowerbuttonPressCount++;

        // �{�^�����������񐔂ɉ�����HP�𑝉�
        float PowerIncrease = 0;
        if (PowerbuttonPressCount >= -1 && PowerbuttonPressCount <= 3)
        {
            PowerIncrease = 0.25f;
            PowTraLev.text = "Lv1";
        }
        else if (PowerbuttonPressCount >= 4 && PowerbuttonPressCount <= 7)
        {
            PowerIncrease = 0.3f;
            PowTraLev.text = "Lv2";
        }
        else if (PowerbuttonPressCount >= 8 && PowerbuttonPressCount <= 11)
        {
            PowerIncrease = 0.4f;
            PowTraLev.text = "Lv3";
        }
        else if (PowerbuttonPressCount >= 12 && PowerbuttonPressCount <= 15)
        {
            PowerIncrease = 0.45f;
            PowTraLev.text = "Lv4";
        }
        else
        {
            PowerIncrease = 0.5f;
            PowTraLev.text = "Lv5";
        }

        // Power�𑝉������ĕ\�����X�V
        Power += PowerIncrease;
        UpdatePowerText();



        
        UpdateHPsippaiRitu();
        UpdatePowersippaiRitu();
        UpdateSpeedsippaiRitu();
        UpdateStaminasippaiRitu();
        UpdateClevernesssippaiRitu();
    }

    private void UpdatePowerText()
    {
        // Poewr�e�L�X�g���X�V
        PowerText.text = Power.ToString();
    }

    #endregion


    #region UPdateSpeedsippaiRitu region


    public void UpdateSpeedsippaiRitu()
    {



        if (50 <= TraGaugeManager.currentTraGauge)
        {
            SpeedsippaiRitu.text = "0%";
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            SpeedsippaiRitu.text = "10%";
        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {
            SpeedsippaiRitu.text = "25%";


        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            SpeedsippaiRitu.text = "45%";

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            SpeedsippaiRitu.text = "60%";

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            SpeedsippaiRitu.text = "99%";

        }

    }



    private void IncreaseSpeedSippai()
    {
        int SpeedSippai = Random.Range(0, 101);

        Turn--;
        TurnSu.text = Turn.ToString();

        if (50 <= TraGaugeManager.currentTraGauge)
        {
            IncreaseSpeed();
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            if (SpeedSippai <= 90)
            {
                IncreaseSpeed();

            }
            else
            {
                //�C����������
            }

        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {

            if (SpeedSippai <= 75)
            {
                IncreaseSpeed();

            }
            else
            {
                //�C����������
            }

        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            if (SpeedSippai <= 55)
            {
                IncreaseSpeed();

            }
            else
            {
                //�C����������
            }

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            if (SpeedSippai <= 40)
            {
                IncreaseSpeed();

            }
            else
            {
                //�C����������
            }

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            if (SpeedSippai <= 1)
            {
                IncreaseSpeed();

            }
            else
            {
                //�C����������
            }

        }
    }


#endregion

    #region Speed Increase Region
    private void IncreaseSpeed()
    {

        if (SpeedbuttonPressCount != -1)
        {


            traGaugeManager.DecreaseGauge(decreaseAmount);
        }

        // �{�^�����������񐔂��X�V
        SpeedbuttonPressCount++;

        // �{�^�����������񐔂ɉ�����HP�𑝉�
        float SpeedIncrease = 0;
        if (SpeedbuttonPressCount >= -1 && SpeedbuttonPressCount <= 3)
        {
            SpeedIncrease = 0.05f;
            SpeTraLev.text = "Lv1";
        }
        else if (SpeedbuttonPressCount >= 4 && SpeedbuttonPressCount <= 7)
        {
            SpeedIncrease = 0.055f;
            SpeTraLev.text = "Lv2";
        }
        else if (SpeedbuttonPressCount >= 8 && SpeedbuttonPressCount <= 11)
        {
            SpeedIncrease = 0.06f;
            SpeTraLev.text = "Lv3";
        }
        else if (SpeedbuttonPressCount >= 12 && SpeedbuttonPressCount <= 15)
        {
            SpeedIncrease = 0.65f;
            SpeTraLev.text = "Lv4";
        }
        else
        {
            SpeedIncrease = 0.07f;
            SpeTraLev.text = "Lv5";
        }

        // Speed�𑝉������ĕ\�����X�V
        Speed += SpeedIncrease;
        UpdateSpeedText();

        


        UpdateHPsippaiRitu();
        UpdatePowersippaiRitu();
        UpdateSpeedsippaiRitu();
        UpdateStaminasippaiRitu();
        UpdateClevernesssippaiRitu();
    }

    private void UpdateSpeedText()
    {
        // Speed�e�L�X�g���X�V
        SpeedText.text = Speed.ToString();
    }

    #endregion





    #region UpdateStaminasippaiRitu region

    public void UpdateStaminasippaiRitu()
    {



        if (50 <= TraGaugeManager.currentTraGauge)
        {
            StaminasippaiRitu.text = "0%";
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            StaminasippaiRitu.text = "10%";
        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {
            StaminasippaiRitu.text = "20%";


        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            StaminasippaiRitu.text = "30%";

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            StaminasippaiRitu.text = "50%";

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            StaminasippaiRitu.text = "60%";

        }

    }



    private void IncreaseStaminaSippai()
    {
        int StaminaSippai = Random.Range(0, 101);

        Turn--;
        TurnSu.text = Turn.ToString();

        if (50 <= TraGaugeManager.currentTraGauge)
        {
            IncreaseStamina();
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            if (StaminaSippai <= 90)
            {
                IncreaseStamina();

            }
            else
            {
                //�C����������
            }

        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {

            if (StaminaSippai <= 80)
            {
                IncreaseStamina();

            }
            else
            {
                //�C����������
            }

        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            if (StaminaSippai <= 70)
            {
                IncreaseStamina();

            }
            else
            {
                //�C����������
            }

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            if (StaminaSippai <= 50)
            {
                IncreaseStamina();

            }
            else
            {
                //�C����������
            }

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            if (StaminaSippai <= 40)
            {
                IncreaseStamina();

            }
            else
            {
                //�C����������
            }

        }
    }


#endregion

    #region Stamina Increase Region
    private void IncreaseStamina()
    {
        if (StaminabuttonPressCount != -1)
        {
            traGaugeManager.DecreaseGauge(decreaseAmount);
        }

        // �{�^�����������񐔂��X�V
        StaminabuttonPressCount++;

        // �{�^�����������񐔂ɉ�����HP�𑝉�
        float StaminaIncrease = 0;
        if (StaminabuttonPressCount >= -1 && StaminabuttonPressCount <= 3)
        {
            StaminaIncrease = 3f;
            StaTraLev.text = "Lv1";
        }
        else if (StaminabuttonPressCount >= 4 && StaminabuttonPressCount <= 7)
        {
            StaminaIncrease = 5f;
            StaTraLev.text = "Lv2";
        }
        else if (StaminabuttonPressCount >= 8 && StaminabuttonPressCount <= 11)
        {
            StaminaIncrease = 6.5f;
            StaTraLev.text = "Lv3";
        }
        else if (StaminabuttonPressCount >= 12 && StaminabuttonPressCount <= 15)
        {
            StaminaIncrease = 7.5f;
            StaTraLev.text = "Lv4";
        }
        else
        {
            StaminaIncrease = 10f;
            StaTraLev.text = "Lv5";
        }

        // Stamina�𑝉������ĕ\�����X�V
        Stamina += StaminaIncrease;
        UpdateStaminaText();

        



        UpdateHPsippaiRitu();
        UpdatePowersippaiRitu();
        UpdateSpeedsippaiRitu();
        UpdateStaminasippaiRitu();
        UpdateClevernesssippaiRitu();
    }

    private void UpdateStaminaText()
    {
        // Stamina�e�L�X�g���X�V
        StaminaText.text = Stamina.ToString();
    }


    #endregion




    #region UpdateClevernesssippaiRitu region

    public void UpdateClevernesssippaiRitu()
    {



        if (50 <= TraGaugeManager.currentTraGauge)
        {
            ClevernesssippaiRitu.text = "0%";
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            ClevernesssippaiRitu.text = "2%";
        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {
            ClevernesssippaiRitu.text = "4%";


        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            ClevernesssippaiRitu.text = "8%";

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            ClevernesssippaiRitu.text = "10%";

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            ClevernesssippaiRitu.text = "20%";

        }

    }



    private void IncreaseClevernessSippai()
    {
        int ClevernessSippai = Random.Range(0, 101);

        Turn--;
        TurnSu.text = Turn.ToString();

        if (50 <= TraGaugeManager.currentTraGauge)
        {
            IncreaseCleverness();
        }
        else if (50 > TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 40)
        {
            if (ClevernessSippai <= 98)
            {
                IncreaseCleverness();

            }
            else
            {
                //�C����������
            }

        }
        else if (40 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 30)
        {

            if (ClevernessSippai <= 96)
            {
                IncreaseCleverness();

            }
            else
            {
                //�C����������
            }

        }

        else if (30 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 20)
        {

            if (ClevernessSippai <= 92)
            {
                IncreaseCleverness();

            }
            else
            {
                //�C����������
            }

        }


        else if (20 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge > 10)
        {

            if (ClevernessSippai <= 90)
            {
                IncreaseCleverness();

            }
            else
            {
                //�C����������
            }

        }
        else if (10 >= TraGaugeManager.currentTraGauge && TraGaugeManager.currentTraGauge >= 0)
        {

            if (ClevernessSippai <= 80)
            {
                IncreaseCleverness();

            }
            else
            {
                //�C����������
            }

        }
    }
    #endregion 

    #region Cleverness Increase Region
    private void IncreaseCleverness()
    {
        if (ClevernessbuttonPressCount != -1)
        {
            traGaugeManager.DecreaseGauge(decreaseAmount);

        }


        // �{�^�����������񐔂��X�V
        ClevernessbuttonPressCount++;

        // �{�^�����������񐔂ɉ�����HP�𑝉�
        float ClevernessIncrease = 0;
        if (ClevernessbuttonPressCount >= -1 && ClevernessbuttonPressCount <= 3)
        {
            ClevernessIncrease = 10;
            CleTraLev.text = "Lv1";
        }
        else if (ClevernessbuttonPressCount >= 4 && ClevernessbuttonPressCount <= 7)
        {
            ClevernessIncrease = 20;
            CleTraLev.text = "Lv2";
        }
        else if (ClevernessbuttonPressCount >= 8 && ClevernessbuttonPressCount <= 11)
        {
            ClevernessIncrease = 30;
            CleTraLev.text = "Lv3";
        }
        else if (ClevernessbuttonPressCount >= 12 && ClevernessbuttonPressCount <= 15)
        {
            ClevernessIncrease = 40;
            CleTraLev.text = "Lv4";
        }
        else
        {
            ClevernessIncrease = 50;
            CleTraLev.text = "Lv5";
        }

        // Cleverness�𑝉������ĕ\�����X�V
        Cleverness += ClevernessIncrease;
        UpdateClevernessText();

        


        UpdateHPsippaiRitu();
        UpdatePowersippaiRitu();
        UpdateSpeedsippaiRitu();
        UpdateStaminasippaiRitu();
        UpdateClevernesssippaiRitu();
    }

    private void UpdateClevernessText()
    {
        // Cleverness�e�L�X�g���X�V
        ClevernessText.text = Cleverness.ToString();
    }
    #endregion






}
