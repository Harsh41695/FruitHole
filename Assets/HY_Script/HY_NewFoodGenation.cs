using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_NewFoodGenation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] foodForSpawn,obstacleGenerate;
    public GameObject playerRef,lastSpawn;
    [SerializeField]
    float z=10;
    [SerializeField]
    Transform startPoint, endPoint, playerTrans;
    float time;
    void Start()
    {
        playerTrans.position = new Vector3(playerTrans.position.x, playerTrans.position.y
           , startPoint.position.z);
        FoodGenration();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (lastSpawn != null && PlayerDistanceFormLastSpawnObject<150)
        {
            if (CheckEndPointDistance > -800)
            {
                if (time < 5)
                {
                    FoodGenration();

                }
                else if (time >= 5)
                {
                    ObstacelGenereation();
                    time = 0;
                }

            }
        }
    }

    void FoodGenration()
    {
            float x = Random.Range(-5.5f, 4.9f);
            GameObject currentSpawn = Instantiate(foodForSpawn[Random.Range(0, foodForSpawn.Length)],
               new Vector3(x, 0.4f, lastSpawn.transform.position.z + z), Quaternion.identity, transform);
            lastSpawn = currentSpawn;  
        
        //Debug.Log(lastSpawn.transform.position.z + " Z axis", lastSpawn);
       // z += 10;
    }
    void ObstacelGenereation()
    {
        float x = Random.Range(-4, 4);
        GameObject obstacleSpawn = Instantiate(obstacleGenerate[Random.Range(0, obstacleGenerate.Length)],
               new Vector3(x, 1.00f, lastSpawn.transform.position.z + z), Quaternion.identity, transform);
        lastSpawn = obstacleSpawn;
    }
    float PlayerDistanceFormLastSpawnObject =>lastSpawn.transform.position.z-
        playerRef.transform.position.z;
    public float CheckEndPointDistance => startPoint.position.z - playerTrans.position.z;
}
