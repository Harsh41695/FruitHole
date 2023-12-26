using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HY_PlatformGenertor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform playerTransform, lastPlatform;
    [SerializeField]
    float minDistanceFromPlayer = 70, widthOfPlatform = 10;
    [SerializeField]
    GameObject platformPrefab;
    GameObject currentPlatform;
    // Update is called once per frame
    void Update()
    {
        if (CheckIfCanGenerate())
        {
            GeneratePlatform();
            
        }
        DistaneCal();


    }
    public bool CheckIfCanGenerate()
    {
        return  lastPlatform.position.z-playerTransform.position.z <= minDistanceFromPlayer;
        
    }
    void GeneratePlatform()
    {
         currentPlatform = Instantiate(platformPrefab, new Vector3(lastPlatform.position.x, lastPlatform.position.y,
            lastPlatform.position.z + widthOfPlatform), Quaternion.identity,transform);
        lastPlatform = currentPlatform.transform;
    }
    private void DistaneCal()
    {
        float dis =lastPlatform.position.z - playerTransform.position.z;
        //print(dis); 
    }
}
