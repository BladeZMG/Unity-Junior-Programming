using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.WebGL;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public InputAction spawnAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnAction.Enable();
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    private float spawnRangex = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    void Update()
    {
        {
            // Randomly generate animal index and spawn position
            {
                if (spawnAction.triggered)
                {
                }
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangex, spawnRangex), 0, spawnPosZ);
                int animalIndex = Random.Range(0, animalPrefabs.Length);
                Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
            }
        }
    }
}
