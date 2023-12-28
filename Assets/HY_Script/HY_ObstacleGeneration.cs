using System.Collections.Generic;
using UnityEngine;

public class HY_ObstacleGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] foodPrefab;
    [SerializeField]
    List<GameObject> foodObj;
    [SerializeField]
    Transform playerRef;
    //float time;
    public float time=0;
    public float tempDistace = 0;
    [SerializeField]
    Transform startPoint, endPoint,playerTrans;
    [SerializeField]
    float spwanTime=13;
    // Update is called once per frame
    private void Start()
    {
        FoodGeneration();
        playerTrans.position=new Vector3(playerTrans.position.x,playerTrans.position.y
            ,startPoint.position.z);
        
    }
    void Update()
    {
        if (GameManager.instance.canSpawn == true)
        {
            time += Time.deltaTime;
            if (CheckEndPointDistance > -730)
            {
                if (time >= spwanTime)
                {
                    FoodGeneration();
                    time = 0;

                }
            }
        }     
        tempDistace = CheckEndPointDistance;
        
    }
    private void FoodGeneration()//Replace For Loop To Distance Loogic.
    {
        float z = playerRef.transform.position.z +20;
        for (int i = 0; i<50; i++)
        {
            float rnd = Random.Range(-5.5f, 4.9f);
            Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], new Vector3(rnd, 0.4f,z),
                Quaternion.identity,transform);
            z +=5;
            
        }
        //new spawn logic.
    }
    public float CheckEndPointDistance => startPoint.position.z - playerTrans.position.z;
}
