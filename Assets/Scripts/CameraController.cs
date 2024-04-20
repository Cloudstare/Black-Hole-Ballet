using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float yOffset;
    public float xOffset;
    public float lerpAmount;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
{
    float x = player.transform.position.x;
    float y = player.transform.position.y + yOffset;
    float direction = player.transform.localScale.x;
    Vector3 targetPosition = new Vector3(x, y, gameObject.transform.position.z);
    Vector3 offset = new Vector3(xOffset * Mathf.Sign(direction), 0, 0);
    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition + offset, lerpAmount);
}
}
