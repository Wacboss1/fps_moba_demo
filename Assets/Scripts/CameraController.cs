using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 5;

    float rotate = 0f;

    Transform trans;
    Transform playerTrans;
    
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        playerTrans = GameObject.Find("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Look();

    }

    private void Look()
    {
        float xMouse = Input.GetAxis("Mouse X") * cameraSpeed;  //mouse movement left and right
        float yMouse = Input.GetAxis("Mouse Y") * cameraSpeed;  //mouse movement up and down

        rotate -= yMouse;
        rotate = Mathf.Clamp(rotate, -90f, 90f);

        trans.localRotation = Quaternion.Euler(rotate, 0f, 0f);

        playerTrans.Rotate(Vector3.up, xMouse);
    }
}
