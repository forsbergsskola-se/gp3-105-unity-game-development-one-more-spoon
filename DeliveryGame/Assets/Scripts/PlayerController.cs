using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    // A two dimensinoal vector that holds what direction the player is moving in.
    private Vector2 movementDirection;
    
    public float movementSpeed = 2;
    
    public float rotationSpeed = 2;
    
    public bool interactPressed = false;
    bool inventoryToggled = false;
    bool isPaused = false;
    bool gunIsShooting = false;
    bool isReloading = false;
    public bool meleeAttacking = false;
    
    public GameObject inventoryGUI;
    public GameObject pauseMenu;
    private Car car;
    private Weapon mainHand;
    private Weapon offHand;
    private bool gunIsEquipped = true;
    public GameObject gunMeshHolder;
    public GameObject batMeshHolder;
    public RawImage mainHandImage;
    public RawImage offHandImage;
    
    public RawImage mainHandImageInventory;
    public RawImage offHandImageInventory;
    
    public Texture gunTexture;
    public Texture batTexture;
    
    public GameObject steveBody;
    
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

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        animator = this.GetComponent<Animator>();
        car = FindFirstObjectByType<Car>();
        mainHand = new Weapon(GetComponentInChildren<Gun>(), null);
        offHand = new Weapon(null, GetComponentInChildren<Bat>());
        Debug.Log(mainHand);
        Debug.Log(mainHand.gun);
        Debug.Log(mainHand.bat);
        Debug.Log(offHand);
        Debug.Log(offHand.bat);
        Debug.Log(offHand.gun);
    }

    
     void Update()
    {
        // Move the player in the movement direction.
        MovePlayer(movementDirection);
        
        
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            steveBody.SetActive(true);
            this.gameObject.transform.position = GameObject.Find("SEDAN").transform.position + new Vector3(-2.5f, 0f, 0f);
            car.ExitCar();
        }
        
    }
     
    public void Interact(InputAction.CallbackContext interactButtonPressed)
    {
        if (interactButtonPressed.performed)
        {
            interactPressed = true;
            Debug.Log("Interact button Pressed");
        }

        else if (interactButtonPressed.canceled)
        {
            interactPressed = false;
            Debug.Log("Interact button Released");
        }
    }
    
    public void Fire(InputAction.CallbackContext fireButtonPressed)
    {
        if (fireButtonPressed.performed)
        {
            var player = FindFirstObjectByType<Player>();
            if (gunIsShooting == false && meleeAttacking == false )
            {
                
            
            if (mainHand.gun != null)
            {
                FireGun();
            }

            if (mainHand.bat != null)
            {
                AttackWithMeleeWeapon();
            }
            }
            
        }

        else if (fireButtonPressed.canceled)
        {
            interactPressed = false;
        }
    }
    
    public void Inventory(InputAction.CallbackContext inventoryButtonPressed)
    {
        if (inventoryButtonPressed.performed)
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

    public void Pause(InputAction.CallbackContext pauseButtonPressed)
    {
        if (pauseButtonPressed.performed)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            
            }
        }
    }
    
    public void PlayDeathAnimation()
    {
        animator.Play("Death");
    }
    
    public void SetBackToIdle()
    {
        animator.Play("Idle");
    }



    public void FireGun()
    {
        if (!gunIsShooting && mainHand.gun != null && mainHand.gun.ammoLeft > 0 && !isReloading && !gunIsShooting && !meleeAttacking)
        {
            gunIsShooting = true;
            mainHand.gun.RemoveAmmo();
            FireGunAnimation();
        }
    }

    public void FireGunAnimation()
    {
        animator.Play("ShootingGun");
        // animator.SetBool("isFiring", true);
    }

    public void GunFireFinished()
    {
        // animator.SetBool("isFiring", false);
        Debug.Log("Gun finished shooting");
        gunIsShooting = false;
    }
    
    public void ReloadButton(InputAction.CallbackContext reloadButtonPressed)
    {
        if (reloadButtonPressed.performed && !gunIsShooting && !meleeAttacking && mainHand.gun != null)
        {
            isReloading = true;
            Debug.Log("Reloading gun.");
            Gun gun = GetComponentInChildren<Gun>();
            gun.ReloadGun();
            animator.Play("Reloading");
        }
    }
    
    public void ReloadDone()
    {
        isReloading = false;
    }

    public void AttackWithMeleeWeapon()
    {
        if (mainHand.bat != null)
        {
        var player = FindFirstObjectByType<Player>();
        meleeAttacking = true;
        animator.Play("MeleeAttack");
        Debug.Log("Hitting with melee weapon");
        }
        
    }

    
    public void MeleeHit()
    {
        var player = FindFirstObjectByType<Player>();
        meleeAttacking = false;
        
    }

    public void OnTriggerStay(Collider playerGettingInTheCar)
    {
        if (playerGettingInTheCar.CompareTag("Car"))
        {
            Debug.Log("Inside of the car box collider");
            if (Input.GetKeyDown(KeyCode.F) && car.playerCanEnterCar == true)
            { 
                steveBody.SetActive(false);
                car.EnterCar();  
            }
        }
    }

    public void SwitchWeapon(InputAction.CallbackContext switchWeaponButtonPressed)
    {
        if (switchWeaponButtonPressed.performed && !isReloading && !gunIsShooting && !meleeAttacking )
        {
            Debug.Log("Switching Weapons");
            gunIsEquipped = !gunIsEquipped;
            var temp = mainHand;
            mainHand = offHand;
            offHand = temp;
            Debug.Log(mainHand.bat);
            Debug.Log(mainHand.gun);
            if (gunIsEquipped)
            {
                gunMeshHolder.SetActive(true);
                batMeshHolder.SetActive(false);
                
                mainHandImage.texture = gunTexture;
                mainHandImageInventory.texture = gunTexture;
                
                offHandImage.texture = batTexture;
                offHandImageInventory.texture = batTexture;


            }
            else
            {
                gunMeshHolder.SetActive(false);
                batMeshHolder.SetActive(true);
                mainHandImage.texture = batTexture;
                mainHandImageInventory.texture = batTexture;
                
                offHandImage.texture = gunTexture;
                offHandImageInventory.texture = gunTexture;

                
            }
        }
    }
    
    public void MainHand()
    {
        
    }
    
    public void OffHand()
    {
        
    }
        
    
}
