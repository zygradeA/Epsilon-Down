using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    [Header("Wallrunning")]
    public LayerMask whatisWall;
    public LayerMask whatisGround;
    public float wallRunForce;
    private float wallRunTimer;
    [Header("Inputs")]
    private float verticalInput;
    private float horizontalInput;
    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftwallhit;
    private RaycastHit rightwallhit;
    private bool wallRight;
    private bool wallLeft;
    [Header("References")]
    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        CheckForWall();
        StateMachine();
    }
    private void FixedUpdate()
    {
        if (pm.wallrunning)
        {
            WallRunMovement();
        }
    }
    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightwallhit, wallCheckDistance, whatisWall);
        wallLeft  = Physics.Raycast(transform.position, -orientation.right, out leftwallhit, wallCheckDistance, whatisWall);
    }
    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatisGround);
    }
    private void StateMachine()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
        {
            if (!pm.wallrunning)
            {
                StartWallRun();
            }

            else
            {
                if (pm.wallrunning)
                {
                    StopWallRun();
                }
            }
        }
    }
    private void StartWallRun()
    {
        pm.wallrunning = true;
    }
    private void WallRunMovement()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        Vector3 wallNormal = wallRight ? rightwallhit.normal : leftwallhit.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);
        rb.AddForce(wallForward*wallRunForce, ForceMode.Force);
    }
    private void StopWallRun()
    {
        pm.wallrunning = false;
    }
}
