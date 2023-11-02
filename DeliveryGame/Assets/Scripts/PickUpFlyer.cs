using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUpFlyer : MonoBehaviour
{
    private Player player;
    public InventoryItem flyerImage;
    public InventoryItem flyerText;
    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            flyerImage.AddToInventory();
            flyerText.AddToInventory();
        }
    }
}

