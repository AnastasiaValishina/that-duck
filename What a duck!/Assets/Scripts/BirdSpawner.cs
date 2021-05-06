using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] Bird birdPrefab;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] float delayIndex = 1f;
    [SerializeField] float delayChangeInSeconds;

    [Header("Speed")]
    public float speed;
    [SerializeField] float initialSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float speedChangeIndex = 1f;
    [SerializeField] float speedChangeInSeconds = 10f;

    float nextSpawnTime;
    float nextSpawnTimeChange;
    float nextSpeedChange;

    static BirdSpawner instance;
    public static BirdSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BirdSpawner>();
            }
            return instance;
        }
    }

    void Start()
    {
        nextSpawnTimeChange = delayChangeInSeconds;
        nextSpeedChange = speedChangeInSeconds;
        speed = initialSpeed;
    }

    void Update()
    {
        SpawnBird();
        BirdSpeedChange();
    }

    void SpawnBird()
    {
        if (Time.time > nextSpawnTime)
        {
            float xPos = Random.Range(-2f, 2f);
            Vector2 birdPosition = new Vector2(xPos, -2.8f);
            Instantiate(birdPrefab, birdPosition, Quaternion.identity);

            nextSpawnTime = Time.time + Random.Range(minDelay, maxDelay);

            if (delayIndex != 0 && Time.time > nextSpawnTimeChange && maxDelay > minDelay)
            {
                maxDelay *= delayIndex;
                nextSpawnTimeChange = Time.time + delayChangeInSeconds;
            }
        }
    }
    void BirdSpeedChange()
    {
        if (speedChangeIndex != 0 && Time.time > nextSpeedChange && speed < maxSpeed)
        {
            speed *= speedChangeIndex;
            nextSpeedChange = Time.time + speedChangeInSeconds;
        }
    }
}
