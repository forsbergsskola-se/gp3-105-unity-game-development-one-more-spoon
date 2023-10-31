using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PizzaQuestCompleted : MonoBehaviour
{
  public InventoryItem inventoryItem;
  public GameObject questCanvas;
  public GameObject questText;
  public GameObject completedtext;
  public GameObject incompletedtext;
  
  private void Start()
  {
    
  }
  
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {
    if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player"))
    {
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
