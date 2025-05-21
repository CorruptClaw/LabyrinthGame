using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMarkersScript : MonoBehaviour
{
    [Header("Marker Sprite")]
    public Sprite markerX;


    private Transform thePlayerLoc;
    public bool playerInRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = markerX;
        thePlayerLoc = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (thePlayerLoc.GetComponent<CapsuleCollider>() == true)
        {
            Debug.Log("Triggering the marking trigger, obj name: " + other.name);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (thePlayerLoc.GetComponent<CapsuleCollider>() == true)
        {
            Debug.Log("Leaving the marking trigger, obj name: " + other.name);
            playerInRange = false;
        }
    }

    public void MarkingSpot()
    {
        if (playerInRange)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = markerX;
        }
        else if (!playerInRange)
        {
            Debug.Log("Is to far away");
        }
    }

}
