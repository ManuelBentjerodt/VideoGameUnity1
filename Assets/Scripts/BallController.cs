using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    BoardController boardController;

    float forceMultiplier = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boardController = FindObjectOfType<BoardController>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Get the board's rotation angles in radians
        float xAngleRad = Mathf.Deg2Rad * boardController.CurrentXRotation;
        float zAngleRad = Mathf.Deg2Rad * boardController.CurrentZRotation;

        // Calculate force direction using sine and cosine of angles
        Vector3 forceDirection = new Vector3(- Mathf.Sin(zAngleRad), 0f, Mathf.Sin(xAngleRad));

        // Apply force with multiplier
        rb.AddForce(forceDirection * forceMultiplier);
    }
}
