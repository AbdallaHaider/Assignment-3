using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerModel;
    public Rigidbody rigb;

    public float rotationSpeed;

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
