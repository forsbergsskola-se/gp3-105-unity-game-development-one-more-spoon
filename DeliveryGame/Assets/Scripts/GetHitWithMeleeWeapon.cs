using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitWithMeleeWeapon : MonoBehaviour
{
    public int health = 5;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision hitWithMeleeWeapon)
    {
        if (hitWithMeleeWeapon.gameObject.CompareTag("Bat") )
        {
            health -= 1;
            Debug.Log("The object was hit with a bat. the health is: " + health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        
    }
    
}
