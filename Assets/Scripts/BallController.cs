using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    MazeMovement mazeMovement;

    [SerializeField] private float forceMultiplier = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mazeMovement = FindObjectOfType<MazeMovement>();
        
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
        rb.AddForce(forceDirection * forceMultiplier, ForceMode.Acceleration);
       

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        Debug.Log(rb.velocity);
        // Cuando la pelota colisiona con otro objeto, calcula el vector de rebote
        Vector3 newDirection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = newDirection;
    }
}
