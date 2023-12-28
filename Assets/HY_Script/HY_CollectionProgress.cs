using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HY_CollectionProgress : MonoBehaviour
{
    [SerializeField]
    Image progressImg;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    float minVal, MaxVal = 2000;
    [SerializeField] string foodName;
    [SerializeField]
    GameObject barContent, claimButton;
    [SerializeField]
    Button claimBtn;
    [SerializeField]
    int rewardedDiamond = 100;
    private void OnEnable()
    {
        switch (foodName)
        {
            case "Burger":
                BarValueChange(GameManager.instance.burgerCount);
                break;
            case "Orange":
                BarValueChange(GameManager.instance.orangeCount);
                break;
            case "Apple":
                BarValueChange(GameManager.instance.appleCout);
                break;
            case "Cupcake":
                BarValueChange(GameManager.instance.cupCakeCount);
                break;

        }

    }

    private void Update()
    {
        if (minVal >= MaxVal)
        {
            barContent.SetActive(false);
            claimButton.SetActive(true);
        }
        
    }
    public void BarValueChange(int value)
    {
        minVal = value;
        text.text = minVal+"/"+MaxVal.ToString();
        progressImg.fillAmount = minVal / MaxVal;
    }
    public void OnBurgerClaimBtn()
    {
        GameManager.instance.diamonds += rewardedDiamond;
        claimBtn.interactable = false;
        HY_SaveSystem.instance.SaveData("BurgerClaim", 1);
    }
    public void OnOrangeClaimBtn()
    {
        GameManager.instance.diamonds += rewardedDiamond;
        claimBtn.interactable = false;
        HY_SaveSystem.instance.SaveData("OrangeClaim", 1);
    }
    public void OnAppleClaimBtn()
    {
        GameManager.instance.diamonds += rewardedDiamond;
        claimBtn.interactable = false;
        HY_SaveSystem.instance.SaveData("AppleClaim", 1);

    }
    public void OnCupcakeClaimBtn()
    {
        GameManager.instance.diamonds += rewardedDiamond;
        claimBtn.interactable = false;
        HY_SaveSystem.instance.SaveData("CupcakeClaim", 1);


    }

}
