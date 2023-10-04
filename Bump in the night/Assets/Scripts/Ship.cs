using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField] string mainMenuSceneName = "MainMenu"; // Set this to the name of your main menu scene.
    [SerializeField] int points = 0;
    [SerializeField] Text scoreText; // Reference to the Text UI element.
    [SerializeField] AudioClip pickupSound;
    private AudioSource audioSource;

    private void Start(){
        // Get the AudioSource component attached to this GameObject.
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with a block (you might need to tag your block GameObject).
        if (other.CompareTag("Finish")){
            // Load the main menu scene when the player hits the block.
            SceneManager.LoadScene(mainMenuSceneName);

        }else if (other.CompareTag("Respawn")){
            // Increase the points when colliding with an object tagged as "Respawn."
            points++;
            audioSource.PlayOneShot(pickupSound);

            // Update the UI Text element with the current score.
            UpdateScoreUI();

            // Destroy the object that the player collided with (the one with the "Respawn" tag).
            Destroy(other.gameObject);
        }
    }

    // Update the UI Text element with the current score.
    void UpdateScoreUI(){
        if (scoreText != null){
            scoreText.text = "Score: " + points.ToString();
        }
    }
}
