using UnityEngine;
using UnityEngine.UI;

public class HY_HoleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public static HY_HoleBehaviour instance;

    [SerializeField]
    Image img;
    [SerializeField]
    float minPoints=0, maxPoints=50;
    [SerializeField]
    float playerYAxis;
    [SerializeField]
    float size=0.7f;
    [SerializeField] float resizeScore = 0;
    //float time;
    public Transform targetPos;
    [SerializeField]
    float leftRightMoveSpeed;
    [SerializeField]
    float positiveXVal=2.5f,negativeXVal=-2.5f;
    public float currentTimeScale=1;
    float powerLevel=0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        transform.localScale = new Vector3(size, size, size);
        transform.position = new Vector3(transform.position.x,-0.128f,
            transform.position.z);
        img.fillAmount = ((float)minPoints / (float)maxPoints);
       
        //SkinUpdater(HY_SaveSystem.instance.GetSavedData("HoleSkin"));
        currentTimeScale = 1;
    }
    private void Update()
    {
        if (HY_UIManager.instance.leftRightMovementActive == true)
        {
            FightTimeMovement();

        }
    }
    public void ChangeSize()
    {
       
        if (transform.localScale.y <= 2.5)
        {
            minPoints = 0;
            transform.localScale = new Vector3(size, size, size);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.019f,
                transform.position.z);

        }
        Time.timeScale += 0.3f;
        currentTimeScale = Time.timeScale;
    }
    void FightTimeMovement()
    {
       
        transform.position += Vector3.right * leftRightMoveSpeed * Time.deltaTime;
        if (transform.position.x >= positiveXVal)
        {
            transform.position = new Vector3(positiveXVal,
                transform.position.y, transform.position.z); 
            leftRightMoveSpeed *= -1;
        }
        if (transform.position.x <= negativeXVal)
        {
            transform.position = new Vector3(negativeXVal, transform.position.y,
                transform.position.z);
            leftRightMoveSpeed *= -1;
        }
    }
    public void IncreacePowerLevel(float power)
    {
        powerLevel += power;
    }
    public void AddPoint(float points)
    {
        resizeScore += (points+powerLevel);
        resizeScore += (points + powerLevel);
        minPoints += (points + powerLevel);
        img.fillAmount = (minPoints /maxPoints);

        if (minPoints >= maxPoints)
        {
            
            if (transform.localScale.y <= 2.5)
            {
                minPoints= 0;
                size+=0.3f;
                ChangeSize();
               // print(size);
               
            }
           
        }
    }
    public void IncreaseSizeFromReward()
    {
        size += 0.5f;
        ChangeSize();
    }
}
