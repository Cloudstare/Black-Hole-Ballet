using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   public Transform target;       // Reference to the player's transform
    public Vector3 offset;         // Offset from the player's position
    public float smoothSpeed = 0.125f; // Adjusts how smooth the camera movement is

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            // Lock the Z position
            desiredPosition.z = transform.position.z;
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
