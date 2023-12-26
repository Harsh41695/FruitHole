

using UnityEngine;
using UnityEngine.UI;

public class HY_HoleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public static HY_HoleBehaviour instance;

    [SerializeField]
    Image img,SkinImg1,SkinImg2,SkinImg3;
    [SerializeField]
    float minPoints=0, maxPoints=50;
    [SerializeField]
    float playerYAxis;
    [SerializeField]
    float size=0.7f;
   [SerializeField] float resizeScore=0;
    int updatePoint;
    float time;
    [SerializeField]
    Transform aPoint, bPoint;
    public Transform targetPos;
    [SerializeField]
    float leftRightMoveSpeed;
    [SerializeField]
    float positiveXVal=2.5f,negativeXVal=-2.5f;
    public float currentTimeScale=1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        transform.position = new Vector3(transform.position.x,-0.069f,
            transform.position.z);
        img.fillAmount = ((float)minPoints / (float)maxPoints);
        targetPos = bPoint;
        SkinUpdater(HY_SaveSystem.instance.GetSavedData("HoleSkin"));
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
        transform.localScale = new Vector3(size, size, size);
        transform.position = new Vector3(transform.position.x, transform.position.y-0.019f,
            transform.position.z);
        Time.timeScale += 0.2f;
        currentTimeScale = Time.timeScale;
    }
    void FightTimeMovement()
    {
        //transform.position = Vector3.MoveTowards(transform.position,
        //    targetPos.position, leftRightMoveSpeed * Time.deltaTime);
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
    public void AddPoint(float points)
    {
        resizeScore += points;
        resizeScore += points;
        minPoints += points;
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
    
    void SkinUpdater(int index)
    {
        switch (index)
        {
            case 1:
                SkinImg1.gameObject.SetActive(true);
                SkinImg2.gameObject.SetActive(false);
                SkinImg3.gameObject.SetActive(false);
                break;
            case 2:
                SkinImg1.gameObject.SetActive(false);
                SkinImg2.gameObject.SetActive(true);
                SkinImg3.gameObject.SetActive(false);
                break;
            case 3:
                SkinImg1.gameObject.SetActive(false);
                SkinImg2.gameObject.SetActive(false);
                SkinImg3.gameObject.SetActive(true);
                break;
            default:
                SkinImg1.gameObject.SetActive(false);
                SkinImg2.gameObject.SetActive(false);
                SkinImg3.gameObject.SetActive(false);
                break;
        }
        HY_SaveSystem.instance.SaveData("HoleSkin", index);
    }
}
