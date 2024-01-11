using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class HY_UIManager : MonoBehaviour
{
    public static HY_UIManager instance;

    public int healthyFood,unHealthyFood;
    [SerializeField]
    TextMeshProUGUI healthyFoodCollectTxt, unHealthyFoodCollectTxt, timerText,
        coinTxt,DiamondTxt,CoinTxtOnDamage,stageTxt;
    [SerializeField]
    GameObject timeUpPanel,fireButtonPanel,homeScreenPanel,settingPanel,
        shopPanel,skinPanel,downPanel,foodSkinPanel,skinChangePanel,gameOverPanel,ScorePanel,
        upgradePanel,stagePanel;
    float time;
    [SerializeField]
    GameObject[] fireHealthyFood, fireUnHealthyFood;
    [SerializeField]
    Transform fireObjSpawnPos;
    [SerializeField]
    HY_EndPointCollide _ref;
    [SerializeField]
    GameObject playActiveBtn, playDeactiveBtn, shopActiveBtn, shopDeactiveBtn,
        skinActiveBtn, skinDeactiveBtn;
    public bool canRun, canSpawn;
    public bool leftRightMovementActive = false;
  
    public int minutes = 1;
  
    public float seconds = 60;
    public  bool timeUp = false;
    [SerializeField]
    Button junkFoodThrowBtn, fruitThrowBtn,noThanksBtn;
    [SerializeField]
    AudioClip clickSound,thorwBtn;
    float coinInFloat,diamondInFloat;
    bool canActivePanel = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        fireButtonPanel.SetActive(false);
        timeUpPanel.SetActive(false);
        homeScreenPanel.SetActive(true);
        shopPanel.SetActive(false);
        skinPanel.SetActive(false);
        playActiveBtn.SetActive(true);
        playDeactiveBtn.SetActive(false);
        skinActiveBtn.SetActive(false);
        skinDeactiveBtn.SetActive(true);
        shopActiveBtn.SetActive(false);
        shopDeactiveBtn.SetActive(true);
        downPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        settingPanel.SetActive(false);
        upgradePanel.SetActive(false);
        stagePanel.SetActive(true);

    }
    void Update()
    { 
        healthyFoodCollectTxt.text = healthyFood.ToString();
        if (healthyFood <= 0)
        {
            healthyFood = 0;
        }
        unHealthyFoodCollectTxt.text = unHealthyFood.ToString();
        if (unHealthyFood <= 0)
        {
            unHealthyFood=0;
        }
        
        if (HY_EndPointCollide.instance.panalCanActive == true)
        {
            timeUpPanel.SetActive(true);
            time += Time.deltaTime;
            
        }
        else
        {
            if (_ref.panalCanActive == true)
            {
                timeUpPanel.SetActive(true);
                time += Time.deltaTime;
               
            }
        }

       if(time>5)
        {
            timeUpPanel.SetActive(false);
            Time.timeScale = 1;
            CameraFollow.instance.initialCameraRotation= new Vector3(3f, 0f, 0f);
            CameraFollow.instance.offsetFromPlayer = new Vector3(0f, 5f, -15f);
            fireButtonPanel.SetActive(true);
            leftRightMovementActive = true;
            GameManager.instance.unFitCharacter.SetActive(true);
           // ScorePanel.SetActive(false);
            if (timeUp == false)
            {
                TimerUpdate();
                ScorePanel.SetActive(false);

            }
        }
        if (timeUp == true)
        {
           // GameManager.instance.FitnessStatus()
            timerText.text = 00+ ":" + 00.ToString();
            junkFoodThrowBtn.interactable = false;
            fruitThrowBtn.interactable = false;
            if (GameManager.instance.canGameOverPanelActive == true)
            {
                if (canActivePanel == true)
                {
                    ScorePanel.SetActive(true);
                    gameOverPanel.SetActive(true);
                    Invoke("ActivateNoThankButton", 5);
                    canActivePanel = false;
                    interstitialUnity.instance.ShowAd();
                }
               
                //ActivateNoThankButton();
               
            }
        }
        CoinUpdater();
        DiamondUpdater();
        CoinTxtOnDamage.text = GameManager.instance.coinsUpdater.ToString();
        stageTxt.text = "STAGE -" + GameManager.instance.currentGameLVL.ToString();
    }
    void CoinUpdater()
    {
        coinInFloat = GameManager.instance.coins;
        coinTxt.text = coinInFloat.ToString();

         if (GameManager.instance.coins > 100000)
         {
            coinTxt.text = (coinInFloat / 10000).ToString("F") + "B";
         }
         else if (coinInFloat > 10000)
         {
            coinTxt.text = (coinInFloat / 10000).ToString("F") + "M";;
         }
        else if (coinInFloat > 1000)
        {
            coinTxt.text = (coinInFloat / 1000).ToString("F") + "K";
        }

    }
    void DiamondUpdater()
    {
        diamondInFloat = GameManager.instance.diamonds;
        DiamondTxt.text = GameManager.instance.diamonds.ToString();
        if (diamondInFloat > 100000)
        {
            DiamondTxt.text = (diamondInFloat / 10000).ToString("F") + "B";
        }
        else if (diamondInFloat > 10000)
        {

            DiamondTxt.text = (diamondInFloat / 10000).ToString("F") + "M";
        }

        else if (diamondInFloat > 1000)
        {

            DiamondTxt.text = (diamondInFloat / 1000).ToString("F") + "K";
        }
    }
    public void ClickHealthyFoodFire()
    {
        if (healthyFood > 0)
        {
            Instantiate(fireHealthyFood[Random.Range(0, fireHealthyFood.Length)], fireObjSpawnPos.position,
           Quaternion.identity);
           
            healthyFood--;
        }
        HY_AudioManager.instance.PlayAudioEffectOnce(thorwBtn);

    }

    public void ClickUnHealthyFoodFire()
    {
        if (unHealthyFood > 0)
        {
            Instantiate(fireUnHealthyFood[Random.Range(0, fireUnHealthyFood.Length)], fireObjSpawnPos.position,
           Quaternion.identity);
            unHealthyFood--;
        }
        HY_AudioManager.instance.PlayAudioEffectOnce(thorwBtn);

    }
    //                                              Timeup funtion
    void TimerUpdate()
    {
        seconds -= Time.deltaTime;
        if (seconds < 1)
        {
            minutes--;
            if (minutes < 0)
            {
                GameManager.instance.FitnessStatus(HY_ChracterBodyShapeChange.instance.fitNessBar.value);
                print("Min goes<0called");
                timeUp = true;
                junkFoodThrowBtn.interactable = false;
                fruitThrowBtn.interactable = false;
                //minutes = 0;
            }
            seconds = 60;
        }
        if (seconds < 10)
        {
            timerText.text = "0" + minutes + " : " + "0" + (int)seconds;

        }
        else
        {
            timerText.text = "0" + minutes + " : " + (int)seconds;

        }
    }

    void ActivateNoThankButton()
    {
        noThanksBtn.gameObject.SetActive(true);
    }

    public void OnPlayAtiveBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);
       // HY_SaveSystem.instance.SaveData("FirstTime", 1);
     
        Time.timeScale = 1;
        downPanel.SetActive(false);
        settingPanel.SetActive(false);
        homeScreenPanel.SetActive(false);
        playDeactiveBtn.SetActive(false);
        shopPanel.SetActive(false);
        upgradePanel.SetActive(false);
        stagePanel.SetActive(false);
        GameManager.instance.canRun = true;
        GameManager.instance.canSpawn = true;
        GameManager.instance.canCameraMove = true;
        GameManager.instance.canRunSpeedTimer = true;
    }
    public void OnPlayDeacvtiveBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);
        print("playAactiveTrue");
        skinActiveBtn.SetActive(false);
        skinDeactiveBtn.SetActive(true);
        playActiveBtn.SetActive(true);
        playDeactiveBtn.SetActive(false);
        shopActiveBtn.SetActive(false);
        shopDeactiveBtn.SetActive(true);
        //skinPanel.SetActive(false);
        shopPanel.SetActive(false);
        skinPanel.SetActive(false);
        homeScreenPanel.SetActive(true);
    }
    public void OnSkinBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);

        print("SkinPanelOpen");
        skinPanel.SetActive(true);
        skinActiveBtn.SetActive(true);
        skinDeactiveBtn.SetActive(false);
        playActiveBtn.SetActive(false);
        playDeactiveBtn.SetActive(true);
        shopActiveBtn.SetActive(false);
        shopDeactiveBtn.SetActive(true);
        shopPanel.SetActive(false);
        homeScreenPanel.SetActive(false);
        settingPanel.SetActive(false);

    }
    public void OnShopBtnClick()
    {
        
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);

        print("ShopPanelOpen");
        shopPanel.SetActive(true);
        skinPanel.SetActive(false);
        skinActiveBtn.SetActive(false);
        skinDeactiveBtn.SetActive(true);
        playActiveBtn.SetActive(false);
        playDeactiveBtn.SetActive(true);
        shopActiveBtn.SetActive(true);
        shopDeactiveBtn.SetActive(false);
        homeScreenPanel.SetActive(false);
        settingPanel.SetActive(false);

    }
    public void OnSettingBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);
        settingPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnSettingCrossBtn()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);
        settingPanel.SetActive(false);
        //Time.timeScale = HY_HoleBehaviour.instance.currentTimeScale;
       
    }

    public void OnFoodSkinChangeBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);

        foodSkinPanel.SetActive(true);
        skinChangePanel.SetActive(false);
    }
    public void OnHoleSkinChangeBtnClik()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);

        skinChangePanel.SetActive(true);
        foodSkinPanel.SetActive(false);
    }
    public void OnUpgradeBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);

        upgradePanel.SetActive(true);
    }
    public void OnUpgradeCrossBtnClick()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(clickSound);

        upgradePanel.SetActive(false);

    }

}
