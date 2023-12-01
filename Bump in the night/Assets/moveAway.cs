using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAwayFromPlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float safeDistance = 5f;
    public float returnDistance = 10f;
    public float randomMoveRadius = 2f;
    public float stopThreshold = 0.5f;

    private Vector3 originalPosition;
    private Vector3 randomDestination;
    private bool movingRandomly = false;

    void Start()
    {
        originalPosition = transform.position;
        SetRandomDestination();
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            player = playerGameObject.transform;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceToOriginal = Vector3.Distance(transform.position, originalPosition);

        // Move away from player
        if (distanceToPlayer < safeDistance)
        {
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;
            transform.position += directionAwayFromPlayer * moveSpeed * Time.deltaTime;
            movingRandomly = false;
        }
        // Return to original position
        else if (distanceToPlayer > returnDistance && distanceToOriginal > stopThreshold)
        {
            Vector3 directionToOriginal = (originalPosition - transform.position).normalized;
            transform.position += directionToOriginal * moveSpeed * Time.deltaTime;
            movingRandomly = false;
        }
        // Move randomly near original position
        else if (distanceToOriginal <= stopThreshold && !movingRandomly)
        {
            movingRandomly = true;
            SetRandomDestination();
        }

        if (movingRandomly)
        {
            MoveRandomly();
        }
    }

    void SetRandomDestination()
    {
        randomDestination = originalPosition + (Random.insideUnitSphere * randomMoveRadius);
        randomDestination.y = originalPosition.y; // Keep the y-axis the same if working in 2D
    }

    void MoveRandomly()
    {
        if (Vector3.Distance(transform.position, randomDestination) > stopThreshold)
        {
            Vector3 directionToRandom = (randomDestination - transform.position).normalized;
            transform.position += directionToRandom * moveSpeed * Time.deltaTime;
        }
        else
        {
            SetRandomDestination();
        }
    }
}
