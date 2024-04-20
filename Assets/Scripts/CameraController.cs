using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float yOffset;
    public float xOffset;
    public float lerpAmount;
    private GameObject player;
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //Get the player's position
        float x = player.transform.position.x;
        // Dodaje przesunięcie w osi Y
        float y = player.transform.position.y + yOffset;
        //Get the direction the player is facing
        float direction = player.transform.localScale.x;
        //Calculate the camera position
        Vector3 targetPosition = new Vector3(x, y, gameObject.transform.position.z);
        //Calculate the camera offset based on the direction the player is facing
        Vector3 offset = new Vector3(xOffset * Mathf.Sign(direction), 0, 0);
        //Set the camera position using Lerp to get a smooth camera movement effect
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition + offset, lerpAmount);
    }
}
