using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthRemover()
    {
        health -= health;
    }
    
    
    void PlayerJump()
    {
        
    }

    
}
