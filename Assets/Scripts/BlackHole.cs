using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float pullForce = 10.0f;
    public float pullRadius = 5.0f;

    void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 direction = (Vector2)transform.position - playerRb.position;
                float distance = direction.magnitude;

                if (distance > 0 && distance < pullRadius)
                {
                    float forceMagnitude = pullForce * ((pullRadius - distance) / pullRadius);
                    Vector2 force = direction.normalized * forceMagnitude;

                    playerRb.AddForce(force);
                }
            }
        }
    }
}
