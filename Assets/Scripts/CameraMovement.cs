using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 targetPosition;
    
    private float distance;

    public float speed;

    private void Awake()
    {
        player = GameObject.Find("Player");
        distance = 10;
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
