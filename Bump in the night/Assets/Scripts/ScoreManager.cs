using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public void AddPoints(int points)
    {
        score += points;
        // You can add more logic here, such as updating the UI to display the score.
    }

    public int GetScore()
    {
        return score;
    }
}
