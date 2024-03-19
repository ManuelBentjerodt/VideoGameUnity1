using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMovement : MonoBehaviour
{
    float rotationSpeed = 15f;
    float maxRotation = 15f;

    float currentXRotation = 0f;
    float currentZRotation = 0f;

    // Propiedades para acceder a la rotaci�n actual desde otros scripts
    public float CurrentXRotation { get { return currentXRotation; } }
    public float CurrentZRotation { get { return currentZRotation; } }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        // Actualizar la rotaci�n en base a las teclas WASD
        if (Input.GetKey(KeyCode.W))
        {
            currentXRotation += rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentXRotation -= rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentZRotation += rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentZRotation -= rotationSpeed * Time.deltaTime;
        }

        // Limitar la rotaci�n
        currentXRotation = Mathf.Clamp(currentXRotation, -maxRotation, maxRotation);
        currentZRotation = Mathf.Clamp(currentZRotation, -maxRotation, maxRotation);

        // Aplicar la rotaci�n al tablero
        transform.rotation = Quaternion.Euler(currentXRotation, 0f, currentZRotation);
    }
}
