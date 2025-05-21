using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedGoal : MonoBehaviour
{
    private Transform thePlayerLoc;
    public GameObject thePlayerObj;
    public bool reachedGoal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlayerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        reachedGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedGoal)
        {
            thePlayerObj.transform.position = thePlayerObj.GetComponent<PlayerMovementScript>().spawnPoint.position;
            thePlayerObj.GetComponent<PlayerMovementScript>().OnRespawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (thePlayerLoc.GetComponent<CapsuleCollider>() == true)
        {
            Debug.Log("Triggering the finish goal trigger, obj name: " + other.name);
            reachedGoal = true;
        }
    }
}
