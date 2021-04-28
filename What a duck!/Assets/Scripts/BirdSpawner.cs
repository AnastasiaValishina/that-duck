using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] Bird birdPrefab;
    //   [SerializeField] List<GameObject>;

    bool isActive = true;
    IEnumerator Start()
    {
        for (int i = 0; i < 20; i++)
        {
            StartCoroutine(SpawnBird());
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        
    }

    IEnumerator SpawnBird()
    {
        float xPos = Random.Range(-2f, 2f);
        Vector2 birdPosition = new Vector2(xPos, -2.8f);
        Instantiate(birdPrefab, birdPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }

}
