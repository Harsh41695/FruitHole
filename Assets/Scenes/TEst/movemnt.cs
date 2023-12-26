using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemnt : MonoBehaviour
{
   
    [SerializeField]
    float fwdSpeed = 3;
    void Update()
    {
        transform.position += new Vector3(0, 0, -1) * fwdSpeed * Time.deltaTime;

    }
}
