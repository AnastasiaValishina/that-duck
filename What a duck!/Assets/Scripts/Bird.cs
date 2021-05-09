using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    int scoreValue = 1;

    float minTurnInterval;
    float maxTurnInterval;
    int turnPossibility;

    float initialSpeed;
    float maxSpeed;
    float speedChangeIndex = 1f;
    float speedChangeInSeconds = 10f;

    Vector2 direction;
    float xPos;
    float yPos;
    float timeToTurn;
    float nextSpeedChange;

    void Start()
    {
        initialSpeed = BirdSpawner.Instance.levelConfig.levels[0].initialSpeed;
        maxSpeed = BirdSpawner.Instance.levelConfig.levels[0].maxSpeed;
        speedChangeIndex = BirdSpawner.Instance.levelConfig.levels[0].speedChangeIndex;
        speedChangeInSeconds = BirdSpawner.Instance.levelConfig.levels[0].speedChangeInSeconds;
        scoreValue = BirdSpawner.Instance.levelConfig.levels[0].birdScoreValue;
        minTurnInterval = BirdSpawner.Instance.levelConfig.levels[0].minTurnInterval;
        maxTurnInterval = BirdSpawner.Instance.levelConfig.levels[0].maxTurnInterval;
        turnPossibility = BirdSpawner.Instance.levelConfig.levels[0].turnPossibility;

        xPos = Random.Range(-1f, 1f);
        SetDirection();
        nextSpeedChange = speedChangeInSeconds;
        BirdSpawner.Instance.speed = initialSpeed;
    }

    void Update()
    {
        transform.localScale = (xPos < 0) ? new Vector2(1, 1) : new Vector2(-1, 1);
        Move();
        TurnByTime();
        BirdSpeedChange();
    }

    private void Move()
    {
        transform.Translate(direction * BirdSpawner.Instance.speed * Time.deltaTime);
    }

    void SetDirection()
    {
        yPos = Random.Range(0.2f, 1f);
        direction = new Vector2(xPos, yPos).normalized;
        float turnInterval = Random.Range(minTurnInterval, maxTurnInterval);
        timeToTurn = Time.time + turnInterval;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "RightBorder":
                xPos = Random.Range(-1f, -0.2f);
                SetDirection();
                break;
            case "LeftBorder":
                xPos = Random.Range(0.2f, 1f);
                SetDirection();
                break;
            case "Bullet":
                ScoreManager.Instance.AddScore(scoreValue);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
        }
    }

    void TurnByTime()
    {
        int possibilityIndex = Random.Range(0, 100);
        if (possibilityIndex > turnPossibility && Time.time > timeToTurn) 
        {
            xPos = (xPos < 0) ? Random.Range(0.2f, 1f) : Random.Range(-1f, -0.2f);
            SetDirection();     
        }
    }
    void BirdSpeedChange()
    {
        if (speedChangeIndex != 0 && Time.time > nextSpeedChange 
            && BirdSpawner.Instance.speed < maxSpeed)
        {
            BirdSpawner.Instance.speed *= speedChangeIndex;
            nextSpeedChange = Time.time + speedChangeInSeconds;
        }
    }
}
