using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject cameraHolder;
    private Player player;
    private PlayerController playerController;
    public bool playerIsInTheCar = false;
    
    public int carHealth;
    public bool playerCanEnterCar = true;
    public Material burntMetalMaterial;

    public GameObject fireEffect;
    public GameObject explosionEffect;


    
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        playerController = FindFirstObjectByType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carHealth <= 0 && playerIsInTheCar == true && player.isDying == false)
        {
            player.health = 0;
            this.gameObject.GetComponent<CarMovementScript>().movementSpeed = 0;
            this.gameObject.GetComponent<CarMovementScript>().rotationSpeed = 0;
            
            StartCoroutine(player.CheckHealth());
            
        }
    }

   public  void EnterCar()
   {
       playerIsInTheCar = true;
        this.gameObject.GetComponent<CarMovementScript>().enabled = true;
         cameraHolder.SetActive(true);
    }

    public void ExitCar()
    {
        this.gameObject.SetActive(true);
        playerIsInTheCar = false;
        this.gameObject.GetComponent<CarMovementScript>().enabled = false;
        cameraHolder.SetActive(false);
        

    }
    
    
     private void OnCollisionEnter(Collision hitWithMeleeWeapon)
    {
        if (hitWithMeleeWeapon.gameObject.CompareTag("Bat") && playerController.meleeAttacking)
        {
            carHealth -= 10;
            Debug.Log("The object was hit with a bat. the health is: " + carHealth);

            if (carHealth <= 0)
            {
                MeshRenderer sedanMaterial = this.gameObject.GetComponent<MeshRenderer>();
                sedanMaterial.material = burntMetalMaterial;
                explosionEffect.SetActive(true);
                playerCanEnterCar = false;
                FireEffectTimeout fireEffectTimeout = GetComponentInChildren<FireEffectTimeout>();
                StartCoroutine(fireEffectTimeout.FireTimeOut());
                
            }
            if (carHealth <= 20)
            {
                fireEffect.SetActive(true);
            }
        }

    }
     public void OnCollisionStay(Collision other)
     {
         Debug.Log("Collision: " + other.impulse.magnitude);
         if (other.impulse.magnitude > 500)
         { 
             carHealth -= 10;
             Debug.Log("The object was hit with a bat. the health is: " + carHealth);

             if (carHealth <= 0 )
             {
                 MeshRenderer sedanMaterial = this.gameObject.GetComponent<MeshRenderer>();
                 sedanMaterial.material = burntMetalMaterial;
                 explosionEffect.SetActive(true);
                 playerCanEnterCar = false;
                 FireEffectTimeout fireEffectTimeout = GetComponentInChildren<FireEffectTimeout>();
                 StartCoroutine(fireEffectTimeout.FireTimeOut());
                 
              
             }
             if (carHealth <= 20)
             {
                 fireEffect.SetActive(true);
             }
         }
         
     }

  

     /*
    public void TakeDamage(int damage)
    {
        carHealth -= damage;
        Debug.Log("The car was hit. Health is now: " + carHealth);

    }
    */
    
}
