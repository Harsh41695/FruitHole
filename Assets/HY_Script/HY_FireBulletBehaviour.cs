using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HY_FireBulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float fwdSpeed = 2;
    [SerializeField]
    float life = 3;
    [SerializeField]
    float giveDamge=0.5f;
    [SerializeField]
    int force = 150;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * fwdSpeed * Time.deltaTime;
       gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * force * Time.deltaTime;
        Destroy(gameObject, life);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HY_Enemy")
        {
            HY_ChracterBodyShapeChange.instance.takeDamage(giveDamge);
            Destroy(gameObject);
        }
    }
   

}
