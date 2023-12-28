using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HY_CheckingShopRewardClaimOrNot : MonoBehaviour
{
    [SerializeField]
    GameObject barPanel, claimPanel;
    [SerializeField]
    string tagName;
    private void Start()
    {
        tagName = gameObject.tag;
    }
    void Update()
    {
        switch (tagName)
        {
            case "ShopBurger":
                if (HY_SaveSystem.instance.GetSavedData("BurgerClaim") == 1)
                {
                    barPanel.SetActive(false);
                    claimPanel.SetActive(true);
                }
                break;
            case "ShopApple":
                if (HY_SaveSystem.instance.GetSavedData("AppleClaim") == 1)
                {
                    barPanel.SetActive(false);
                    claimPanel.SetActive(true);
                }
                break;
            case "ShopCupcake":
                if (HY_SaveSystem.instance.GetSavedData("CupcakeClaim") == 1)
                {
                    barPanel.SetActive(false);
                    claimPanel.SetActive(true);
                }
                break;
            case "ShopOrange":
                if (HY_SaveSystem.instance.GetSavedData("OrangeClaim") == 1)
                {
                    barPanel.SetActive(false);
                    claimPanel.SetActive(true);
                }
                break;

        }
      
    }

   
}
