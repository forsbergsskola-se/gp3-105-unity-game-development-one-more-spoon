using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0,2,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.health < player.maxHealth)
        {
            Destroy(gameObject);
            if (player.health + 50 > player.maxHealth)
            {
                player.HealPlayer(player.maxHealth - player.health);
            }
            else
            {
                player.HealPlayer(50);
            }
        }
    }
}
