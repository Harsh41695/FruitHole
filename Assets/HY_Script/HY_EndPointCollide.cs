using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_EndPointCollide : MonoBehaviour
{
    public static HY_EndPointCollide instance;
    public bool panalCanActive, canCharacterPlatformActive = false;
 
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HY_Player")
        {
            Time.timeScale = 1;
            HY_PlatformMovement.instace.fwdSpeed = 0;
            panalCanActive = true;
            canCharacterPlatformActive = true;
        }
    }
}
