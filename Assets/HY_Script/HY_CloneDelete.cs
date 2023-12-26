using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HY_CloneDelete : MonoBehaviour
{
    // Update is called once per frame
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("HY_Player");
    }
    private void Update()
    {
        if (transform.position.z - player.transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }


}
