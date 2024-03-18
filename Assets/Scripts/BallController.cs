using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    MazeMovement mazeMovement;

    [SerializeField] private float forceMultiplier = 40f;
    [SerializeField] private float cameraHeight = 5f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mazeMovement = FindObjectOfType<MazeMovement>();
        mainCamera = Camera.main;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Get the board's rotation angles in radians
        float xAngleRad = Mathf.Deg2Rad * mazeMovement.CurrentXRotation;
        float zAngleRad = Mathf.Deg2Rad * mazeMovement.CurrentZRotation;

        // Calculate force direction using sine and cosine of angles
        Vector3 forceDirection = new Vector3(-Mathf.Sin(zAngleRad), 0f, Mathf.Sin(xAngleRad));

        // Apply force with multiplier
        rb.AddForce(forceDirection * forceMultiplier);

        // Update camera position
        if (mainCamera != null)
        {
            // Set camera position to follow the ball's position with fixed height
            Vector3 cameraPosition = transform.position + Vector3.up * cameraHeight + Vector3.back * 2;
            mainCamera.transform.position = cameraPosition;

            // Rotate camera to look downwards
            Vector3 camaraDirection = new Vector3(0, -1, 1).normalized;
            mainCamera.transform.LookAt(transform.position, camaraDirection);
        }
    }
}
