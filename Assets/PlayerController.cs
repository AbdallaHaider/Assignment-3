using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerModel;
    [SerializeField] private float speed;
    [SerializeField] private Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;


    public void Start()
    {
        playerModel = GetComponent<Rigidbody>();
        playerModel.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        movePlayer();
        controlSpeed();
    }
    private void Update()
    {
        moveInput();
    }
    private void moveInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void movePlayer()
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        playerModel.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
    }

    void controlSpeed()
    {
        Vector3 maxVelocity = new Vector3(playerModel.linearVelocity.x, 0f, playerModel.linearVelocity.z);
        if(maxVelocity.magnitude > speed)
        {
            Vector3 limitedVelocity = maxVelocity.normalized * speed;
            playerModel.linearVelocity = new Vector3(limitedVelocity.x, playerModel.linearVelocity.y, limitedVelocity.z);
        }
    }
}
