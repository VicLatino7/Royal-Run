using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject); // Destroy the object that enters the trigger
    }
}
