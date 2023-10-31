using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CopKilledCompleted : MonoBehaviour
{
  
  
  public GameObject questCanvas;

  
  public void OnTriggerStay(Collider ThingThatIsInsideTheCollider)
  {
    CopKillQuest copKillQuest = FindFirstObjectByType<CopKillQuest>();
    if (!copKillQuest.isAccepted)
    {
      
      if (Input.GetKeyDown(KeyCode.E) && ThingThatIsInsideTheCollider.CompareTag("Player"))
      {
        questCanvas.SetActive(true);
      }
      
    }

    if (Input.GetKeyDown(KeyCode.E) && ThingThatIsInsideTheCollider.CompareTag("Player")&& copKillQuest.isCompleted == true)
    {
      onQuestCompleted();
    }

    if(Input.GetKeyDown(KeyCode.E) && ThingThatIsInsideTheCollider.CompareTag("Player")&& copKillQuest.isCompleted == true)
    {
      questCanvas.SetActive(false);
    }

  }

  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"));
    {
      questCanvas.SetActive(false);
    }
  }

  public void onQuestCompleted()
  {
    Debug.Log("Perfect, you killed him!");
  }
}
