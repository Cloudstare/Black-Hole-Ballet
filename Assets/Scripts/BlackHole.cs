using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour
{
    public float lifeTime = 1.0f;
    public float pullForce = 20.0f;
    public float pullRadius = 5.0f;
    public float orbitRadius = 1.0f; // Zmienna do ustawiania wielkości orbity w edytorze Unity
    public float orbitSpeedOffset = 1.0f; // Zmienna do ustawiania offsetu prędkości orbity w edytorze Unity
    public float maxPullForce = 50.0f; // Zmienna do ustawiania maksymalnej siły przyciągania
    private bool isInOrbit = false;
    private Vector2 entryVelocity;

    private void Start()
    {
        // Uruchom coroutine, która usunie czarną dziurę po 2 sekundach
        StartCoroutine(DestroyBlackHoleAfterDelay(lifeTime));
    }

    private IEnumerator DestroyBlackHoleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
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

                // Calculate the pull force based on the distance from the black hole. The closer the player is to the black hole, the stronger the pull force. We use the coefficient ((pullRadius - distance) / pullRadius) to achieve this effect
                float forceMagnitude = pullForce * ((pullRadius - distance) / pullRadius) * 2.0f; // Increase the pull force
                // Limit the pull force to the maximum value
                forceMagnitude = Mathf.Min(forceMagnitude, maxPullForce);
                // Calculate the force vector
                Vector2 force = direction.normalized * forceMagnitude;
                // Add the pull force to the player
                playerRb.AddForce(force);

                // Check if the player is very close to the black hole to enter a stable orbit
                if (distance < orbitRadius)
                {
                    if (!isInOrbit)
                    {
                        isInOrbit = true;
                        entryVelocity = playerRb.velocity; // Save the entry velocity
                    }
                    else
                    {
                        // Determine the direction of the orbit based on the player's position relative to the black hole
                        Vector2 tangentialDirection = Vector2.Perpendicular(direction).normalized;
                        if (Vector2.Dot(playerRb.velocity, tangentialDirection) < 0)
                        {
                            tangentialDirection = -tangentialDirection;
                        }
                        // Calculate the tangential force for a stable orbit
                        Vector2 tangentialForce = tangentialDirection * (entryVelocity.magnitude + orbitSpeedOffset);
                        // Add the tangential force to the player
                        playerRb.AddForce(tangentialForce);
                    }
                }
                else
                {
                    isInOrbit = false;
                }
            }
        }
    }
}