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
    [FormerlySerializedAs("inventoryImage")] [FormerlySerializedAs("inventoryItem")] public AddItem flyerImage;
    public AddItem flyername;
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
            flyername.Addname();
        }
    }
}

