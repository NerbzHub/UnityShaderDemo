using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosalesAnimController : MonoBehaviour
{
    Animator m_Animator;
    //int m_AnimState = 0;
    private int AnimState;
    public float walkSpeed;
    private float m_speed;
    private float m_horizontalSpeed;
    private bool isWalking;
    private bool isRunning;



    // I need to create a variable that is changed by the input
    // Then assign the variable into the set float.

    // Use this for initialization
    void Awake()
    {
        m_Animator = GetComponent<Animator>(); // gets animator component
    }

    // Update is called once per frame
    void Update()
    {

        m_speed = Mathf.Clamp(m_speed, -1, 1);
        m_horizontalSpeed = Mathf.Clamp(m_horizontalSpeed, -1, 1);

        m_Animator.SetFloat("speed", m_speed);
        m_Animator.SetFloat("horizontalSpeed", m_horizontalSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            m_speed += walkSpeed;
            m_Animator.SetBool("isWalking", true);
            //m_Animator.SetFloat("speed", m_speed);
        }
        else
        {
            m_Animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_speed -= walkSpeed;
            m_Animator.SetBool("isWalking", true);
            //m_Animator.SetFloat("speed", m_speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_horizontalSpeed += walkSpeed;
            m_Animator.SetBool("isWalking", true);
            //m_Animator.SetFloat("horizontalSpeed", m_horizontalSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_horizontalSpeed -= walkSpeed;
            m_Animator.SetBool("isWalking", true);
           // m_Animator.SetFloat("horizontalSpeed", m_horizontalSpeed);
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

        //if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
        //{
        //    m_Animator.SetFloat("speed", 0);
        //}

        //if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        //{
        //    m_Animator.SetFloat("horizontalSpeed", 0);
        //}
    }

    private void FixedUpdate()
    {
    }
}
