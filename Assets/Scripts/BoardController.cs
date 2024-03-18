using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    float rotationSpeed = 20f;
    float maxRotation = 15f;

    float currentXRotation = 0f;
    float currentZRotation = 0f;

    // Propiedades para acceder a la rotación actual desde otros scripts
    public float CurrentXRotation { get { return currentXRotation; } }
    public float CurrentZRotation { get { return currentZRotation; } }

    // Update is called once per frame
    void Update()
    {
        // Actualizar la rotación en base a las teclas WASD
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

        // Limitar la rotación
        currentXRotation = Mathf.Clamp(currentXRotation, -maxRotation, maxRotation);
        currentZRotation = Mathf.Clamp(currentZRotation, -maxRotation, maxRotation);

        // Aplicar la rotación al tablero
        transform.rotation = Quaternion.Euler(currentXRotation, 0f, currentZRotation);
    }
}
