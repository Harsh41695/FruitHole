using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

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
    int resetVal=250;
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
        if (sliderVal >= -40 && sliderVal <= -20)
        {
            status = "TOO FAT";
            //200
            coinsUpdater = 200;

        }
        else if (sliderVal >= -21 && sliderVal <= 40)
        {
            status = "FAT";
            //350
            coinsUpdater = 350;

        }
        else if (sliderVal >= 41 && sliderVal <= 49)
        {
            status = "FIT";
            //1000
            coinsUpdater = 1000;
        }
        else if (sliderVal >= 50 && sliderVal <= 55)
        {
            status = "PERFECT";
            //2000
            coinsUpdater = 2000;

        }
        else if (sliderVal >= 56 && sliderVal <= 70)
        {
            status = "FIT";
            //1000
            coinsUpdater = 1000;

        }
        else if (sliderVal >= 71 && sliderVal <= 100)
        {
            status = "SLIM";
            //350
            coinsUpdater = 350;

        }
        else if (sliderVal >= 101 && sliderVal <= 140)
        {
            status = "TOO SLIM";
            //200
            coinsUpdater = 200;

        }
    }
    public void WinCheck()
    {
        //Win Animation Play. and after some time game over panel will open.
        print("WIN Animation");
        isVictory = true;    
        isWon = true;
        time+= Time.deltaTime;
        statusTxt.text = status;
        HY_SaveSystem.instance.SaveData("CurrentTimerCoins", resetVal);
        if (time > 5)
        {
            canGameOverPanelActive = true;
            canScorePanelGo = true;
            time= 0;
        }
    }
    
    public void Loosecheck()
    {
        //Loose Animation Will play and after some time game over panel will open.
        print("Loose Animation");
        isDefeat = true;
        statusTxt.text = status;
        time += Time.deltaTime;
        //time= 0;
        if (time > 5)
        {
            canGameOverPanelActive = true;
            canScorePanelGo = true;
            time = 0;

        }
    }

    public void NoThanksGameOverBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        coins += coinsUpdater;
        if (isWon == true)
        {
            currentGameLVL++;
        }
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
}
