using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClankAI : MonoBehaviour
{
    Animator m_Animator;
    NavMeshAgent ClankAgent;
    public float runSpeed;
    public GameObject[] AISeekSpots;
    public GameObject CurrentTarget;

    private bool isWalking;
    private bool isRunning;
    private float turnRight;


    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>(); // gets animator component
        ClankAgent = GetComponent<NavMeshAgent>();
        turnRight = 90;
    }

    // Update is called once per frame
    void Update()
    {
        runSpeed = m_Animator.speed;
        ClankAgent.SetDestination(CurrentTarget.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //switch (other.ToString())
        //{
        //    case "TLSeekSpot":
        //        {
        //            //ClankAgent.SetDestination(AISeekSpots[1].transform.position);
        //            CurrentTarget = AISeekSpots[1];
        //        }
        //        break;
        //    case "TRSeekSpot":
        //        {
        //            //ClankAgent.SetDestination(AISeekSpots[2].transform.position);
        //            CurrentTarget = AISeekSpots[2];
        //        }
        //        break;
        //    case "BRSeekSpot":
        //        {
        //            //ClankAgent.SetDestination(AISeekSpots[3].transform.position);
        //            CurrentTarget = AISeekSpots[3];
        //        }
        //        break;
        //    case "BLSeekSpot":
        //        {
        //            //ClankAgent.SetDestination(AISeekSpots[0].transform.position);
        //            CurrentTarget = AISeekSpots[0];
        //        }
        //        break;
        //    default:
        //        break;
        //}

        if(other.ToString() == "TLSeekSpot")
            CurrentTarget = AISeekSpots[1];

        if(other.ToString() == "TRSeekSpot")
            CurrentTarget = AISeekSpots[2];

        if(other.ToString() == "BRSeekSpot")
            CurrentTarget = AISeekSpots[3];

        if(other.ToString() == "BLSeekSpot")
            CurrentTarget = AISeekSpots[0];


        if (other.tag == "WalkAI")
        {
            //gameObject.transform.SetPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, turnRight, 0));
            m_Animator.SetBool("isRunning", false);
            m_Animator.SetBool("isWalking", true);
        }
        if(other.tag == "RunAI")
        {
            //gameObject.transform.SetPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, turnRight, 0));
            m_Animator.SetBool("isWalking", false);
            m_Animator.SetBool("isRunning", true);
        }
    }
}
