using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    public Transform _Body;

    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /*_Body.Rotate(0f, Input.GetAxis("Mouse X") * 120f * Time.deltaTime, 0f);
        GetComponent<Transform>().Rotate(Input.GetAxis("Mouse Y") * -120f * Time.deltaTime, 0f, 0f);*/

        // get mouse input
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        // Rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        _Body.rotation = Quaternion.Euler(0, yRotation, 0);

    }


}
