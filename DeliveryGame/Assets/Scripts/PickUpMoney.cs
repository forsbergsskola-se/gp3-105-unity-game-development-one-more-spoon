using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpMoney : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.Rotate(0, 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            player.AddCash(100);
        }
    }
}
