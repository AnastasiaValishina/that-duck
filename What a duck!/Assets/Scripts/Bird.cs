using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] int scoreValue = 1;

    [Header("Possibility")]
    [SerializeField] float minTurnInterval;
    [SerializeField] float maxTurnInterval;
    [Range(0, 100)] [SerializeField] int turnPossibility;

    Vector2 direction;
    float xPos;
    float yPos;
    float timeToTurn;

    void Start()
    {
        xPos = Random.Range(-1f, 1f);
        SetDirection();
    }

    void Update()
    {
        transform.localScale = (xPos < 0) ? new Vector2(1, 1) : new Vector2(-1, 1);
        Move();
        TurnByTime();
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

}
