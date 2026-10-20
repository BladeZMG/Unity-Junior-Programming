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
    void Update()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        if (spawnAction.triggered)
        {
            Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
