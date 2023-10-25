using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealDown : MonoBehaviour
{
    private Player player;

    public float timeBuffRemaining;

    // add a remainingTimeField: *
    private void Start()
    {
        player = GetComponent<Player>();

        if (player != null && player.health > 0)
        {
            player.health -= 1;
            // add benefit *
        }
    }
}
/*
        timeBuffRemaining = 5;
        // add the benefit to movement *
        // set remaining time to 30 *
    }

    private void OnDestroy()
    {
        // remove the benefit from movement*
        player.health = 100;
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
*/


