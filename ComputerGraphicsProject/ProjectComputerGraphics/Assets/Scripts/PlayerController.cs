using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------------------------------------
// Class:
//      PlayerController: Player controller controls the player's movment and most
//                        of the interactions that the player has in the world.
//-------------------------------------------------------------------------------------
public class PlayerController : MonoBehaviour
{
    // Player's rigidbody.
    public Rigidbody m_rigidBody;

    // Rotational on the Y axis
    public float rotationSpeed;

    // Rate that the player moves at.
    public float moveSpeed;

    // Rate that the player runs at.
    public float runSpeed;

    // The maximum speed the player can go at.
    public float maxSpeed = 12.0f;

    // Able to rotate on the Y
    Vector3 m_EulerAngleVelocity;

    // Transform for behind the player
    Transform behindPlayerTransform;




    // Use this for initialization
    void Start()
    {
        //// If there is a gameobject with a rigidbody, freeze its' rotation.
        //if (gameObject.GetComponent<Rigidbody>())
        //    gameObject.GetComponent<Rigidbody>().freezeRotation = true;

        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, 100, 0);

        //behindPlayerTransform = new Transform()
    }

    //-------------------------------------------------------------------------------------
    // Update is called once per frame.
    //-------------------------------------------------------------------------------------
    void Update()
    {
        //-------------------------------------------------------------------------------------------
        //                                   Keyboard Input Movement
        //
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidBody.AddForce(new Vector3(transform.forward.x * moveSpeed, 0, transform.forward.z * moveSpeed), ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //m_rigidBody.transform.LookAt()
            //m_rigidBody.AddForce(new Vector3(-transform.forward.x * moveSpeed, 0, -transform.forward.z * moveSpeed), ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_rigidBody.AddForce(new Vector3(transform.forward.x * runSpeed, 0, transform.forward.z * runSpeed), ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //m_rigidBody.AddForce(new Vector3(transform.right.x * moveSpeed, 0, transform.right.z * moveSpeed), ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //m_rigidBody.AddForce(new Vector3(-transform.right.x * moveSpeed, 0, -transform.right.z * moveSpeed), ForceMode.Acceleration);
        }

        // Movement Cap
        if (m_rigidBody.velocity.magnitude > maxSpeed)
        {
            float f = m_rigidBody.velocity.magnitude - maxSpeed;
            m_rigidBody.AddForce(m_rigidBody.velocity * -f);
        }
        //-------------------------------------------------------------------------------------------

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            m_rigidBody.transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_rigidBody.transform.Rotate(new Vector3(0f, -rotationSpeed, 0f));
            //m_rigidBody.AddTorque(0.0f, -rotationSpeed, 0.0f, ForceMode.Acceleration);
            //Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * -rotationSpeed);
            //m_rigidBody.MoveRotation(m_rigidBody.rotation * deltaRotation);
        }
    }
}