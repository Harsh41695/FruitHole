using UnityEngine;
using UnityEngine.UI;

public class HY_PlatformMovement : MonoBehaviour
{
    public static HY_PlatformMovement instace;
    //[SerializeField]
    //Button settingBtn;
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }

    public  float fwdSpeed = 5;

    void LateUpdate()
    {
        if (GameManager.instance.canRun == true)
        {
            transform.position += new Vector3(0, 0, -1) * fwdSpeed * Time.deltaTime;
            //settingBtn.gameObject.SetActive(false);
        }

    }
   
}
