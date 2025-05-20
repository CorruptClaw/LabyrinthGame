using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    public float groundDrag;

    public float jumpForce;
    public float airMultiplier;

    [Header("Ground Check")]
    public float _playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Spawn and Checks")]
    public Transform spawnPoint;
    public GameObject deathBarrier;
    public GameObject endPoint;

    private Rigidbody _playerRigidbody;
    private float movementX;
    private float movementY;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        transform.position = spawnPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, whatIsGround);

        // handle drag
        if (grounded)
        {
            //Debug.Log(grounded);
            _playerRigidbody.linearDamping = groundDrag;
            grounded = true;
            
        }
        else
        {
            _playerRigidbody.linearDamping = 0;
        }

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

        if (grounded)
        {
            _playerRigidbody.AddForce(WorldMovement * speed);
        }
        else if (!grounded)
        {
            _playerRigidbody.AddForce(WorldMovement * speed * airMultiplier);
        }
        

    }

    void OnJump()
    {
       if (grounded)
       {
            //Debug.Log(readyToJump);

            // reset y velocity
            _playerRigidbody.angularVelocity = new Vector3(_playerRigidbody.linearVelocity.x, 0f, _playerRigidbody.linearVelocity.y);

            _playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            grounded = false;
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            /*if (deathBarrierCollider.isTrigger)
            {
                Debug.Log("Entered death trigger, object is: " + gameObject.name);
                transform.position = spawnPoint.position;
            }

            if (endPointCollider.isTrigger)
            {
                Debug.Log("Entered winning trigger, object is: " + gameObject.name);
                //Debug.Log("Reached to the end");
            }
            Debug.Log("You died!");
            transform.position = spawnPoint.position;*/
        }
        
    }

    public void OnRespawn()
    {
        if (deathBarrier.GetComponent<OutOfBoundsScript>().isOutOfBounds == true)
        {
            deathBarrier.GetComponent<OutOfBoundsScript>().isOutOfBounds = false;
        }
        
        if (endPoint.GetComponent<FinishedGoal>().reachedGoal == true)
        {
            endPoint.GetComponent<FinishedGoal>().reachedGoal = false;
        }

    }

    #region DebugLog checking with button press
    private void DebugLogsChecks()
    {
        /*if (deathBarrier)
        {
            isAvailable = true;
            Debug.Log(deathBarrier.name + " is " + isAvailable);
        }
        else if (!deathBarrier)
        {
            isAvailable = false;
            Debug.Log(deathBarrier.name + " is " + isAvailable);
        }*/

        /*if (endPoint)
        {
            isAvailable = true;
            Debug.Log(endPoint.name + " is " + isAvailable);
        }
        else if (!endPoint)
        {
            isAvailable = false;
            Debug.Log(endPoint.name + " is " + isAvailable);
        }*/

    }

    void OnDebugCheck()
    {
        //DebugLogsChecks();
    }
    #endregion

}
