using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_NewFoodGenation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] foodForSpawn;
    public GameObject playerRef,lastSpawn;
    [SerializeField]
    float z=10;
    [SerializeField]
    Transform startPoint, endPoint, playerTrans;
    void Start()
    {
        playerTrans.position = new Vector3(playerTrans.position.x, playerTrans.position.y
           , startPoint.position.z);
        FoodGenration();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn != null && PlayerDistanceFormLastSpawnObject<150)
        {
            if (CheckEndPointDistance > -800)
            {
                FoodGenration();

            }
        }
    }

    void FoodGenration()
    {
        float x = Random.Range(-5.5f, 4.9f);
         GameObject currentSpawn = Instantiate(foodForSpawn[Random.Range(0,foodForSpawn.Length)],
            new Vector3(x, 0.4f, lastSpawn.transform.position.z+z), Quaternion.identity,transform);
        lastSpawn=currentSpawn;
        //Debug.Log(lastSpawn.transform.position.z + " Z axis", lastSpawn);
       // z += 10;
    }
    float PlayerDistanceFormLastSpawnObject =>lastSpawn.transform.position.z-
        playerRef.transform.position.z;
    public float CheckEndPointDistance => startPoint.position.z - playerTrans.position.z;
}
