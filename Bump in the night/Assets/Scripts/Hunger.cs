using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour
{
    [SerializeField] string mainMenuSceneName = "MainMenu"; // Set this to the name of your main menu scene.
    [SerializeField] int points = 5;
    [SerializeField] Text scoreText; // Reference to the Text UI element.
    [SerializeField] AudioClip pickupSound;
    [SerializeField] TextMeshProUGUI winText;
    private AudioSource audioSource;

    

    void UpdateScoreUI(){
        if (scoreText != null){
            scoreText.text = "Food: " + points.ToString();
        }
        if (GameObject.FindGameObjectsWithTag("Food").Length == 0)
            {
                if (winText != null) {
                    winText.text = "You Win!";
                }
                StartCoroutine(LoadMainMenuAfterDelay());
            }
    }
    public void Decrese(){
        points--;
    }
    void Start(){
        InvokeRepeating("Decrese",0f,3f);
        audioSource = GetComponent<AudioSource>();
        if (winText != null){
             winText.text = ""; // Initialize win text to be empty
        }
    }
    void Update(){
        if(points<=0){
            SceneManager.LoadScene(mainMenuSceneName);
        }
        UpdateScoreUI();
    }

    IEnumerator LoadMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food")){
            points++;
            audioSource.PlayOneShot(pickupSound);
            // Update the UI Text element with the current score.
            UpdateScoreUI();
            
    }
}
}

