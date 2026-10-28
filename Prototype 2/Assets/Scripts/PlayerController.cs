using Mono.Cecil;
using System.Threading;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction fireAction;

    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;

    void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }

    void Update()
    {
        // Move left and right
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(
            Vector3.right * moveInput.x * Time.deltaTime * speed,
            Space.World
        );

        // Keep player inside the boundaries
        float x = Mathf.Clamp(
            transform.position.x, -xRange, xRange
        );

        transform.position = new Vector3(
            x, transform.position.y, transform.position.z
        );

        // Shoot food with the Fire Action
        if (fireAction.WasPressedThisFrame())
        {
            if (projectilePrefab != null)
            {
                Instantiate(
                    projectilePrefab,
                    transform.position + transform.forward * 1.5f,
                    projectilePrefab.transform.rotation
                );
            }
            else
            {
                Debug.LogError("Assign your projectile prefab in the Inspector!");
            }
        }
    }
}