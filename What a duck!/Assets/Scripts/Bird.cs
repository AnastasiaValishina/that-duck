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
        if (xPos < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
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
        if (collision.tag == "RightBorder")
        {
            xPos = Random.Range(-1f, -0.2f);
            SetDirection();
        }
        if (collision.tag == "LeftBorder")
        {
            xPos = Random.Range(0.2f, 1f);
            SetDirection();
        }
        if (collision.tag == "Bullet")
        {
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void TurnByTime()
    {
        int possibilityIndex = Random.Range(0, 100);
        if (possibilityIndex > turnPossibility) 
        {
            if (Time.time > timeToTurn)
            {
                if (xPos < 0)
                {
                    xPos = Random.Range(0.2f, 1f);
                }
                else
                {
                    xPos = Random.Range(-1f, -0.2f);
                }
                SetDirection();
            }
        }
    }

}
