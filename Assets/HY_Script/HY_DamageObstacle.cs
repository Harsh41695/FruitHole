using UnityEngine;

public class HY_DamageObstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "GreenPlus":
                HY_UIManager.instance.healthyFood += 50;
                print(HY_UIManager.instance.healthyFood);
                break;
            case "GreenMinus":
                HY_UIManager.instance.healthyFood -= 50;
                print(HY_UIManager.instance.healthyFood);
                break;
            case "RedPlus":
                HY_UIManager.instance.unHealthyFood += 50;
                print(HY_UIManager.instance.unHealthyFood);
                break;
            case "RedMinus":
                HY_UIManager.instance.unHealthyFood -= 50;
                print(HY_UIManager.instance.unHealthyFood);
                break;
        }
    }
}
