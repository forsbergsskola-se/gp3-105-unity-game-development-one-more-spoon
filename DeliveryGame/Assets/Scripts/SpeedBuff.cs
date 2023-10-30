using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    private PlayerController playerController;

    private DanielsCarMovementScript carScript;

    public float timeBuffRemaining;
    // add a remainingTimeField: *
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        carScript = GetComponentInParent<DanielsCarMovementScript>();
        if (playerController != null)
        {
            playerController.movementSpeed = 9;
            // add benefit *
        }
        else
        {
            carScript.movementSpeed = 45000;
        }
        
        timeBuffRemaining = 5;
        // add the benefit to movement *
        // set remaining time to 30 *
    }

    private void OnDestroy()
    {
        
        if (playerController != null)
        {
            playerController.movementSpeed = 4;
        }
        else
        {
            carScript.movementSpeed = 35000;
        }
    }

    private void Update()
    {
        timeBuffRemaining = timeBuffRemaining - Time.deltaTime;
        if (timeBuffRemaining < 0)
        {
            Destroy(this);
        }
        // change remaining time by subtracting Time.deltaTime;
        // if remaining time is below zero
        // then destroy this component
    }
}


