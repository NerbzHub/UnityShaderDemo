using UnityEngine;

public class AnimController : MonoBehaviour
{

    Animator m_Animator;
    //int m_AnimState = 0;
    private int AnimState;
    private bool isWalking;
    private bool isRunning;

    // Use this for initialization
    void Start()
    {

        m_Animator = GetComponent<Animator>(); // gets animator component

        //m_Animator.SetInteger(m_AnimState, 0); //sets state to 0 at beginning

        //AnimState = m_Animator.GetInteger(AnimState);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D))
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


        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{

        //    m_Animator.SetInteger("AnimState", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{

        //    m_Animator.SetInteger("AnimState", 1);

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{

        //    m_Animator.SetInteger("AnimState", 2);

        //}

    }
}
