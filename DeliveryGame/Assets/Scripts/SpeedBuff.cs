using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    private PlayerController playerController;
    private Player player;
    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.AddCash(10);
            playerController.movementSpeed = playerController.movementSpeed + 2;
        }
    }
}
