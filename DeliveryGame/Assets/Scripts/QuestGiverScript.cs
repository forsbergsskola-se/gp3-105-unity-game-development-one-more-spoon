using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestGiverScript : MonoBehaviour
{
  
  
  public GameObject questCanvas;

  private void Start()
  {
    
  }
  
  public void OnTriggerStay(Collider ThingThatIsInsideTheCollider)
  {
    if (Input.GetKeyDown(KeyCode.E) && ThingThatIsInsideTheCollider.CompareTag("Player"))
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
