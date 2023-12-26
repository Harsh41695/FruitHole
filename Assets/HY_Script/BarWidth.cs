using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarWidth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    RectTransform bar;
    //float width;
    float rand;
    [SerializeField]
    float maxImgScale=100;
    [SerializeField]
    GameObject obj;
    void Start()
    {
        obj.SetActive(false);
        bar.transform.localScale = new Vector3(0,1,1);
    }

    // Update is called once per frame
    void Update()
    {
         rand = Random.Range(2,4);
        if (Input.GetKeyDown(KeyCode.D))
        {
            bar.transform.localScale += new Vector3(rand, 0, 0);
            if (bar.transform.localScale.x >= maxImgScale)
            {
                bar.transform.localScale = new Vector3(maxImgScale, transform.localScale.y,transform.localScale.z);
            }

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            bar.transform.localScale -= new Vector3(rand, 0, 0);
            if (bar.localScale.x <= 0)
            {
                bar.transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);

            }
        }

        if (bar.transform.localScale.x >= 100)
        {
            obj.SetActive(true);
        }

      


    }
}
