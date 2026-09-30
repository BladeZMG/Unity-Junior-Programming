using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroler: MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float tiltSpeed = 50f;
    public float levelSpeed = 2f;

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * tiltSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * tiltSpeed * Time.deltaTime);
        }
        else
        {
            // Slowly return to level
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(0, transform.eulerAngles.y, 0),
                levelSpeed * Time.deltaTime
            );
        }
    }
}
