using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HY_UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    Button timerUpgBtn,timerDimndUpgBtn, powerUpgBtn, powerDimndUpgBtn, 
        sizeUpgbtn, sizeDimndUpgBtn;
    [SerializeField]
    TextMeshProUGUI timerBtnCoinsTxt,timerBtnDimondTxt, powerBtnCoinsTxt, powerBtnDimondTxt, 
        sizeBtnCoinsTxt, sizeBtnDimondTxt;
    public int startTimerCoins = 250,startTimerDiamnd=10, startPowerCoins = 250, startPowerDiamnd=10,
        startSizeCoins = 250,startSizeDiamnd=10;
    [SerializeField]
    TextMeshProUGUI timerLVLTxt, powerLvlTxt, sizeLvlTxt;
    int timerLvl=1, powerLvl=1,sizeLvl=1;

    void Start()
    {
        startTimerCoinNLVL();
        startPwoerCoinNLVL();
        startSizeCoinNLVL();
    }

    // Update is called once per frame
    void Update()
    {
        CoinsBtnStatusUpdater();
        timerLVLTxtNCoinTxtUpdater();
        PowerLVLTxtNCoinTxtUpdater();
        SizeLVLTxtNCoinTxtUpdater();
    }
    public void OnTimerCoinBtn()
    {
        //coins text update
        //text update
        //coin--
        GameManager.instance.coins -= startTimerCoins;
        startTimerCoins += 250;
        timerLvl++;
        HY_SaveSystem.instance.SaveData("CurrentTimerCoinReq", startTimerCoins);
        HY_SaveSystem.instance.SaveData("CurrentTimerLvl", timerLvl);
        HY_UIManager.instance.seconds++;
        if (HY_UIManager.instance.seconds > 60)
        {
            HY_UIManager.instance.minutes++;
            HY_UIManager.instance.seconds = 0;
        }
      
    }
    public void OnTimerDiamndBtn() //Timer Diamond 
    {
        GameManager.instance.diamonds -= startTimerDiamnd;
        startTimerDiamnd += 20;
        timerLvl++;
        HY_SaveSystem.instance.SaveData("CurrentTimerDiamondReq", startTimerDiamnd);
        HY_SaveSystem.instance.SaveData("CurrentTimerLvl", timerLvl);
        HY_UIManager.instance.seconds++;
        if (HY_UIManager.instance.seconds > 60)
        {
            HY_UIManager.instance.minutes++;
            HY_UIManager.instance.seconds = 0;
        }
    }
    public void OnPowerCoinBtn()
    {
        GameManager.instance.coins -= startPowerCoins;
        startPowerCoins += 250;
        powerLvl++;
        HY_HoleBehaviour.instance.IncreacePowerLevel(1);
        HY_SaveSystem.instance.SaveData("CurrentPowerCoinReq", startPowerCoins);
        HY_SaveSystem.instance.SaveData("CurrentPowerLvl", powerLvl);
       // HY_Obstacle.instance.pointToUpdate += 1;


    }
    public void OnPowerDiamndBtn()//Power Diamond
    {
        GameManager.instance.diamonds -= startPowerDiamnd;
        startPowerDiamnd += 20;
        powerLvl++;
        HY_HoleBehaviour.instance.IncreacePowerLevel(1);
        HY_SaveSystem.instance.SaveData("CurrentPowerDiamondReq", startPowerDiamnd);
        HY_SaveSystem.instance.SaveData("CurrentTimerLvl", powerLvl);
       // HY_Obstacle.instance.pointToUpdate += 1f;

    }
    public void OnsizeCoinBtn()
    {
        GameManager.instance.coins -= startSizeCoins;
        startSizeCoins += 250;
        sizeLvl++;
        HY_HoleBehaviour.instance.AddPoint(10f);
        HY_SaveSystem.instance.SaveData("CurrentSizeCoinReq", startSizeCoins);
        HY_SaveSystem.instance.SaveData("CurrentSizeLvl", sizeLvl);
        
    }
    public void OnSizeDiamndBtn()// Size Diamond.
    {
        GameManager.instance.diamonds -= startSizeDiamnd;
        startSizeDiamnd += 20;
        sizeLvl++;
        HY_HoleBehaviour.instance.AddPoint(5f);
        HY_SaveSystem.instance.SaveData("CurrentSizeDiamondReq", startSizeDiamnd);
        HY_SaveSystem.instance.SaveData("CurrentSizeLvl", sizeLvl);

    }
    void startTimerCoinNLVL()
    {
        startTimerCoins = HY_SaveSystem.instance.GetSavedData("CurrentTimerCoinReq");
        if (startTimerCoins == 0)
        {
            startTimerCoins = 250;
        }
        timerLvl = HY_SaveSystem.instance.GetSavedData("CurrentTimerLvl");
        if (timerLvl == 0)
        {
            timerLvl = 1;
        }
        startTimerDiamnd = HY_SaveSystem.instance.GetSavedData("CurrentTimerDiamondReq");
        if (startTimerDiamnd == 0)
        {
            startTimerDiamnd= 10;
        }
    }
    void startPwoerCoinNLVL()
    {
        startPowerCoins = HY_SaveSystem.instance.GetSavedData("CurrentPowerCoinReq");
        if (startPowerCoins == 0)
        {
            startPowerCoins = 250;
        }
        powerLvl = HY_SaveSystem.instance.GetSavedData("CurrentPowerLvl");
        if (powerLvl == 0)
        {
            powerLvl = 1;
        }
        startPowerDiamnd = HY_SaveSystem.instance.GetSavedData("CurrentPowerDiamondReq");
        if (startPowerDiamnd == 0)
        {
            startPowerDiamnd= 10;
        }
    }
    void startSizeCoinNLVL()
    {
        startSizeCoins = HY_SaveSystem.instance.GetSavedData("CurrentSizeCoinReq");
        if (startSizeCoins == 0)
        {
            startSizeCoins = 250;
        }
        sizeLvl = HY_SaveSystem.instance.GetSavedData("CurrentSizeLvl");
        if (sizeLvl == 0)
        {
            sizeLvl = 1;
        }
        startSizeDiamnd = HY_SaveSystem.instance.GetSavedData("CurrenSizeDiamondReq");
        if (startSizeDiamnd == 0)
        {
            startSizeDiamnd = 10;
        }
    }

    void timerLVLTxtNCoinTxtUpdater()
    {
        timerLVLTxt.text = "TIMER LVL." + timerLvl.ToString();
        timerBtnCoinsTxt.text = startTimerCoins.ToString();
        timerBtnDimondTxt.text = startTimerDiamnd.ToString();

    }//Updating Txt of respected elements
    void PowerLVLTxtNCoinTxtUpdater()
    {
        powerLvlTxt.text = "POWER LVL." + powerLvl.ToString();
        powerBtnCoinsTxt.text = startPowerCoins.ToString();
        powerBtnDimondTxt.text = startPowerDiamnd.ToString();
    }//Updating Txt of respected elements
    void SizeLVLTxtNCoinTxtUpdater()
    {
        sizeLvlTxt.text = "SIZE LVL." + sizeLvl.ToString();
        sizeBtnCoinsTxt.text = startSizeCoins.ToString();
        sizeBtnDimondTxt.text = startSizeDiamnd.ToString();
    }//Updating Txt of respected elements

    private void CoinsBtnStatusUpdater()
    {
        if (GameManager.instance.coins < startTimerCoins)
        {
            timerUpgBtn.interactable = false;
        }
        if (GameManager.instance.coins < startPowerCoins)
        {
            powerUpgBtn.interactable = false;
        }
        if (GameManager.instance.coins <startSizeCoins)
        {
            sizeUpgbtn.interactable = false;
        }
//----------------------------------------------------------------------------
            ///Diamond Button status..
        if (GameManager.instance.diamonds < startTimerDiamnd)
        {
            timerDimndUpgBtn.interactable = false;
        }
        if (GameManager.instance.diamonds < startPowerDiamnd)
        {
            powerDimndUpgBtn.interactable = false;
        }
        if (GameManager.instance.diamonds < startSizeDiamnd)
        {
            sizeDimndUpgBtn.interactable = false;
        }

    }//Disabling button
}
