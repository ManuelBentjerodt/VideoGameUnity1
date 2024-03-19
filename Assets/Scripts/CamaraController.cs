using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // Base movement speed (can be adjusted in Inspector)

    public float rotationSpeed = 3f; // Velocity of camera rotation (not used for movement)


    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    [Range(0.1f, 9f)]
    [SerializeField] float sensitivity = 2f;

    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)]
    [SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;

    BallController ballController;

    void Start()
    {
        Debug.Log("CameraController Start");
        ballController = FindObjectOfType<BallController>();
    }

    void Update()
    {

        // Check for arrow key presses
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (!Input.GetKey(KeyCode.Space))
        {
            return;
        }

        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     verticalInput = 1.0f;
        // }
        // else if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     verticalInput = -1.0f;
        // }
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     horizontalInput = -1.0f;
        // }
        // else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     horizontalInput = 1.0f;
        // }

        // Calculate movement based on arrow key presses
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;

    //     transform.position = ballController.transform.position + new Vector3(0, 10, 0);
    //     Debug.Log("Ball position: " + ballController.transform.position);
    }

    void LateUpdate()
    {
        // ... other code

        // Look at the ball's position
        // transform.LookAt(ballController.transform);
    }

}
