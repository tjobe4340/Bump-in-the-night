using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ShortRoomGenerator : MonoBehaviour
{
    public GameObject shortRoomPrefab; // Assign your ShortRoom prefab in the Inspector
    public int numberOfRooms = 5; // Number of ShortRooms to generate
    public float placementRadius = 10f; // Radius within which to place the rooms

    private List<GameObject> placedRooms = new List<GameObject>();

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        for (int i = 0; i < numberOfRooms; i++)
        {
            GameObject newRoom = Instantiate(shortRoomPrefab);
            newRoom.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f)); // Random Z rotation

            Vector3 randomPosition;
            bool positionFound;

            // Try to find a non-overlapping position
            do
            {
                randomPosition = new Vector3(Random.Range(-placementRadius, placementRadius), Random.Range(-placementRadius, placementRadius), 0);
                newRoom.transform.position = randomPosition;

                positionFound = !IsOverlapping(newRoom);
            } while (!positionFound);

            placedRooms.Add(newRoom);
        }
    }

    bool IsOverlapping(GameObject room)
    {
        foreach (GameObject otherRoom in placedRooms)
        {
            if (otherRoom == room)
                continue;

            Collider[] roomColliders = room.GetComponentsInChildren<Collider>();
            Collider[] otherRoomColliders = otherRoom.GetComponentsInChildren<Collider>();

            foreach (Collider col1 in roomColliders)
            {
                foreach (Collider col2 in otherRoomColliders)
                {
                    if (col1.bounds.Intersects(col2.bounds))
                        return true;
                }
            }
        }
        return false;
    }
}
