
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22f;
    private float spawnLimitXRight = 7f;
    private float spawnPosY = 30f;

    private float startDelay = 1f;
    private float spawnInterval = 4f;

    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    void SpawnRandomBall()
    {
        int randomIndex = Random.Range(0, ballPrefabs.Length);

        Vector3 spawnPos = new Vector3(
            Random.Range(spawnLimitXLeft, spawnLimitXRight),
            spawnPosY,
            0f
        );

        Instantiate(ballPrefabs[randomIndex], spawnPos,
            ballPrefabs[randomIndex].transform.rotation);
    }
}
