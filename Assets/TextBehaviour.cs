using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshPro txt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "+" + HY_Obstacle.instance.pointToUpdate.ToString();
        Destroy(gameObject, 0.4f);
    }
}
