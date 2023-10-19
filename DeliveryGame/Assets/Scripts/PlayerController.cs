using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // A two dimensinoal vector that holds what direction the player is moving in.
    private Vector2 movementDirection;
    
    public float movementSpeed = 2;

    public float rotationSpeed = 2;
    
    bool interactPressed = false;
    bool inventoryToggled = false;

    public GameObject inventoryGUI;
     

    Animator animator;
    
    /// <summary>
    /// Read the value from the keyboard or controllers input and put it in moveDirection variable.
    /// </summary>
    /// <param name="context"></param>
    public void OnMovement(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    
    /// <summary>
    /// Move function that takes the input of direction and translates it into movement.
    /// </summary>
    /// <param name="direction"></param>
    void MovePlayer(Vector2 direction)
    {
        // Since this is a vector 2 then we use the y on the vector 2 for the z direction.
        transform.Translate(0, 0, direction.y * movementSpeed * Time.deltaTime);
        transform.Rotate(0, direction.x * rotationSpeed * Time.deltaTime, 0);
        float forwardInput = direction.y;

        if (forwardInput > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else if (forwardInput < 0)
        {
            Debug.Log("RunningBack");
            animator.SetBool("isBackwardsRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isBackwardsRunning", false);
        }
    }
    
    
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        // Move the player in the movement direction.
        MovePlayer(movementDirection);
    }

    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }

        else if (context.canceled)
        {
            interactPressed = false;
        }
    }
    public void Inventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventoryToggled = !inventoryToggled;
            if (inventoryToggled)
            {
                inventoryGUI.SetActive(true);
                
            }
            else
            {
                inventoryGUI.SetActive(false);
            }
        }

    }
    
}
