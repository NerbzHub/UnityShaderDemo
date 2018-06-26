/*
    CameraLookAt.cs
    
    Purpose: This script is to have a stable camera that can
            follow the player and look at it without inheriting
            the rotation of the character's animation. I created
            this script for a different game but I brought it in
            and editted it to suit this project more.

    @author Nathan Nette
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    // Transform for the target that the camera is looking at.
    public Transform character;

    // A float for the distance that the camera will sit away from the target.
    public float distance = 6.4f;

    // A float to change the height away that the camera will sit away from the target.
    public float height = 1.4f;

    // A float to store the damping of rotation
    public float rotationDamping = 3.0f;

    // A float to store the damping of the height.
    public float heightDamping = 2.0f;

    // A float to change how zoomed in the camera is.
    public float zoomRatio = 0.5f;

    // A float to store the FOV of the camera.
    public float defaultFOV = 60f;

    // A vec3 to store the rotation of the camera.
    private Vector3 rotationVector;

    // Called every frame.
    void Update()
    {
        // If the character exists, do this.
        if (character != null)
        {
            // The angle we want to get to = the y of the rotationVector.
            float wantedAngle = rotationVector.y;

            // The height we want  = the character's position + height.
            float wantedHeight = character.position.y + height;

            // myAngle = eulerAngles.y.
            float myAngle = transform.eulerAngles.y;

            // myHeight = the camera's position's y.
            float myHeight = transform.position.y;

            // The Combination between these next two lines of code creates a smooth transition
            //  for the camera to move in to the character.
            myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
            myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Set the current rotation of the camera to my angle on the y.
            Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);

            // Set the position of the camera to the character's position 
            // with an offset of the distance.
            // And ensure that the camera is looking at the character.
            transform.position = character.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            Vector3 temp = transform.position;
            temp.y = myHeight;
            transform.position = temp;

            // Camera looks at the character.
            transform.LookAt(character);
        }
    }
}
