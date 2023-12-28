using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HY_ShopSystem : MonoBehaviour
{
    [SerializeField]
    GameObject BarPanel, ClaimPanel;
    [SerializeField]
    Button diamondBtn, coinBtn;
    [SerializeField]
    TextMeshProUGUI diamondTxt, coinTxt;
    [SerializeField]
    int reqCoin=0,reqDiamond=0;
 
    private void Start()
    {
        coinTxt.text = reqCoin.ToString();
        diamondTxt.text = reqDiamond.ToString();    
    }
    private void Update()
    {
        ButtonActiveCheck(); 
        
    }
    public void OnCoinBtn()
    {
        GameManager.instance.coins-=reqCoin;
        BarPanel.SetActive(false);
        ClaimPanel.SetActive(true);
    } 
    public void OnDimondBtn()
    {
        GameManager.instance.diamonds-=reqDiamond;
        BarPanel.SetActive(false);
        ClaimPanel.SetActive(true);
        
    }

    private void ButtonActiveCheck()
    {
        if (GameManager.instance.coins < reqCoin)
        {
            coinBtn.interactable = false;
        }
        if (GameManager.instance.diamonds < reqDiamond)
        {
            diamondBtn.interactable = false;
        }
    }
}
