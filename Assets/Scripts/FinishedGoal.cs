using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedGoal : MonoBehaviour
{
    private Transform thePlayerLoc;
    public GameObject finishText;
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
            finishText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (thePlayerLoc.GetComponent<CapsuleCollider>() == true)
        {
            reachedGoal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (thePlayerLoc.GetComponent<CapsuleCollider>() == true)
        {
            reachedGoal = false;
            finishText.SetActive(false);
        }
    }
}
