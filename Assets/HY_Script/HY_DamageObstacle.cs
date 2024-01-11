using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_DamageObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "GreenPlus":
                HY_UIManager.instance.healthyFood += 50;
                break;
            case "GreenMinus":
                HY_UIManager.instance.healthyFood -= 50;
                break;
            case "RedPlus":
                HY_UIManager.instance.unHealthyFood += 50;
                break;
            case "RedMinus":
                HY_UIManager.instance.unHealthyFood -= 50;
                break;
        }
    }
}
