using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HY_TextSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject textPrefab,spawnPoint;
    //[SerializeField] TextMeshPro textToSpawn;
    // Update is called once per frame
    void Update()
    {
        //textToSpawn.text=HY_Obstacle.instance.pointToUpdate.ToString();
        if (HY_Obstacle.instance.textSpanw == true)
        {
            Instantiate(textPrefab, spawnPoint.transform.position, Quaternion.identity);
            //HY_Obstacle.instance.textSpanw = false;
        }
    }
}
