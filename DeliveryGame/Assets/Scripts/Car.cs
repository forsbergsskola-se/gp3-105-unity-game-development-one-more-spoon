using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject cameraHolder;
    public int carHealth;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
