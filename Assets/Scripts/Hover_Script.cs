using UnityEngine;

public class Hover_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // This is the script that allows the sprites to hover in place.
    public float amplitude = 0.5f; // Monitors how high/low it floats
    public float speed = 2.0f; // How fast it is bouncing between two points
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // This will calculate the new Y Position
        // Time ensures frames run smoothly regardless of framerate
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        // This applies the new position while keeping the X and Z positions the same
        // Will not move it in other ways except for Y position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
