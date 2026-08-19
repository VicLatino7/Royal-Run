using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;

    [SerializeField] float appleSpawnChance = 0.3f;

    [SerializeField] float[] lanes = {-4.15f, -1.21f, 1.71f};

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    void Start()
    {
        SpawnFences();
        SpawnApple();
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length); // Randomly determine how many fences to spawn (0 to 2)

        for (int i = 0; i < fencesToSpawn; i++) // Loop to spawn fences
        {
            if(availableLanes.Count <= 0) break;
            
            int selectedLane = SelectLane(); // Select a lane for the fence

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return; // Check if we should spawn an apple based on the spawn chance
        if(availableLanes.Count <= 0) return;

        int selectedLane = SelectLane(); // Select a lane for the apple

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);   
    }
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
