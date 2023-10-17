using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();
       
    }
       void PlayerMovement()
        {
             Rigidbody rigidbody = GetComponent<Rigidbody>();
                    
                    if(Input.GetKey(KeyCode.W)) {
                        transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
                    }
                    else if(Input.GetKey(KeyCode.S)) {
                        rigidbody.position += Vector3.back * Time.deltaTime * movementSpeed;
                    }
                    else if(Input.GetKey(KeyCode.A)) {
                        rigidbody.position += Vector3.left * Time.deltaTime * movementSpeed;
                    }
                    else if(Input.GetKey(KeyCode.D)) {
                        rigidbody.position += Vector3.right * Time.deltaTime * movementSpeed;
                    }
        }
    public void healthRemover()
    {
        health -= health;
    }
    
    


    
}
