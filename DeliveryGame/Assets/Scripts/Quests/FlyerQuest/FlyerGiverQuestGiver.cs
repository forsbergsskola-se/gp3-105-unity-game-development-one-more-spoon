using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerGiverQuestGiver : MonoBehaviour
{
   public FlyerQuest flyerQuest;

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Q))
      {
          //FlyerQuest.StartQuest();
      }
   }
}
