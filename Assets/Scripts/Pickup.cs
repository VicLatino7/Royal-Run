using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string playerString = "Player"; // Tag for the player object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            // Handle pickup logic here (e.g., increase score, play sound, etc.)
            Debug.Log("Pickup collected by: " + other.gameObject.name);
            Destroy(gameObject); // Destroy the pickup object after collection
        }
    }
}
