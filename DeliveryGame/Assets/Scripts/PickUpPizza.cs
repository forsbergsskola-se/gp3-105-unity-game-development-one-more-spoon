using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUpPizza : MonoBehaviour
{
    public InventoryItem pizzaImage;
    public InventoryItem pizzaText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            this.pizzaImage.AddToInventory();
            pizzaText.AddTextToinventory();
        }
    }
}

