using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_PlatformMaterialChange : MonoBehaviour
{
    [SerializeField]    
    Material[] material;
    [SerializeField]
    MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        int rnd = Random.Range(0, material.Length);
        meshRenderer.material = material[rnd];
    }

    
}
