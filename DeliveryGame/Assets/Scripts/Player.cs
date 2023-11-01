using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    private int score;
    private int cash;
    //public static int moneySaved = 100;
    //public static int ammoSaved = 100;
    //public static bool playerDied = false;
    
    public bool isDying = false;
    
    
    public Vector3 startingPosition;
    public Vector3 startingRotation;

    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text cashText;
    
    public GameObject wastedText;

    private void Awake()
    {
        LoadSavedGame();
    }



    private void Start()
    {
        startingPosition = this.transform.position;
        startingRotation = this.transform.rotation.eulerAngles;
        // TransferMoneyAndAmmoBackToPlayerAfterRestart();


    }

    private void Update()
    {
        healthText.SetText(health.ToString());
        scoreText.SetText(score.ToString());
        cashText.SetText(cash.ToString());
        if (health <= 0 && isDying == false)
        {
            StartCoroutine(CheckHealth());
        }
        

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
    public void SaveGame()
    {
        Gun gun = GetComponentInChildren<Gun>();
        PlayerPrefs.SetInt("Cash", cash);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("AmmoLeft", gun.ammoLeft);
        PlayerPrefs.SetInt("AmmoStored", gun.ammoStored);
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }
    
    public void SaveCashOnDeath()
    {
        Gun gun = GetComponentInChildren<Gun>();
        PlayerPrefs.SetInt("Cash", cash);
    }
    
    private void LoadSavedGame()
    {
        Gun gun = GetComponentInChildren<Gun>();
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            cash = PlayerPrefs.GetInt("Cash");
            score = PlayerPrefs.GetInt("Score");
            gun.ammoLeft = PlayerPrefs.GetInt("AmmoLeft");
            gun.ammoStored = PlayerPrefs.GetInt("AmmoStored");
        }
    }

    public void RemoveCashOnDeath()
    {
        cash = cash / 2;
    }
    
    
    public void TransferMoneyAndAmmoBackToPlayerAfterRestart()
    {
        Gun gun = GetComponentInChildren<Gun>();
        //cash = moneySaved;
        //gun.ammoStored = ammoSaved;
    }

   public void RestartGameOnDeath()
    {
        Gun gun = GetComponentInChildren<Gun>();
        // moneySaved = cash;
       // ammoSaved = gun.ammoStored;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Respawn()
    {
        
        this.transform.rotation = Quaternion.Euler(startingRotation);
        this.transform.position = startingPosition;
        this.gameObject.GetComponent<PlayerController>().SetBackToIdle();
        this.gameObject.GetComponent<PlayerController>().movementSpeed = 4;
        this.gameObject.GetComponent<PlayerController>().rotationSpeed = 100;
        isDying = false;
        health = 100;

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

   public IEnumerator CheckHealth()
    {
            isDying = true;
            ShowWastedText();
            Death();
            yield return new WaitForSeconds(3);
            HideWastedText();
            RemoveCashOnDeath();
            SaveCashOnDeath();
            RestartGameOnDeath();
            //Respawn();
    }
    
    
    
}
