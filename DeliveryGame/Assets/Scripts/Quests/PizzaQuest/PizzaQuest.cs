using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PizzaQuest : MonoBehaviour
{
  public InventoryItem inventoryItem;
  public GameObject questCanvas;
  public GameObject questText;
  public GameObject completedtext;
  public GameObject incompletedtext;
  public bool isAccepted;
  public bool isCompleted = false;
  
  public void StartQuest()
  {
    if (this.isAccepted) return;
      
    this.isAccepted = true;
    
  }
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {
    if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player"))
    {
      if (!this.isAccepted) return;
      
      //if (this.copsKilled >= 1) return;
      
      questCanvas.SetActive(true); questText.SetActive(false);
      completedtext.SetActive(inventoryItem.count >= 3);
      incompletedtext.SetActive(inventoryItem.count < 3);
    }
  }
/*questCanvas.SetActive(true); questText.SetActive(false);
      if (inventoryItem.count >= 3)
      {
        completedtext.SetActive(true);
      }

      if (inventoryItem.count < 3)
      {
        incompletedtext.SetActive(true);
      }*/
  
  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"));
    {
      questCanvas.SetActive(false);
    }
  }
  
}
