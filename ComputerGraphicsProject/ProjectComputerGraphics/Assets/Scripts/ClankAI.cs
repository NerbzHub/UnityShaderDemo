/*
    ClankAI.cs
    
    Purpose: This simple script is just to toggle the walk and run
            animations on the clank character in the scene.
            It is to demonstrate animation blending.

    @author Nathan Nette
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    This class is to toggle the animations of the clank
        character in my scene. It is to demonstrate animation
        blending.
 */
public class ClankAI : MonoBehaviour
{
    // Cache the animator of the Clank character here.
    Animator m_Animator;

    // Use this for initialization
    void Start()
    {
        // Caching of the animator.
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Every 2 seconds, invoke the toggle function.
        InvokeRepeating("WalkRunToggle", 2f, 2f);
    }

    /*
        WalkRunToggle toggles to the opposite animation.
            if one is being played, play the other one.
            This is only called when invoked.
    */
    void WalkRunToggle()
    {
        if (!m_Animator.GetBool("isRunning"))
        {
            m_Animator.SetBool("isWalking", false);
            m_Animator.SetBool("isRunning", true);

        }
        else if (m_Animator.GetBool("isRunning"))
        {
            m_Animator.SetBool("isRunning", false);
            m_Animator.SetBool("isWalking", true);
        }
    }
}
