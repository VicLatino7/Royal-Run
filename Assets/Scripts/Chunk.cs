using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;

    [SerializeField] float[] lanes = {-4.15f, -1.21f,1.71f};

    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        int randomLaneIndex = Random.Range(0, lanes.Length);
        Vector3 spawnPosition = new Vector3(lanes[randomLaneIndex], transform.position.y, transform.position.z);
        Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
}
