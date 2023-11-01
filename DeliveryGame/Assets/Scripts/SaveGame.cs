using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public void OnTriggerStay(Collider thingThatIsInsideTheCollider)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && thingThatIsInsideTheCollider.CompareTag("Player"))
        {
            Debug.Log("Saving the game");
            SavePoint();
        }
    }



    public void SavePoint()
    {
        Player player = FindFirstObjectByType<Player>();
        player.SaveGame();
    }
}
