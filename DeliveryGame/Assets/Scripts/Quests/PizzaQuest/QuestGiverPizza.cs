using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestGiverPizza : MonoBehaviour
{
  
  public GameObject questCanvas;
  
  
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {
    PizzaQuest iscompleted = FindFirstObjectByType<PizzaQuest>();
    if (iscompleted.iscompleted == true)
    {
      return;
    }
    
    
    if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player"))
    {
      questCanvas.SetActive(true);
    }
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"));
    {
      questCanvas.SetActive(false);
    }
  }
  
}
