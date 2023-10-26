using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class FlyerQuest : MonoBehaviour
{
   public UnityEvent onQuestStarted;

   public UnityEvent FlyerChangeEvent;
   // false, true (2)

   private bool isAccepted;
   private int flyer;
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
         questLable.text = $"{flyer} /2 Cops";
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
      if (this.flyer >= 2) return;

      this.flyer++;
      this.FlyerChangeEvent.Invoke();
      
      //this.OnCopsKilledChanged.Invoke(); ??
   }
}

          
      
      
         
     
   

