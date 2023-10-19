using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int score;
    public int cash;
    public bool isDying = false;
    
    public Vector3 startingPosition;
    public Vector3 startingRotation;
    public TMP_Text cashText;
    public GameObject wastedText;
    
    private void Start()
    {
        startingPosition = this.transform.position;
        startingRotation = this.transform.rotation.eulerAngles;

    }

    private void Update()
    {
        cashText.SetText(cash.ToString());
    }

    public void HealPlayer(int healthAdded)
    {
        health += healthAdded;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
    }

    public void AddCash(int addedCash)
    {
        cash += addedCash;
    }

    public void RemoveCash(int removedCash)
    {
        cash -= removedCash;
    }

    public void RemoveCashOnDeath()
    {
        cash = cash / 2;
    }

    public void Respawn()
    {
        this.transform.rotation = Quaternion.Euler(startingRotation);
        this.transform.position = startingPosition;
        this.gameObject.GetComponent<PlayerController>().SetBackToIdle();
        this.gameObject.GetComponent<PlayerController>().movementSpeed = 4;
        this.gameObject.GetComponent<PlayerController>().rotationSpeed = 100;
        isDying = false;
        

    }

    public void ShowWastedText()
    {
        wastedText.SetActive(true);
    }
    
    public void HideWastedText()
    {
        wastedText.SetActive(false);
    }

    public void Death()
    {
        this.gameObject.GetComponent<PlayerController>().PlayDeathAnimation();
        this.gameObject.GetComponent<PlayerController>().movementSpeed = 0;
        this.gameObject.GetComponent<PlayerController>().rotationSpeed = 0;
        
        // Play death animation
        // wait for 3 seconds.
        // Respawn
        Debug.Log("You died!");
    }
}
