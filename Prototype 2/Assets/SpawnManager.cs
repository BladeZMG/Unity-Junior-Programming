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
    }

    // Update is called once per frame
    private float spawnRangex = 20;
    private float spawnPosZ = 20;
    void Update() { 
        if (Input.GetKeyDown(KeyCode.S)) {
            // Randomly generate animal index and spawn position
            Vector3 spwanPos = new Vector3(Random.Range(-spawnRangex, spawnRangex),0, spawnPosZ);
            {
                int animalIndex = Random.Range(0, animalPrefabs.Length);
                if (spawnAction.triggered)
                {
                    Instantiate(animalPrefabs[animalIndex],spwanPos, animalPrefabs[animalIndex].transform.rotation);
                }
            }
        }
    }
}
