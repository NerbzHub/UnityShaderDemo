using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosalesAnimController : MonoBehaviour
{
    Animator m_Animator;
    //int m_AnimState = 0;
    private int AnimState;
    private float m_speed;
    private bool isWalking;
    private bool isRunning;

    // Use this for initialization
    void Awake()
    {
        m_Animator = GetComponent<Animator>(); // gets animator component
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            m_Animator.SetBool("isWalking", true);
        }
        else
        {
            m_Animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_Animator.SetBool("isRunning", true);
        }
        else
        {
            m_Animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_Animator.SetBool("LClickDown", true);
        }
        else
        {
            m_Animator.SetBool("LClickDown", false);

        }
    }
}
