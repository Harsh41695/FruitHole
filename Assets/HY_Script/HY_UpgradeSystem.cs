using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HY_UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    Button timerUpgBtn, powerUpgBtn, sizeUpgbtn;
    [SerializeField]
    TextMeshProUGUI timerBtnCoinsTxt, powerBtnCoinsTxt, sizeBtnCoinsTxt;
    public int startTimerCoins = 250, startPowerCoins = 250, startSizeCoins = 250;
    [SerializeField]
    TextMeshProUGUI timerLVLTxt, powerLvlTXt, sizeLvlTxt;
    int timerLvl=1, powerLvl=1,sizeLvl=1;

    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        CoinsBtnStatusUpdater();
        timerLVLTxt.text = "TIMER LVL." + timerLvl.ToString();
        timerBtnCoinsTxt.text = startTimerCoins.ToString();


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

       // HY_SaveSystem.instance.SaveData("UpdateTimeCoin", startTimerCoins);
    }
    public void OnPowerCoinBtn()
    {
        GameManager.instance.coins -= startPowerCoins;
        startPowerCoins += 250;
        

    }
    public void OnsizeCoinBtn()
    {
        GameManager.instance.coins -= startSizeCoins;
        startSizeCoins += 250;
        
    }
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
    }
}
