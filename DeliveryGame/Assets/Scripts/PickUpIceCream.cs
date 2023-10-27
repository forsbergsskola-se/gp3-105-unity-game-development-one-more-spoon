using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpIceCream : MonoBehaviour
{
    public AddItem icecreamName;
    public AddItem icecreamImage;
    private Player player;
    static int Icecreams = 1;
    // private PickUpIceCream Canvas
    // I created a canvas in Ice Cream 1 for the Ice-Cream quest text.
    
    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Icecreams == 1)
        {
            // Quest activated
            
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            icecreamName.Addname();
            icecreamImage.AddToInventory();
            player.AddScore(10 * Icecreams);
            Icecreams++;
        }
    }
}