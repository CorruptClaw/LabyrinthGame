using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    public Transform Body;

    [SerializeField]
    private float _cameraSensetivity;

    private float _pitch;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Body.Rotate(0f, Input.GetAxis("Mouse X") * _cameraSensetivity * Time.deltaTime, 0f);
        GetComponent<Transform>().Rotate(Input.GetAxis("Mouse Y") * -_cameraSensetivity * Time.deltaTime, 0f, 0f);
    }
}
