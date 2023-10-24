using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopKillQuestGiver : MonoBehaviour
{
   public CopKillQuest copKillQuest;

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Q))
      {
          copKillQuest.StartQuest();
      }
   }
}
