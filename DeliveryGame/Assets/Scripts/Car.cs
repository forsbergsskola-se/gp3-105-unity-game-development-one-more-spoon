using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject cameraHolder;
    private Player player;
    public int carHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public  void EnterCar()
    {
      
        this.gameObject.GetComponent<DanielsCarMovementScript>().enabled = true;
         cameraHolder.SetActive(true);
    }

    public void ExitCar()
    {
        this.gameObject.SetActive(true); 
        this.gameObject.GetComponent<DanielsCarMovementScript>().enabled = false;
        cameraHolder.SetActive(false);
        
    }
    
    
     private void OnCollisionEnter(Collision hitWithMeleeWeapon)
    {
        if (hitWithMeleeWeapon.gameObject.CompareTag("Bat") && player.meleeAttacking == true)
        {
            carHealth -= 10;
            Debug.Log("The object was hit with a bat. the health is: " + carHealth);
            if (carHealth <= 0)
            {
                Destroy(this.gameObject);
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
