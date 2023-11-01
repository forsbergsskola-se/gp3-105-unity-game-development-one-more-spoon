using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeInstantDeath : MonoBehaviour
{
    private Player player;
    

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        
    }

    IEnumerator OnTriggerEnter(Collider smokeTrigger)
    {
        if (smokeTrigger.CompareTag("Player") && player.isDying == false)
        {
            player.isDying = true;
            player.ShowWastedText();
            player.Death();
            yield return new WaitForSeconds(3);
            player.HideWastedText();
            player.RemoveCashOnDeath();
            player.SaveCashOnDeath();
            player.RestartGameOnDeath();
            //player.Respawn();
        }
        
        
    }
}
