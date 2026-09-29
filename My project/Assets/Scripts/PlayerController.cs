using UnityEngine;
using UnityEngine.InputSystem;
using Y = UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnspeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputAction moveaction;
    public Vector2 moveinput;
    void Start()
    {
        moveaction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveinput = moveaction.ReadValue<Vector2>();

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveinput.y);
        transform.Translate(Vector3.forward * Time.deltaTime * turnspeed * moveinput.x);
        transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * moveinput.x);
  
    }
}
