using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using com.adjust.sdk;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool canRun, canSpawn,canCameraMove, canGameOverPanelActive,canScorePanelGo,isWon;
    public int coins, diamonds;
    public GameObject unFitCharacter;
    [SerializeField]public string status;
    [SerializeField]
    Button healthyFoodThrowBtn, UnHealthyFoodThrowBtn;
    public float time;
    [SerializeField]
    TextMeshProUGUI statusTxt;
    public int currentGameLVL = 1;
    public int appleCout, bananaCount, WatermelonCount, orangeCount, cupCakeCount, burgerCount;
    public int coinsUpdater;
    [SerializeField]
    Button bugerClaimBtn, orangeClaimBtm, CupcakeClaimBtn, appleClaimBtn;
    public bool isVictory, isDefeat;
    int coinResetVal=250, timeResetVal=1;
    [SerializeField]
    AudioClip winSound, looseSound;
    [SerializeField]
    GameObject revivePanel;
    bool startTimer=true;
    [SerializeField]
    AudioClip clickSound,coinAddSound;
    bool playsound = true;
    // float coinsUpdater;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            instance=this;
        }
    }
    private void Start()
    {
        canRun = false;
        canSpawn = false;
        canGameOverPanelActive = false;
        canScorePanelGo = false;
        isWon = false;
        GetSavedDataValue();
        unFitCharacter.SetActive(false);
        isVictory= false;
        isDefeat= false;
        startTimer = true;
    }
    void Update()
    {
        SavingAllData();
        win_LooseConditionUpdater();
        CheckClaimButtonActive();

    }
    void win_LooseConditionUpdater()
    {
        if (status == "FIT" || status == "PERFECT")
        {
            //win 
            WinCheck();
        }
        else if (status == "TOO SLIM" || status == "TOO FAT"
            || status == "SLIM" || status == "FAT")
        {
            //LOOSE
            Loosecheck();
        }
    }
    public void FitnessStatus(float sliderVal)
    {
        if (sliderVal >= 50 && sliderVal <= 100)
        {
            status = "TOO FAT";
            //200
            coinsUpdater = 200;

        }
        else if (sliderVal >= 15 && sliderVal <= 49)
        {
            status = "FAT";
            //350
            coinsUpdater = 350;

        }
        else if (sliderVal >= 6 && sliderVal <= 14)
        {
            status = "FIT";
            //1000
            coinsUpdater = 1000;
        }
        else if (sliderVal >= -10 && sliderVal <= 5)
        {
            status = "PERFECT";
            //2000
            coinsUpdater = 2000;

        }
        else if (sliderVal >= -14 && sliderVal <= -9)
        {
            status = "FIT";
            //1000
            coinsUpdater = 1000;

        }
        else if (sliderVal >= -49 && sliderVal <= -15)
        {
            status = "SLIM";
            //350
            coinsUpdater = 350;

        }
        else if (sliderVal >= -100 && sliderVal <= -50)
        {
            status = "TOO SLIM";
            //200
            coinsUpdater = 200;

        }
    }
    public void WinCheck()
    {
        //Win Animation Play. and after some time game over panel will open.
       // print("WIN Animation");
        
        if (playsound == true)
        {
            HY_AudioManager.instance.PlayAudioEffectOnce(winSound);
            playsound = false;
        }
        isVictory = true;    
        isWon = true;
        if (startTimer == true)
        {
            time += Time.deltaTime;
        }
       
        statusTxt.text = status;
        //Timer coin and LVL
        HY_SaveSystem.instance.SaveData("CurrentTimerCoinReq", coinResetVal);
        HY_SaveSystem.instance.SaveData("CurrentTimerLvl", timeResetVal);

        //Power coin and LVL
        HY_SaveSystem.instance.SaveData("CurrentPowerCoinReq", coinResetVal);
        HY_SaveSystem.instance.SaveData("CurrentPowerLvl", timeResetVal);

        //Size coin and LVL
        HY_SaveSystem.instance.SaveData("CurrentSizeCoinReq", coinResetVal);
        HY_SaveSystem.instance.SaveData("CurrentSizeLvl", timeResetVal);

        if (time > 5)
        {
           // revivePanel.SetActive(false);
            canGameOverPanelActive = true;
            canScorePanelGo = true;
            startTimer = false;
            time= 0;
            
        }
    }
    
    public void Loosecheck()
    {
        //Loose Animation Will play and after some time game over panel will open.
       // print("Loose Animation");
        if (playsound == true)
        {
            HY_AudioManager.instance.PlayAudioEffectOnce(looseSound);
            playsound=false;
        }
        isDefeat = true;
        statusTxt.text = status;
        if (startTimer == true)
        {
            time += Time.deltaTime;

        }
        //time= 0;
        if (time > 5)
        {

            canGameOverPanelActive = true;
            canScorePanelGo = true;
            startTimer = false;
            startTimer = false;
        }
       
    }

    public void NoThanksGameOverBtn()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);
        HY_AudioManager.instance.PlayAudioEffectOnce(coinAddSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        coins += coinsUpdater;
        if (isWon == true)
        {
            currentGameLVL++;
        }
        interstitialUnity.instance.ShowAd();
    }

    public void ReviveNoThanksBtn()
    {
        revivePanel.SetActive(false);
        canGameOverPanelActive = true;
        canScorePanelGo = true;
    }
    public void SavingAllData()
    {
        HY_SaveSystem.instance.SaveData("Coins", coins);
        HY_SaveSystem.instance.SaveData("Diamonds", diamonds);
        HY_SaveSystem.instance.SaveData("CurrentLVL", currentGameLVL);
        HY_SaveSystem.instance.SaveData("Apple", appleCout);
        HY_SaveSystem.instance.SaveData("Banana", bananaCount);
        HY_SaveSystem.instance.SaveData("Orange", orangeCount);
        HY_SaveSystem.instance.SaveData("Watermelon", WatermelonCount);
        HY_SaveSystem.instance.SaveData("Burger", burgerCount);
        HY_SaveSystem.instance.SaveData("Cupcake", cupCakeCount);
    }
    void GetSavedDataValue()
    {
        coins = HY_SaveSystem.instance.GetSavedData("Coins");
        currentGameLVL = HY_SaveSystem.instance.GetSavedData("CurrentLVL");
        appleCout = HY_SaveSystem.instance.GetSavedData("Apple");
        bananaCount = HY_SaveSystem.instance.GetSavedData("Banana");
        orangeCount = HY_SaveSystem.instance.GetSavedData("Orange");
        WatermelonCount = HY_SaveSystem.instance.GetSavedData("Watermelon");
        burgerCount = HY_SaveSystem.instance.GetSavedData("Burger");
        cupCakeCount = HY_SaveSystem.instance.GetSavedData("Cupcake");
        diamonds = HY_SaveSystem.instance.GetSavedData("Diamonds");
    }
   
    void CheckClaimButtonActive()
    {
        if (HY_SaveSystem.instance.GetSavedData("BurgerClaim") == 1)
        {
            bugerClaimBtn.interactable = false;
        }
        if (HY_SaveSystem.instance.GetSavedData("OrangeClaim") == 1)
        {
            orangeClaimBtm.interactable = false;
        }
        if (HY_SaveSystem.instance.GetSavedData("AppleClaim") == 1)
        {
            appleClaimBtn.interactable = false;
        }
        if (HY_SaveSystem.instance.GetSavedData("CupcakeClaim") == 1)
        {
            CupcakeClaimBtn.interactable = false;
        }
    }
    //public void OnCoinMultiplierBtnClick()
    //{

    //}
    public void sendadjusttoken(string token)
    {
        AdjustEvent @event = new AdjustEvent(token);
        Adjust.trackEvent(@event);
    }
}
