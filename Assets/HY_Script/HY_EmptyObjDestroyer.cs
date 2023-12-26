using UnityEngine;

public class HY_EmptyObjDestroyer : MonoBehaviour
{
    void Update()
    {
        if (HY_Obstacle.instance.GetDistance() < -10)
        {
            Destroy(gameObject);
        }
    }
}
