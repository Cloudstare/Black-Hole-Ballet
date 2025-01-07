using UnityEngine;

public class BlackHole2 : MonoBehaviour
{
    [SerializeField] private float gravitationalForce = 10f;
    [SerializeField] private float orbitRadius = 2f;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
    {
        Debug.Log("Gracz jest w zasięgu czarnej dziury.");
    }
    
        if (other.TryGetComponent(out Rigidbody2D rb))
        {
            Vector2 direction = (Vector2)transform.position - rb.position;
            float distance = direction.magnitude;

            if (distance > orbitRadius)
            {
                // Przyciąganie gracza do czarnej dziury
                Vector2 force = direction.normalized * gravitationalForce / (distance * distance);
                rb.AddForce(force);
            }
            else
            {
                // Zapewnienie orbitowania
                Vector2 tangent = Vector2.Perpendicular(direction).normalized;
                rb.velocity = tangent * rb.velocity.magnitude;
            }
        }
    }
}
