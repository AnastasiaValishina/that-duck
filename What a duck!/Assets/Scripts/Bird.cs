using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    Vector2 direction;
    float xPos;
    float yPos;

    void Start()
    {
        xPos = Random.Range(-1f, 1f);
        if (xPos < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else 
        {
            transform.localScale = new Vector2(-1, 1);
        }
        SetDirection();
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void SetDirection()
    {
        yPos = Random.Range(0.2f, 1f);
        direction = new Vector2(xPos, yPos).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RightBorder")
        {
            xPos = Random.Range(-1f, 0.2f);
            transform.localScale = new Vector2(1, 1);
            SetDirection();
        }
        if (collision.tag == "LeftBorder")
        {
            xPos = Random.Range(0.2f, 1f);
            transform.localScale = new Vector2(-1, 1);
            SetDirection();
        }
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
