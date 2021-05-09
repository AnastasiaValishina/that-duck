using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
    [Header("Score")]
    public int birdScoreValue = 1;
    
    [Header("Bird Spawn Delay")]
    public float minDelay;
    public float maxDelay;
    public float delayIndex = 1f;
    public float delayChangeInSeconds;

    [Header("Bird Speed")]
    public float initialSpeed;
    public float maxSpeed;
    public float speedChangeIndex = 1f;
    public float speedChangeInSeconds = 10f;

    [Header("Possibility")]
    public float minTurnInterval;
    public float maxTurnInterval;
    [Range(0, 100)] public int turnPossibility;
}
