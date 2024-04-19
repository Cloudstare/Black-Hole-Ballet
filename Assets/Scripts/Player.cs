using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerJump = 10.0f;

    private Rigidbody2D rb;
    private bool isRigidbody = false;

    public GameObject blackHolePrefab; // Przypisz w inspektorze prefabrykat czarnej dziury
    private GameObject currentBlackHole;

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

        if (Input.GetMouseButtonDown(0)) // 0 oznacza lewy przycisk myszy
        {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Ignoruj współrzędną Z
        worldPosition.z = 0;

        // Jeśli istnieje obecna czarna dziura, zniszcz ją
        if (currentBlackHole != null)
        {
            Destroy(currentBlackHole);
        }

        // Tworzy instancję czarnej dziury na pozycji myszki i zapisuje referencję do niej
        currentBlackHole = Instantiate(blackHolePrefab, worldPosition, Quaternion.identity);
        }

        if( Input.GetMouseButtonDown(1) && currentBlackHole != null)
        {
            Destroy(currentBlackHole);
            currentBlackHole = null;
        }

        
    }
}
