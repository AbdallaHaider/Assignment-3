using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player object
    private Rigidbody playerModel;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float airSpeed;
    [SerializeField] private Transform orientation;

    public LayerMask ground;
    bool onGround;

    public void Start()
    {
        playerModel = GetComponent<Rigidbody>();
        playerModel.freezeRotation = true;
    }
    private void Update()
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, 0.8f, ground);
        controlSpeed();
    }
    public void movePlayer(Vector2 input)
    {
        Vector3 moveDir = orientation.forward * input.y + orientation.right * input.x;
        if(onGround)
            playerModel.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
        if(!onGround)
            playerModel.AddForce(moveDir.normalized * speed * airSpeed * 10f, ForceMode.Force);
    }
    public void Jump()
    {
        if (onGround)
        {
            playerModel.linearVelocity = new Vector3(playerModel.linearVelocity.x, 0f, playerModel.linearVelocity.z);
            playerModel.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
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
