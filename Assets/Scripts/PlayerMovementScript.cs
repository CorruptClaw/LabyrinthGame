using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float speed;


    private Rigidbody _playerRigidbody;
    private float movementX;
    private float movementY;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 Localmovement = new Vector3(movementX, 0f, movementY);

        Vector3 WorldMovement = transform.TransformVector(Localmovement);

        _playerRigidbody.AddForce(WorldMovement * speed);
    }

}
