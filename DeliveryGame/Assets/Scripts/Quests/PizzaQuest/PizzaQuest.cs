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
  public GameObject iscompletedtext;
  //public GameObject missionCompletedCanvas;
  //public GameObject missionCompletedText;
  public bool iscompleted = false;
  
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {
    Player player = thingThatIsInsideTheCollider.GetComponent<Player>();

    if (iscompleted == true)
    {
      return;
    }
    
    if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player"))
    {
      questCanvas.SetActive(true); questText.SetActive(false);
      completedtext.SetActive(inventoryItem.count >= 3);
      iscompletedtext.SetActive(inventoryItem.count < 3);
      
      if (inventoryItem.count >=3 && iscompleted == false)
      {
        player.AddCash(2000);
        //missionCompletedCanvas.SetActive(iscompleted == false);
        //missionCompletedText.SetActive(iscompleted == false);
        iscompleted = true;
      }
    }
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player")) ;
    {
      questCanvas.SetActive(false);
    }

  }
}