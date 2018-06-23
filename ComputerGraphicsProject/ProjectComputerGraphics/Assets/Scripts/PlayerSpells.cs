using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject shooterPos;
    public float delayForShoot;
    public float shootPower;
    private Rigidbody rosalesRb;
    //private float timer;

    // Use this for initialization
    void Start()
    {
        rosalesRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Invoke("ShootFireball", delayForShoot);

        }
    }

    private void ShootFireball()
    {
        GameObject fireball = Instantiate(fireBall, shooterPos.transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().AddForce(shooterPos.transform.forward * shootPower, ForceMode.Impulse);
    }
}
