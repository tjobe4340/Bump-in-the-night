using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ShortRoomGenerator : MonoBehaviour
{
    public GameObject shortRoomPrefab;
    public int numberOfRooms = 5;
    public float placementRadius = 10f;

    private Queue<GameObject> roomPool = new Queue<GameObject>();

    void Start()
    {
        InitializeRoomPool();
        GenerateRooms();
    }

    void InitializeRoomPool()
    {
        for (int i = 0; i < numberOfRooms; i++)
        {
            GameObject room = Instantiate(shortRoomPrefab);
            room.SetActive(false);
            roomPool.Enqueue(room);
        }
    }

    void GenerateRooms()
    {
        foreach (GameObject room in roomPool)
        {
            room.SetActive(false);
        }

        foreach (GameObject room in roomPool)
        {
            room.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            Vector3 randomPosition;
            bool positionFound;

            do
            {
                randomPosition = new Vector3(Random.Range(-placementRadius, placementRadius), Random.Range(-placementRadius, placementRadius), 0);
                room.transform.position = randomPosition;
                positionFound = !IsOverlapping(room);
            } while (!positionFound);

            room.SetActive(true);
        }
    }

    bool IsOverlapping(GameObject room)
    {
        foreach (GameObject otherRoom in roomPool)
        {
            if (otherRoom == room || !otherRoom.activeSelf)
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
