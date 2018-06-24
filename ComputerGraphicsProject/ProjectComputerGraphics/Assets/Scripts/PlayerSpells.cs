using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject lightning;

    public float delayForCast;
    public float castLength;

    private Rigidbody rosalesRb;
    //private float timer;

    // Use this for initialization
    void Start()
    {
        //rosalesRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Invoke("ShootFireball", delayForCast);

        }
    }

    private void ShootFireball()
    {
        lightning.SetActive(true);
        Invoke("EndOfSpell", castLength);
        
    }

    private void EndOfSpell()
    {
        lightning.SetActive(false);
    }
}
