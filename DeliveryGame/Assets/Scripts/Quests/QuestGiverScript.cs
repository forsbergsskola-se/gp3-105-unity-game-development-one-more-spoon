using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class QuestGiverScript : MonoBehaviour
{
  
  
  public GameObject questCanvas;
  public GameObject questStartText;
  public GameObject rewardCanvasText;
  public bool questHasBeenRewarded; 
  
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {
    CopKillQuest copKillQuest = FindFirstObjectByType<CopKillQuest>();
      if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player")&& copKillQuest.isCompleted==false)
      {
        questCanvas.SetActive(true);
        questStartText.SetActive(!copKillQuest.isAccepted);
       
      }
      if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player")&& copKillQuest.isCompleted==true && questHasBeenRewarded==false)
      {
        questHasBeenRewarded = true;
        rewardCanvasText.SetActive(true);
        Player player = FindFirstObjectByType<Player>();
        player.AddCash(2000);
        StartCoroutine(TurnOfQuestRewardCanvas());
        
      }
      
      
  }
  public IEnumerator TurnOfQuestRewardCanvas()
  {
    yield return new WaitForSeconds(5);
    rewardCanvasText.SetActive(false);
  }
  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"));
    {
      questCanvas.SetActive(false);
    }
  }
  
}
