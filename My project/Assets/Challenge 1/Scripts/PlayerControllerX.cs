using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float tiltSpeed = 50f;
    public float propellerSpeed = 1000f;

    public Transform propeller;

    void Update()
    {
        // Move the plane forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Tilt upward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * tiltSpeed * Time.deltaTime);
        }

        // Tilt downward
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * tiltSpeed * Time.deltaTime);
        }

        // Spin the propeller
        if (propeller != null)
        {
            propeller.Rotate(
                Vector3.forward * propellerSpeed * Time.deltaTime
            );
        }
    }
}