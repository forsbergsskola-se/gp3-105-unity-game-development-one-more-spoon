using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Cop : MonoBehaviour

{
    private Player player;
    private PlayerController playerController;
    
    public int policeHealth = 100;
    public UnityEvent OnDeath;
    public Animator policeAnimator;
    


    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        playerController = FindFirstObjectByType<PlayerController>();
        policeAnimator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (policeHealth<=0)
        {
            copDead();
        }
    }
    
    private void OnCollisionEnter(Collision hitWithMeleeWeapon)
    {
        if (hitWithMeleeWeapon.gameObject.CompareTag("Bat") && playerController.meleeAttacking)
        {
            policeHealth -= 25;
            Debug.Log("The Police was hit with a bat. the health is: " + policeHealth);

            if (policeHealth <= 0)
            {
                copDead();
            }
        }

    }
    public void copDead()
    {
        policeAnimator.Play("CopDeath");
        this.OnDeath.Invoke();
        StartCoroutine(DespawnCop());
    }

    public IEnumerator DespawnCop()
    {
        yield return new WaitForSeconds(10f);
        this.gameObject.SetActive(false);
    }
}


