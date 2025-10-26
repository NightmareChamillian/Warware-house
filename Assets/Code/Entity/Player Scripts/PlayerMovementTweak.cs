using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class PlayerMovementTweak : MonoBehaviour
{
    public KeyControl jumpKey;

    Rigidbody rb;

    float horizInput;
    float vertInput;

    Vector3 moveDirection;

    public float moveSpeed = 8f;

    public float groundDrag = 5f;
    public float playerHeight = 2f;
    bool grounded;

    public float jumpForce = 10f;
    public float jumpCooldown = 0.25f;
    public float airMultiplier = 0.4f;
    bool readyToJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        jumpKey = Keyboard.current[Key.Space];

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // physics raycast from player pos to right below player. check if the player is on the ground or not
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f);

        GetInput();
        SpeedControl();

        // friction
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (jumpKey.isPressed && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void MovePlayer()
    {
        // calc movement dir
        moveDirection = transform.forward * vertInput + transform.right * horizInput;

        if (grounded)
            rb.AddForce(10f * moveSpeed * moveDirection.normalized, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(10f * moveSpeed * moveDirection.normalized * airMultiplier, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        Debug.Log("Jumping");
    }
    
    void ResetJump()
    {
        readyToJump = true;
    }
}
