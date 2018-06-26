/*
    PlayerSpells.cs
    
    Purpose: This script controls the spell cast animation.
            The spell is a lightning that get cast when left
            mouse button is clicked. It plays an animation and
            particles spawn at the character's hands.

    @author Nathan Nette
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The Player Spells class is used to ensure that the
        animation and particles sync up.
 */
public class PlayerSpells : MonoBehaviour
{
    // Getting the lightning particle effects.
    // I'm getting them as a game object rather than
    // a particle system so that I can use the SetActive
    // function.
    public GameObject lightning;

    // A delay in seconds for the time before the particles
    // are set to active. This is due to the animation's long
    // length.
    public float delayForCast;

    // How long in seconds it is until the particles get set to inactive.
    public float castLength;

    // Use this for initialization
    void Start()
    {
        //rosalesRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // If left mouse button down, cast lightning.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Only begin the lightning after a delay.
            Invoke("ShootLightning", delayForCast);
        }
    }

    /*
        Turns on the lightning particles.
     */
    private void ShootLightning()
    {
        // Turn on the lightning particles.
        lightning.SetActive(true);

        // This turns the particles off after castLength long.
        Invoke("EndOfSpell", castLength);
        
    }

    /*
        Turns off the lightning particles.
     */
    private void EndOfSpell()
    {
        // Stops the lightning being active.
        lightning.SetActive(false);
    }
}
