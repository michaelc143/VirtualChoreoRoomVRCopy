using UnityEngine;

public class DestroyOnCubeCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Duplicate"
        if (collision.gameObject.CompareTag("Duplicate"))
        {
            // Destroy the GameObject that collided
            Destroy(collision.gameObject);
        }
    }
}
