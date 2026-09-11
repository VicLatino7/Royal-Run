using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f; // Speed of rotation in degrees per second
    const string playerString = "Player"; // Tag for the player object

    void Update()
    {
        // Rotate the pickup object
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            // Handle pickup logic here (e.g., increase score, play sound, etc.)
            // Debug.Log("Pickup collected by: " + other.gameObject.name);
           OnPickup(); // Call the abstract method for specific pickup behavior
           Destroy(gameObject); // Destroy the pickup object after collection
        }
    }

    protected abstract void OnPickup(); // Abstract method to be implemented by derived classes for specific pickup behavior


}
