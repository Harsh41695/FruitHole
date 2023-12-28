using Unity.VisualScripting;
using UnityEngine;

public class HY_Obstacle : MonoBehaviour
{
    public static HY_Obstacle instance;
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float veloFoce = 15, rigdForce=15,maxYDis=3;
    GameObject player;
    public float  pointToUpdate=1;
    //float time = 0;
   // bool magnetFunctionActive=false;
    [SerializeField]
    AudioClip fallSound;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("HY_Player");
    }
    private void Update()
    {

        DeadCheck();
        MissedTOCollect();
        #region MagnetCode not using now
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    magnetFunctionActive=true;
        //}
        //if (magnetFunctionActive==true)
        //{
        //    time += Time.deltaTime;
        //    if (time < 2)
        //    {
        //        MagnetFunc();
        //    }
        //}
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HY_Player")
        {
            rb.AddForce(new Vector3(transform.position.x, -rigdForce, transform.position.z));
            transform.RotateAround(player.transform.position,Vector3.forward,90*Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,
                HY_PlayerMovements.instance.attractObject.position, veloFoce);
        }
    }// Attraction Behaviour.
   
    public float GetDistance()
    {
        return transform.position.z-player.transform.position.z;
    }
   
    void DeadCheck()
    {
        if (transform.position.y <= -maxYDis)
        {
            // print("deadCheckCalled");
            HY_HoleBehaviour.instance.AddPoint(pointToUpdate);
            HY_AudioManager.instance.PlayAudioEffectOnce(fallSound);
            ObjectCollectionPointAdd(gameObject.tag);
            HealthyFoodCount();
            UnhealthyFoodCount();
            Destroy(gameObject);
        }   
    }
    void MagnetFunc()
    {
        transform.position = Vector3.Lerp(transform.position,
            HY_PlayerMovements.instance.attractObject.position,0.2f);

    }
    void MissedTOCollect()
    {
        if (GetDistance() < -10)
        {
            Destroy(gameObject);
            //Missed Sound
        }
    }
    public void ObjectCollectionPointAdd(string objectTag)
    {
        
        switch (objectTag)
        {
            case "Apple":
                GameManager.instance.appleCout++;
                break;
            case "Banana":
                GameManager.instance.bananaCount++;
                break;
            case "Burger":
                GameManager.instance.burgerCount++;
                break;
            case "Cupcake":
                GameManager.instance.cupCakeCount++;
                break;
            case "Watermelon":
                GameManager.instance.WatermelonCount++;
                break;
            case "Orange":
                GameManager.instance.orangeCount++;
                break;
            //case "Donut":
            //    GameManager.instance.appleCout++;
            //    break;
            //case "Tomato":
            //    GameManager.instance.appleCout++;
            //    break;

        }
    }
    void HealthyFoodCount()
    {
        if (gameObject.tag == "Apple" || gameObject.tag == "Banana" || gameObject.tag == "Orange"
                || gameObject.tag == "Watermelon" || gameObject.tag == "Tomato")
        {
            HY_UIManager.instance.healthyFood++;
        }
    }
    private void UnhealthyFoodCount()
    {
        if (gameObject.tag == "Burger" || gameObject.tag == "Cupcake"||gameObject.tag=="CandyBox")
        {
            HY_UIManager.instance.unHealthyFood++;
        }
    }
}
