using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DanielsCarMovementScript : MonoBehaviour
{
    private Vector2 movementDirection;
    
    // CAR MASS in unity should be set to 1000.
    public float movementSpeed = 35000;
   
    public float rotationSpeed = 10000;

    private Rigidbody carRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCar(movementDirection);
        Debug.Log(carRigidbody.velocity);
    }
    
    public void OnCarMovement(InputAction.CallbackContext buttonPressed)
    {
        movementDirection = buttonPressed.ReadValue<Vector2>();
    }

    void MoveCar(Vector2 direction)
    {

        float forwardForce = direction.y * movementSpeed;
        
        carRigidbody.AddForce(transform.forward * forwardForce);
       
        float RotationMovement = direction.x * rotationSpeed;
        
        carRigidbody.AddTorque(Vector3.up * RotationMovement);
        
    }

}
