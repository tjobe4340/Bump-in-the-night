using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // The prefab of the object you want to spawn.
    public float spawnInterval = 5f;  // The time interval between spawns.
    public int maxObjects = 3;       // The maximum number of objects to spawn.

    private int currentObjects = 0;

    private void Start()
    {
        // Start spawning objects with the specified interval.
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)  // Infinite loop to keep spawning objects.
        {
            if (currentObjects < maxObjects)
            {
                // Wait for the specified spawnInterval.
                yield return new WaitForSeconds(spawnInterval);

                // Spawn a new object.
                SpawnNewObject();
            }
            else
            {
                yield return null;  // Wait for a frame if the maxObjects limit is reached.
            }
        }
    }

    void SpawnNewObject()
    {
        // Calculate a random position within a specific range.
        Vector3 spawnPosition = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),  // Set the Y position where you want to spawn the objects.
            0//Random.Range(-10f, 10f)
        );

        // Instantiate the object at the random position.
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        currentObjects++; // Increment the count of spawned objects.
        Debug.Log(currentObjects);
    }

    // You can call this method when an object is destroyed to decrement the count.
    public void ObjectDestroyed()
    {
        currentObjects--;
    }
}
