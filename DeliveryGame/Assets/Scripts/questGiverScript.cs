using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questGiverScript : MonoBehaviour
{
  public GameObject quest;
  public void OnTriggerEnter(Collider other)
  {
    quest.SetActive(true);
  }

  public void OnTriggerExit(Collider other)
  {
    quest.SetActive(false);
  }
}
