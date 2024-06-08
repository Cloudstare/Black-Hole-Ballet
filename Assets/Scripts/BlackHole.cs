using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float pullForce = 20.0f;
    public float pullRadius = 5.0f;
    void FixedUpdate()
    {
        // Get the player object
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Get the Rigidbody2D component from the player object
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Calculate the direction from the player to the black hole
                Vector2 direction = (Vector2)transform.position - playerRb.position;
                // Calculate the distance between the player and the black hole
                float distance = direction.magnitude;

                // Check if the player is within the pull radius of the black hole
                if (distance > 0 && distance < pullRadius)
                {
                    // Calculate the pull force based on the distance from the black hole. The closer the player is to the black hole, the stronger the pull force. We use the coefficient ((pullRadius - distance) / pullRadius) to achieve this effect
                    float forceMagnitude = pullForce * ((pullRadius - (distance/3)) / pullRadius);
                    // Calculate the force vector
                    Vector2 force = direction.normalized * forceMagnitude;
                    // Add the pull force to the player
                    playerRb.AddForce(force);
                }
            }
        }
    }
}
