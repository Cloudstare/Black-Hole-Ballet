using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Vector3 offset = new Vector3(0, 1, 0);
    [SerializeField] private float lookAheadDistance = 2;
    [SerializeField] private float lookAheadSpeed = 1;
    [SerializeField] private float stopTime = 0.5f;

    private Vector3 velOffset;
    private Vector3 vel;
    private Vector3 lookAheadVel;
    private bool isMoving;
    private float moveThreshold = 0.1f;
    private float stopTimer;

    private void Update()
    {
        if (player != null && Vector3.Distance(player.position, transform.position) > moveThreshold)
        {
            isMoving = true;
            stopTimer = stopTime;
        }
        else if (isMoving)
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                isMoving = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (player != null && isMoving)
        {
            var projectedPos = player.position + player.right * lookAheadDistance;
            velOffset = Vector3.SmoothDamp(velOffset, projectedPos - player.position, ref lookAheadVel, lookAheadSpeed * Time.deltaTime);

            Step(smoothTime);
        }
        else
        {
            Step(smoothTime * 2); // Continue moving the camera for a short while after the player stops
        }
    }

    private void OnValidate() => Step(0);

    private void Step(float time)
    {
        var goal = player.position + offset + velOffset;
        goal.z = -10;
        transform.position = Vector3.SmoothDamp(transform.position, goal, ref vel, time);
    }
}