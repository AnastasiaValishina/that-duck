using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text scoreText;
    int totalScore = 0;

    static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        scoreText = GetComponent<Text>();   
    }

    public void AddScore(int value)
    {
        totalScore = totalScore + value;
        scoreText.text = totalScore.ToString();
    }
}
