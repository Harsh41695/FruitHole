using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManagerActivation : MonoBehaviour
{
    [SerializeField]
    GameObject content;
    void Start()
    {
        if (HY_SaveSystem.instance.GetSavedData("FirstTimeContentShow") == 1)
        {
            content.SetActive(false);
        }
    }
}
