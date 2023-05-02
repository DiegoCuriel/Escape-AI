using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float playerHeight = 2f;
    static public float movementSpeed = 6f;
    public float movementMultiplier = 10f;

    [SerializeField]
    float airMultiplier = 0.4f;

    public float jumpForce = 5f;

    float verticalMovement;
    float horizontalMovement;

    [SerializeField]
    float groundDrag = 6f;

    [SerializeField]
    float airDrag = 2f;

    Vector3 moveDirection;

    Rigidbody rb;
    bool isGrounded;

    [SerializeField] LayerMask groundMask;
    float groundDistance = 0.4f;

    //vidas
    private PlayerHealth playerHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //vidas
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, playerHeight / 2, 0), groundDistance, groundMask);

        MyInput();
        ControlDrag();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    //vidas
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerHealth.lives--;
            //imprimir vidas
            Debug.Log("Vidas: " + playerHealth.lives);
            if (playerHealth.lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isGrounded)
        {
            rb.AddForce(moveDirection * movementSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection * movementSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }
}