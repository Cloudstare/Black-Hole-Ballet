using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerJump = 10.0f;
    private Rigidbody2D rb;
    private bool isRigidbody = false;
    public GameObject blackHolePrefab;
    private GameObject currentBlackHole;
    private Animator animator;
    private bool isGrounded;
    private float horizontalD;
    void Start()
    {
        //Get the Animator component from the object
        animator = GetComponent<Animator>();
        //Check if the object has a Rigidbody2D component
        isRigidbody =  TryGetComponent<Rigidbody2D>(out rb);
        //Freeze rotation of the player
        if(isRigidbody){
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void Update()
    {
        horizontalD = Input.GetAxis("Horizontal");

        Move();
        Jump();
        BlackHole();
        animator.SetBool("run", horizontalD != 0);
        animator.SetBool("onground", isGrounded);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Move(){
        // Flip the player depending on the direction
        if(horizontalD > 0.01f){
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if(horizontalD < -0.01f){
            transform.localScale = new Vector3(-2, 2, 1);
        }

        if( isRigidbody && horizontalD != 0)
        {
            // Set the velocity vector (horizontalD ranges from -1 to 1, and playerSpeed is the player's speed set in the inspector)
            rb.velocity = new Vector2(horizontalD * playerSpeed, rb.velocity.y);
        }
    }

    private void Jump(){
        //Check if the player is on the ground to jump
        if( isRigidbody && Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerJump);
            isGrounded = false;
        }
    }

    private void BlackHole(){
        //If the player clicks the left mouse button, create a black hole at the mouse position
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Input.mousePosition;
            // Convert the mouse position to world space
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Ignore the Z coordinate
            worldPosition.z = 0;

            // Destroy the current black hole if it exists
            if (currentBlackHole != null)
            {
                Destroy(currentBlackHole);
            }
            
            // Create an instance of the black hole at the mouse position and save a reference to it
            currentBlackHole = Instantiate(blackHolePrefab, worldPosition, Quaternion.identity);
        }

        if( Input.GetMouseButtonDown(1) && currentBlackHole != null)
        {
            Destroy(currentBlackHole);
            currentBlackHole = null;
        }
    }

}
