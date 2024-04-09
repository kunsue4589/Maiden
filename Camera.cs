using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's position the camera will follow.

    public float smoothSpeed = 0.125f; //Smoothness of camera movement
    public Vector3 offset; // Distance between camera and player

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; //Where the camera wants to be
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //Calculate the importance of the position
        transform.position = smoothedPosition; //Move the camera to the calculated position.
    }
}

