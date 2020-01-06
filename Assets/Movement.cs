using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementSpeed);
        rb.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * movementSpeed);
    }
}
