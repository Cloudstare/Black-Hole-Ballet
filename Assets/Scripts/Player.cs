using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerJump = 10.0f;

    private Rigidbody2D rb;
    private bool isRigidbody = false;
    // Start is called before the first frame update
    void Start()
    {
       isRigidbody =  TryGetComponent<Rigidbody2D>(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        float Hdirection;

        if( isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            rb.velocity = new Vector2(Hdirection * playerSpeed, rb.velocity.y);
        }

        if( isRigidbody && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, playerJump);
        }
    }
}
