using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questGiverScript : MonoBehaviour
{
  public GameObject quest;
  public void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player");
    {
      quest.SetActive(true);
    }
    
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.tag == "Player");
    {
      quest.SetActive(false);
    }
    
  }
}
