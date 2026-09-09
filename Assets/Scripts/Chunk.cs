using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;
    [SerializeField] float coinSeperationLength = 2f;

    [SerializeField] float[] lanes = {-4.15f, -1.21f, 1.71f};

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
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

    void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0) return; // Check if we should spawn a coin based on the spawn chance
        if(availableLanes.Count <= 0) return;

        int selectedLane = SelectLane(); // Select a lane for the coin

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn); // Randomly determine how many coins to spawn (1 to 5)

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++) // Loop to spawn coins
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeperationLength); // Calculate the Z position for each coin based on the separation length
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);   
        
        }
            

    }
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
