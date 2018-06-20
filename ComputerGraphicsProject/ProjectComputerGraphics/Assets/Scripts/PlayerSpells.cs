using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject fireBall;
    public float delayForShoot;
    public float shootPower;
    //private float timer;

    // Use this for initialization
    void Start()
    {

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
        GameObject fireball = Instantiate(fireBall, gameObject.transform.forward, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootPower, ForceMode.Impulse);
    }
}
