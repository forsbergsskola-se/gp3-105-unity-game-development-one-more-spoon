using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CopKillQuest : MonoBehaviour
{
   public UnityEvent onQuestStarted;

   public UnityEvent CopsKilledChangeEvent;
   // false, true (2)

   private bool isAccepted;
   private int copsKilled;
   public TMP_Text questLable;
   public Player player;
   public AudioSource music;
   public Slider healthbar;
   

   public void Update()
   {
      if (isAccepted)
      {
         Debug.Log("Raise event");
      }
      
      if (isAccepted)
      {
         questLable.text = $"{copsKilled} /2 Cops";
      }

      if (!isAccepted)
      {
         questLable.text = "";
      }

   }

   public void StartQuest()
   {
      if (this.isAccepted) return;
      
      this.isAccepted = true;
      this.onQuestStarted.Invoke();
   }
   public void OnCopKilled()
   {
      if (!this.isAccepted) return;
      if (this.copsKilled >= 2) return;

      this.copsKilled++;
      this.CopsKilledChangeEvent.Invoke();
      
      //this.OnCopsKilledChanged.Invoke(); ??
   }
}

          
      
      
         
     
   
