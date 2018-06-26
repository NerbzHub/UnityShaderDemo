/*
    RosalesAnimController.cs
    
    Purpose: This script is the animation controller for
            the playable character in the scene. I wanted to
            explore using root motion and let the animation 
            do the movement, rather than sync up adding the right
            amount of force to a rigidbody so that it looks real.

            Because of this, this script is now my Player Controller.

    @author Nathan Nette
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is basically a player controller due to using root motion.
 */
public class RosalesAnimController : MonoBehaviour
{
    // Get an instance of animator to later cache the character's animator into.
    Animator m_Animator;

    // The speed that she is walking at. This is used for animation blending
    // and smoothness between different animations.
    public float walkSpeed;

    // The current forward/back speed that the character is moving at.
    private float m_speed;

    // The current left/right speed that the character is moving at.
    private float m_horizontalSpeed;

    // A bool to set whether the character is walking or not.
    private bool isWalking;

    // A bool to set whether the character is running or not.
    private bool isRunning;

    // Use this for initialization.
    void Awake()
    {
        // Cache the animator component.
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Clamp the speed of the player to between -1 and 1 for animation purposes.
        m_speed = Mathf.Clamp(m_speed, -1, 1);

        // Clamp the horizontal speed of the player to between -1 and 1 for animation purposes.
        m_horizontalSpeed = Mathf.Clamp(m_horizontalSpeed, -1, 1);

        // Set the float for the speed on the animator to the current speed of the character.
        m_Animator.SetFloat("speed", m_speed);

        // Set the float for the horizontal speed on the animator to the current speed of the character.
        m_Animator.SetFloat("horizontalSpeed", m_horizontalSpeed);

        // If the W key is pressed, increase the current speed by the walkSpeed and set isWalking to true.
        if (Input.GetKey(KeyCode.W))
        {
            m_speed += walkSpeed;
            m_Animator.SetBool("isWalking", true);
        }
        // Otherwise, set is walking to false.
        else
        {
            m_Animator.SetBool("isWalking", false);
        }

        // If the S key is pressed, decrease the current speed by the walkSpeed and set isWalking to true.
        if (Input.GetKey(KeyCode.S))
        {
            m_speed -= walkSpeed;
            m_Animator.SetBool("isWalking", true);
        }

        // If the D key is pressed, increase the current horizontalSpeed by the walkSpeed and set isWalking to true.
        if (Input.GetKey(KeyCode.D))
        {
            m_horizontalSpeed += walkSpeed;
            m_Animator.SetBool("isWalking", true);
        }

        // If the A key is pressed, decrease the current horizontalSpeed by the walkSpeed and set isWalking to true.
        if (Input.GetKey(KeyCode.A))
        {
            m_horizontalSpeed -= walkSpeed;
            m_Animator.SetBool("isWalking", true);
        }

        // If left shift is held, the character runs.
        // Set isRunning to true when left shift is held down, otherwise the player can just walk.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_Animator.SetBool("isRunning", true);
        }
        else
        {
            m_Animator.SetBool("isRunning", false);
        }

        // If the left mouse button is clicked, set bool in animator "LClickDown" to true,
        // otherwise set it to false.
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
