using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cop : MonoBehaviour
{
    public UnityEvent OnDeath;
    private void OnDestroy()
    {
        this.OnDeath.Invoke();
    }

   
}
