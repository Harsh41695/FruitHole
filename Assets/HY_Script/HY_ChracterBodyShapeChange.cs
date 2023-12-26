//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class HY_ChracterBodyShapeChange : MonoBehaviour
{
    public static HY_ChracterBodyShapeChange instance;
    [SerializeField]
    SkinnedMeshRenderer playersSkin;
    public float myValue = 0;
    //[SerializeField]
    public Slider fitNessBar;
    //public int coinsUpdater;
    int rndGenratorNum, rndStartSlimVal, rndStartFatVal;
  
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        playersSkin = GetComponent<SkinnedMeshRenderer>();
        rndGenratorNum = Random.Range(0, 2);
        print(rndGenratorNum);
        if (rndGenratorNum == 0)
        {
            // Means Character is slim, genrate slim bar value.
            rndStartSlimVal = Random.Range(60, 141);
            playersSkin.SetBlendShapeWeight(0, rndStartSlimVal);
            fitNessBar.value = rndStartSlimVal;
        }
        if (rndGenratorNum == 1)
        {
            // Means Character is fat, genrate fat bar value.
            rndStartFatVal = Random.Range(-30, 40);
            playersSkin.SetBlendShapeWeight(0, rndStartFatVal);
            fitNessBar.value = rndStartFatVal;
            int rnd = Random.Range(0, 1);
        }
        #region//Commented
        //playersSkin.SetBlendShapeWeight(0, 900);
        //slimSlider.minValue = minSlimVal;
        //slimSlider.maxValue = maxSlimVal;
        //fatSlider.minValue = minFatVal;
        //fatSlider.maxValue = maxFatVal;

        //rndGenratorNum = UnityEngine.Random.Range(0, 2);
        //print(rndGenratorNum);
        //if (rndGenratorNum == 0)
        //{
        //    // Means Character is slim, genrate slim bar value.
        //    rndStartSlimVal = UnityEngine.Random.Range(60, 141);
        //    playersSkin.SetBlendShapeWeight(0, rndStartSlimVal);
        //    slimSlider.value = rndStartSlimVal;
        //    fatSlider.value = minFatVal;
        //    isSlim = true;

        //}
        //if (rndGenratorNum == 1)
        //{
        //    // Means Character is fat, genrate fat bar value.
        //    rndStartFatVal = UnityEngine.Random.Range(-30, 40);
        //    playersSkin.SetBlendShapeWeight(0, rndStartFatVal);
        //    fatSlider.value = rndStartFatVal;
        //    slimSlider.value = minSlimVal;
        //    isSlim = false;


        //}
        #endregion
        //coinsUpdater = PlayerPrefs.GetFloat("Coins");
    }

    public void takeDamage(float damageVal)
    {
        fitNessBar.value += damageVal;
        #region//Not Using Code 
        //if (damageVal < 0)
        //{
        //   // GameManager.instance.coins += -(200 * damageVal);
        //    coinsUpdater+= -(200 * damageVal);
        //}
        //else
        //{
        //    //GameManager.instance.coins += 200 * damageVal;
        //    coinsUpdater += (200 * damageVal);
        //}
        //GameManager.instance.coins = coinsUpdater;
        #endregion
        playersSkin.SetBlendShapeWeight(0,fitNessBar.value);
        #region//CommentCode
        //    if (isSlim == true)
        //    {
        //        slimSlider.value += damageVal;
        //        playersSkin.SetBlendShapeWeight(0, slimSlider.value);
        //        if (slimSlider.value <=minSlimVal&&damageVal<=0)
        //        {
        //            fatSlider.value -= damageVal;
        //            if (fatSlider.value != minFatVal && damageVal>= 0)
        //            {
        //                fatSlider.value -= damageVal;
        //            }
        //        }


        //        //if (slimSlider.value <= minSlimVal)
        //        //{
        //        //    slimSlider.value = minSlimVal;
        //        //    fatSlider.value += damageVal;
        //        //}

        //    }
        //    if (isSlim == false)
        //    {

        //        fatSlider.value += damageVal;
        //        playersSkin.SetBlendShapeWeight(0, fatSlider.value);

        //    }
        #endregion
    }

}
