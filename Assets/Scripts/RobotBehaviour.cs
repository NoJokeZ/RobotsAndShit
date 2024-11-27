using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RobotBehaviour : MonoBehaviour
{
    float horizontal = 0f;
    float vertical = 0f;
    public float MovementSpeed = 8f;

    float xRotation;
    float yRotation;

    [SerializeField] Transform Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
    }

    void FixedUpdate()
    {

    }

    void LateUpdate()
    {
        CameraMovement();
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Movement()
    {
        //transform.position = transform.position + new Vector3(horizontal * movementSpeed * Time.deltaTime, 0, vertical * movementSpeed * Time.deltaTime);

        horizontal = horizontal * MovementSpeed * Time.deltaTime;
        vertical = vertical * MovementSpeed * Time.deltaTime;


        Vector3 cameraForward = Camera.forward;
        Vector3 cameraRight = Camera.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 forwardRelativeMovementVector = vertical * cameraForward;
        Vector3 rightRelativeMovementVector = horizontal * cameraRight;

        Vector3 RelativeMovementVector = (forwardRelativeMovementVector + rightRelativeMovementVector); // * movementSpeed;
        //RelativeMovementVector = RelativeMovementVector.normalized;

        //RelativeMovementVecor = RelativeMovementVector * movementSpeed;

        transform.position = (transform.position + RelativeMovementVector);

    }

    void CameraMovement()
    {
        xRotation += Input.GetAxisRaw("Mouse X");
        yRotation += -(Input.GetAxisRaw("Mouse Y"));
        yRotation = Mathf.Clamp(yRotation, -40, 80);
        Quaternion camRotation = Quaternion.Euler(yRotation, xRotation, 0);
        Quaternion playerRotation = Quaternion.Euler(0, xRotation, 0);
        Camera.rotation = camRotation;
        transform.rotation = playerRotation;
    }
}
