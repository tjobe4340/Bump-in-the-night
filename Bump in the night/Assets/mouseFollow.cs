using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDirectionController : MonoBehaviour
{
    public ParticleSystem particleSystem;

    void Update()
    {
        if (particleSystem == null)
        {
            Debug.LogError("Particle system is not assigned!");
            return;
        }

        // Convert the mouse position to world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        mousePosition.z = particleSystem.transform.position.z; // Ensure we stay in the 2D plane

        // Calculate the direction from the particle system to the mouse position
        Vector3 direction = (mousePosition - particleSystem.transform.position).normalized;

        // Calculate the angle between the particle system's forward vector and the direction vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // Subtract 90 degrees to align with particle system's forward direction

        // Set the particle system's rotation
        particleSystem.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
