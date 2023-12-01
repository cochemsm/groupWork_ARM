using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    public float speed;
    public float distance;

    private void Awake()
    {
        player = GameObject.Find("Player");
        distance = 10;
        startPosition = new Vector3(0, 0, -distance);
    }

    private void Update()
    {
        // Look where is player
        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -distance);

        // Move to player
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, speed * Time.deltaTime);
    }
}
