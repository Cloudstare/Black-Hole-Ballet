using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float pullForce = 10.0f;
    public float pullRadius = 5.0f;
    void FixedUpdate()
    {
        // Pobiera obiekt gracza
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Pobiera komponent Rigidbody2D z obiektu gracza
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Wektor kierunku od gracza do czarnej dziury
                Vector2 direction = (Vector2)transform.position - playerRb.position;
                // Oblicza odległość między graczem a czarną dziurą
                float distance = direction.magnitude;

                // Sprawdza, czy gracz jest w zasięgu oddziaływania czarnej dziury
                if (distance > 0 && distance < pullRadius)
                {

                    // Oblicza siłę przyciągania tak że, im bliżej gracz jest do czarnej dziury, tym większa siła przyciągania. Używamy współczynnika ((pullRadius - distance) / pullRadius) aby uzyskać ten efekt
                    float forceMagnitude = pullForce * ((pullRadius - distance) / pullRadius);
                    // Oblicza siłę przyciągania
                    Vector2 force = direction.normalized * forceMagnitude;
                    // Dodaje siłę przyciągania do gracza
                    playerRb.AddForce(force);
                }
            }
        }
    }
}
