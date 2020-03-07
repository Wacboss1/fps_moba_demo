using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float groundDistance = 1f;

    public LayerMask groundmask;

    bool isGrounded;
    Vector3 velocity;
    GameObject groundChecker;
    Transform groundCheck;
    CharacterController charC;

    // Start is called before the first frame update
    void Start()
    {
        charC = GetComponent<CharacterController>();
        groundChecker = GameObject.Find("GroundChecker");
        groundCheck = groundChecker.transform;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);
        Move();

        velocity.y -= gravity * Time.deltaTime;
        charC.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
    }

    private void Move()
    {
        float xin = Input.GetAxis("Horizontal");
        float zin = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xin + transform.forward * zin;

        charC.Move(move * movementSpeed * Time.deltaTime);
    }
}
