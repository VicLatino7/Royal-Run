using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Detected with: " + other.gameObject.name);
    }
}
