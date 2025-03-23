using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;   // Offset distance between the camera and the player

    void Start()
    {
        // Optionally, set an initial offset
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Update the camera's position to stay at a fixed offset from the player
        transform.position = player.position + offset;
    }
}
