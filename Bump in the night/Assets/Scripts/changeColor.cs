using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorChanger : MonoBehaviour
{
    public SpriteRenderer wallSpriteRenderer; // Assign the sprite renderer of the wall
    public Color hitColor = Color.red; // Define the color you want the wall to change to
    public float colorChangeDuration = 1f; // How long the color change should last
    private Color originalColor; // To store the original color of the wall

    void Start()
    {
        // Store the original color of the wall
        originalColor = wallSpriteRenderer.color;
    }

    private void OnParticleCollision(GameObject other)
    {
        // Change the color of the wall
        wallSpriteRenderer.color = hitColor;

        // Stop any existing coroutine to avoid overlaps
        StopAllCoroutines();

        // Start a coroutine to fade the color back
        StartCoroutine(FadeColorBack());
    }

    private IEnumerator FadeColorBack()
    {
        float elapsedTime = 0;

        while (elapsedTime < colorChangeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Lerp the color back to the original over the specified duration
            wallSpriteRenderer.color = Color.Lerp(hitColor, originalColor, elapsedTime / colorChangeDuration);

            yield return null;
        }

        // Ensure the color is set to the original at the end
        wallSpriteRenderer.color = originalColor;
    }
}

