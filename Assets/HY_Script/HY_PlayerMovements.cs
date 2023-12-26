using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_PlayerMovements : MonoBehaviour
{
    public static HY_PlayerMovements instance;
    [SerializeField]
    public Joystick joystickInput;
    [SerializeField]
    float playerMoveSpeed = 10f;
    public bool canRun = true;
    
    public Transform attractObject;
   
    //[SerializeField]
    //float velocityForce=10;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(joystickInput == null)
        {
            Debug.Log("Missing Joystick for input");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canRun)
        {
            if(joystickInput.Horizontal>=0.2|| joystickInput.Horizontal <=- 0.2 )
            {
                transform.position += (transform.right * joystickInput.Horizontal)
                     .normalized * playerMoveSpeed * Time.deltaTime;
            }
           
        }
      
        if (transform.position.x > 5.5)
        {
            transform.position = new Vector3(5.5f,transform.position.y,transform.position.z);
        }
        if (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(-5.5f, transform.position.y, transform.position.z);

        }
        if (transform.localScale.x >= 5&& transform.position.x>4)
        {
            transform.position = new Vector3(4f, transform.position.y, transform.position.z);
        }
        if (transform.localScale.x >= 5 && transform.position.x < -4)
        {
            transform.position = new Vector3(-4f, transform.position.y, transform.position.z);
        }

    }
    

}
