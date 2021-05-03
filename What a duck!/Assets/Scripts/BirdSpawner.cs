using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] Bird birdPrefab;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] float delayIndex = 1f;
    [SerializeField] float delayChangeInSeconds;

    float nextSpawnTime;
    float nextSpawnTimeChange;

    void Start()
    {
        nextSpawnTimeChange = delayChangeInSeconds;
    }

    void Update()
    {
        SpawnBird();
    }

    void SpawnBird()
    {
        if (Time.time > nextSpawnTime)
        {
            float xPos = Random.Range(-2f, 2f);
            Vector2 birdPosition = new Vector2(xPos, -2.8f);
            Instantiate(birdPrefab, birdPosition, Quaternion.identity);

            nextSpawnTime = Time.time + Random.Range(minDelay, maxDelay);

            if (delayIndex != 0 && Time.time > nextSpawnTimeChange)
            {
                maxDelay *= delayIndex;
                nextSpawnTimeChange = Time.time + delayChangeInSeconds;
            }
        }
    }

}
