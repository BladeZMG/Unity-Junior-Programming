using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject animalPrefab;

    public float spawnRangeX = 10f;
    public float spawnRangeZ = 10f;
    public float spawnY = 0f;

    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAnimal), 1f, spawnInterval);
    }

    void SpawnAnimal()
    {
        // Pick a random location
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            spawnY,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );

        // Spawn an animal
        GameObject newAnimal = Instantiate(
            animalPrefab,
            randomPosition,
            animalPrefab.transform.rotation
        );

        // Make the new animal spawn more animals
        AnimalSpawner newSpawner =
            newAnimal.AddComponent<AnimalSpawner>();

        newSpawner.animalPrefab = animalPrefab;
        newSpawner.spawnRangeX = spawnRangeX;
        newSpawner.spawnRangeZ = spawnRangeZ;
        newSpawner.spawnY = spawnY;
        newSpawner.spawnInterval = spawnInterval;
    }
}