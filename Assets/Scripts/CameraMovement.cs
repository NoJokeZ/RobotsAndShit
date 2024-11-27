using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float mouseX;
    float mouseY;
    public float sensitivity = 5f;
    Vector3 offset = new Vector3(0f, 5.5f, -8f);

    Camera Cam;

    //Transform CameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        //CameraTransform = GetComponentInChildren
        //Cam = GetComponentFromTag<Camera>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        CameraMove();
    }

    private void FixedUpdate()
    {
        //float rotateHorizontal = Input.GetAxis("Mouse X");
        //float rotateVertical = Input.GetAxis("Mouse Y");
        //Cam.transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        //Cam.transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player

    }

    void GetInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
    }

    void CameraMove()
    {
        Cam.transform.RotateAround((transform.position), -Vector3.up, mouseX * sensitivity);
        Cam.transform.RotateAround(Vector3.zero, transform.right, mouseY * sensitivity);
        //Cam.transform.Rotate(Cam.transform.)


        //transform.Rotate(new Vector3(mouseY * sensitivity * Time.deltaTime, mouseX * sensitivity * Time.deltaTime, 0)); 
    }
}
