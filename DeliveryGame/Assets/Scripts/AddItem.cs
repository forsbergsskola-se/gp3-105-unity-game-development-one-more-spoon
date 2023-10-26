using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public int count;
    public TMP_Text countLabel;
    public void AddToInventory()
    {
        {
            count++;
            gameObject.SetActive(true);
            countLabel.text = count.ToString();
        }
    }

    public void Addname()
    {
        gameObject.SetActive(true);
    }
}
