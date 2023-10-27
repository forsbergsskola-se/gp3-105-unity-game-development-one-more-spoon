using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUpPizza : MonoBehaviour
{
    private Player player;
    public AddItem pizzaImage;
    public AddItem pizzaname;
    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            pizzaImage.AddToInventory();
            pizzaname.Addname();
        }
    }
}

