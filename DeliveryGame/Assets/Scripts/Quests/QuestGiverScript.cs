using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class QuestGiverScript : MonoBehaviour
{
  
  
  public GameObject questCanvas;
  public GameObject missionCompletedText;
  public GameObject questStartText;
 
  
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {
    CopKillQuest copKillQuest = FindFirstObjectByType<CopKillQuest>();
      if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player"))
      {
        questCanvas.SetActive(true);
        questStartText.SetActive(!copKillQuest.isAccepted);
        missionCompletedText.SetActive(copKillQuest.isCompleted);
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
