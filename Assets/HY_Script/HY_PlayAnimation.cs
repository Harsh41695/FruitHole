using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_PlayAnimation : MonoBehaviour
{
    Animator m_Animator;
    int index;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        index =Random.Range(0, 3);

    }
    void Update()
    {
        if (GameManager.instance.isVictory == true)
        {
            m_Animator.SetFloat("Blend", 1.5f);
        }
        else if(GameManager.instance.isDefeat == true)
        {
            m_Animator.SetFloat("Blend",2f);
        }
        else
        {
            switch (index)
            {
                case 0:
                    m_Animator.SetFloat("Blend", 0);
                    break;
                case 1:
                    m_Animator.SetFloat("Blend", 0.5f);
                    break;
                case 2:
                    m_Animator.SetFloat("Blend", 1);
                    break;
            }

        }
    }
}
