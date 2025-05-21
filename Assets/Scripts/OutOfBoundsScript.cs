using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    private Transform thePlayerLoc;
    public GameObject thePlayerObj;
    public bool isOutOfBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlayerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        isOutOfBounds = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOutOfBounds)
        {
            thePlayerObj.transform.position = thePlayerObj.GetComponent<PlayerMovementScript>().spawnPoint.position;
            thePlayerObj.GetComponent<PlayerMovementScript>().OnRespawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (thePlayerLoc.GetComponent<CapsuleCollider>() == true)
        {
            isOutOfBounds = true;
        }
    }

}
