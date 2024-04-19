using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        Debug.Log("x: " + player.transform.position.x + " y: " + player.transform.position.y);
        Debug.Log("x: " + x + " y: " + y);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
