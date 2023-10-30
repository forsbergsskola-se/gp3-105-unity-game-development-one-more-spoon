using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
  
  
  public GameObject questCanvas;

  private void Start()
  {
    
  }
  
  public void OnTriggerEnter(Collider thingThatIsInsideTheCollider)
  {
    if (thingThatIsInsideTheCollider.CompareTag("Player"))
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
