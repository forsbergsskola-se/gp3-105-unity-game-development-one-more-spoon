using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int score;
    public int cash;
    

    public void TakeDamage()
    {
        
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
        
    }
}
