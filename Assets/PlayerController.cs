using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player object
    private Rigidbody playerModel;

    [SerializeField] private float speed;
    [SerializeField] private Transform orientation;

    public void Start()
    {
        playerModel = GetComponent<Rigidbody>();
        playerModel.freezeRotation = true;
    }
    private void Update()
    {
        controlSpeed();
    }
    public void movePlayer(Vector2 input)
    {
        Vector3 moveDir = orientation.forward * input.y + orientation.right * input.x;
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
