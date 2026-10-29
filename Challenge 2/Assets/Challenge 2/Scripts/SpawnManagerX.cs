
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
        InvokeRepeating(nameof(SpawnRandomBall), startDelay, spawnInterval);
    }

    void SpawnRandomBall()
    {
        // Choose a random ball
        int randomIndex = Random.Range(0, ballPrefabs.Length);

        // Spawn it at the top in a random position
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnLimitXLeft, spawnLimitXRight),
            spawnPosY,
            0f
        );

        GameObject ball = Instantiate(
            ballPrefabs[randomIndex],
            spawnPos,
            ballPrefabs[randomIndex].transform.rotation
        );

        // Enable gravity so the ball falls down
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = true;
        }
    }
}