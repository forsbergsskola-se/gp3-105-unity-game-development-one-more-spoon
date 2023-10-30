using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cop : MonoBehaviour

{
    public int health = 100;
    public UnityEvent OnDeath;
    
    public void copDead()
    {
        this.OnDeath.Invoke();
    }

    private void Update()
    {
        if (health<=0)
        {
            copDead();
        }
    }
}
