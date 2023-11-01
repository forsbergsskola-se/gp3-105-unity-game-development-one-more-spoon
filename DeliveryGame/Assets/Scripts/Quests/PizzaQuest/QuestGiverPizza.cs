using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class QuestGiverPizza : MonoBehaviour
{
  
  
  public GameObject questCanvas;
  public GameObject questStartText;
  public GameObject rewardCanvasText;
  public bool questHasBeenRewarded; 
  
  public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
  {

    PizzaQuest pizzaQuest = FindFirstObjectByType<PizzaQuest>();
      if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player")&& pizzaQuest.isCompleted==false)
      {
        questCanvas.SetActive(true);
        questStartText.SetActive(!pizzaQuest.isAccepted);
       
      }
      if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player")&& pizzaQuest.isCompleted==true && questHasBeenRewarded==false)
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
