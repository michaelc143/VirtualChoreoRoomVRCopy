using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform startMarker; // Starting point
    public Transform endMarker;   // Ending point
    public float speed = 1.0f;    // Speed of movement

    private float startTime;
    private float journeyLength;

    void Start()
    {
        // Record the start time and calculate the journey length
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        // Calculate the distance covered
        float distCovered = (Time.time - startTime) * speed;

        // Calculate the fraction of journey completed
        float fracJourney = distCovered / journeyLength;

        // Move the object using Lerp
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

        // If the object has reached the destination
        if (fracJourney >= 1.0f)
        {
            // Optionally, do something when the movement is complete
            Debug.Log("Movement Complete");
        }
    }
}
