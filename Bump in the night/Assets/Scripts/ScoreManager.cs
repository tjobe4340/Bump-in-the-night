using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 5;

    public void AddPoints(int points)
    {
        score += points;
        // You can add more logic here, such as updating the UI to display the score.
    }

    public void DecreaseScoreByOne()
    {
        score -= 1;
        // You can add more logic here, such as updating the UI to display the updated score.
    }

    public int GetScore()
    {
        return score;
    }

    private void Start()
    {
        // Invoke a method to decrease the score by 1 every 3 seconds.
        InvokeRepeating("DecreaseScoreByOne", 0f, 3f);
    }
}