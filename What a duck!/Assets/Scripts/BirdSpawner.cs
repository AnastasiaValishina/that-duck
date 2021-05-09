using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] Bird birdPrefab;
    public Levels levelConfig;
    public float speed;

    float minDelay, maxDelay;
    float delayIndex = 1f;
    float delayChangeInSeconds = 10f;
    float nextSpawnTime;
    float nextSpawnTimeChange;

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
        minDelay = levelConfig.levels[0].minDelay;
        maxDelay = levelConfig.levels[0].maxDelay;
        delayIndex = levelConfig.levels[0].delayIndex;
        delayChangeInSeconds = levelConfig.levels[0].delayChangeInSeconds;

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

            if (delayIndex != 0 && Time.time > nextSpawnTimeChange && maxDelay > minDelay)
            {
                maxDelay *= delayIndex;
                nextSpawnTimeChange = Time.time + delayChangeInSeconds;
            }
        }
    }
}
