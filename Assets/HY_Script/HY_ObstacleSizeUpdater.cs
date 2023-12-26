using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_ObstacleSizeUpdater : MonoBehaviour
{
    public static HY_ObstacleSizeUpdater instance;
    public void ChangeScaleOfObject(int size)
    {
        transform.localScale += new Vector3(transform.localScale.x + size, transform.localScale.y + size,
            transform.localScale.z + size);
        print("Called");
    }
}
