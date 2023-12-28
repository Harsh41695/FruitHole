using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HY_CoinMulitiplier : MonoBehaviour
{
    // Start is called before the first frame update
    public static HY_CoinMulitiplier instance;
    [SerializeField]
    Image indigetor;
   
    //bool canRotate;
    Animator animator;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // indigetor.rectTransform.rotation = Quaternion.Euler(0f, 0f, -80);
        //canRotate = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    [System.Obsolete]
    public void CoinMultipier()
    {
        animator.enabled = false;

        if (indigetor.rectTransform.rotation.eulerAngles.z <= 80 &&
            indigetor.rectTransform.rotation.eulerAngles.z >= 25)
        {
            print("X1");
            GameManager.instance.coinsUpdater += 2000 * 1;

        }
        else if (indigetor.rectTransform.rotation.eulerAngles.z <= 24 &&
            indigetor.rectTransform.rotation.eulerAngles.z >= 360 - 30)
        {
            print("X2");
            GameManager.instance.coinsUpdater += 2000 * 2;

        }
        else if (indigetor.rectTransform.rotation.eulerAngles.z <= 360 - 29 &&
            indigetor.rectTransform.rotation.eulerAngles.z >= 360 - 80)
        {
            print("X3");
            GameManager.instance.coinsUpdater += 2000 * 3;

        }
        //GameManager.instance.NoThanksGameOverBtn();
    }

}