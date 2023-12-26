using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_PlayAnimation : MonoBehaviour
{
    Animator m_Animator;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.isVictory == true)
        {
            m_Animator.SetFloat("Blend", 0.5f);
        }
        else if(GameManager.instance.isDefeat == true)
        {
            m_Animator.SetFloat("Blend",1f);
        }
        else
        {
            m_Animator.SetFloat("Blend", 0);
        }
    }
}
